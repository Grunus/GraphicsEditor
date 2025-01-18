using Library.StaticClasses;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace Library.CustomControls
{
    public class CanvasView : PictureBox
    {
        private const int grab = 10;

        public Point PointForResizing { get; set; }

        public bool IsResizing { get; set; } = false;

        public bool IsDraggingRightSide { get; set; } = false;

        public bool IsDraggingBottomSide { get; set; } = false;

        public bool IsDraggingBottomRightCorner { get; set; } = false;

        public CanvasView() : base() 
        {
            Margin = new Padding(0);
            Padding = new Padding(0);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Location.X >= Width - grab && e.Location.Y <= Height - grab)
            {
                IsResizing = true;
                IsDraggingRightSide = true;
            }
            else if (e.Location.Y >= Height - grab && e.Location.X <= Width - grab)
            {
                IsResizing = true;
                IsDraggingBottomSide = true;
            }    
            else if (e.Location.X >= Width - grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                IsDraggingBottomRightCorner = true;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!IsResizing)
            {
                if (Parent.PointToClient(Cursor.Position).X - Left > Width || Parent.PointToClient(Cursor.Position).Y - Top > Height)
                    Cursor.Current = Cursors.Default;
                else if (e.Location.X >= Width - grab && e.Location.Y <= Height - grab)
                    Cursor.Current = Cursors.SizeWE;
                else if (e.Location.Y >= Height - grab && e.Location.X <= Width - grab)
                    Cursor.Current = Cursors.SizeNS;
                else if (e.Location.X >= Width - grab && e.Location.Y >= Height - grab)
                    Cursor.Current = Cursors.SizeNWSE;
                else
                    Cursor.Current = Cursors.Default;
                Application.DoEvents();
            }
            else
            {
                if (IsDraggingRightSide)
                {
                    PointForResizing = new Point(e.Location.X >= 16 ? e.Location.X : 16, Height);
                    Cursor.Current = Cursors.SizeWE;
                }
                else if (IsDraggingBottomSide)
                {
                    PointForResizing = new Point(Width, e.Location.Y >= 16 ? e.Location.Y : 16);
                    Cursor.Current = Cursors.SizeNS;
                }
                else if (IsDraggingBottomRightCorner)
                {
                    PointForResizing = new Point(e.Location.X >= 16 ? e.Location.X : 16, e.Location.Y >= 16 ? e.Location.Y : 16);
                    Cursor.Current = Cursors.SizeNWSE;
                }
                Application.DoEvents();
                Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (IsResizing)
            {
                if (IsDraggingRightSide)
                {
                    Size = new Size(e.Location.X >= 16 ? e.Location.X : 16, Height);
                    IsDraggingRightSide = false;
                }
                else if (IsDraggingBottomSide)
                {
                    Size = new Size(Width, e.Location.Y >= 16 ? e.Location.Y : 16);
                    IsDraggingBottomSide = false;
                }
                else if (IsDraggingBottomRightCorner)
                {
                    Size = new Size(e.Location.X >= 16 ? e.Location.X : 16, e.Location.Y >= 16 ? e.Location.Y : 16);
                    IsDraggingBottomRightCorner = false;
                }
                IsResizing = false;
                Parent.Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (IsResizing)
            {
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, PointForResizing.X, PointForResizing.Y), Color.Black, ButtonBorderStyle.Dotted);

                var pos = Parent.PointToClient(Cursor.Position);

                if (!(pos.X - Left <= Width && pos.Y - Top <= Height))
                    Parent.Invalidate();
            }
        }
    }
}
