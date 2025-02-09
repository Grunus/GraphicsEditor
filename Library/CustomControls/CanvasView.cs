using Library.Enums;

namespace Library.CustomControls
{
    public class CanvasView : PictureBox
    {
        private const int grab = 10;

        public Point PointForResizing { get; set; }

        public bool IsResizing { get; set; } = false;

        public DragHandle DragHandle { get; set; } = DragHandle.None;

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
                DragHandle = DragHandle.RightSide;
            }
            else if (e.Location.Y >= Height - grab && e.Location.X <= Width - grab)
            {
                IsResizing = true;
                DragHandle = DragHandle.BottomSide;
            }    
            else if (e.Location.X >= Width - grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                DragHandle = DragHandle.BottomRightCorner;
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
                if (DragHandle == DragHandle.RightSide)
                {
                    PointForResizing = new Point(e.Location.X >= 16 ? e.Location.X : 16, Height);
                    Cursor.Current = Cursors.SizeWE;
                }
                else if (DragHandle == DragHandle.BottomSide)
                {
                    PointForResizing = new Point(Width, e.Location.Y >= 16 ? e.Location.Y : 16);
                    Cursor.Current = Cursors.SizeNS;
                }
                else if (DragHandle == DragHandle.BottomRightCorner)
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
                if (DragHandle == DragHandle.RightSide)
                {
                    Size = new Size(e.Location.X >= 16 ? e.Location.X : 16, Height);
                    DragHandle = DragHandle.RightSide;
                }
                else if (DragHandle == DragHandle.BottomSide)
                {
                    Size = new Size(Width, e.Location.Y >= 16 ? e.Location.Y : 16);
                    DragHandle = DragHandle.BottomSide;
                }
                else if (DragHandle == DragHandle.BottomRightCorner)
                {
                    Size = new Size(e.Location.X >= 16 ? e.Location.X : 16, e.Location.Y >= 16 ? e.Location.Y : 16);
                    DragHandle = DragHandle.BottomRightCorner;
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

        //If something's wrong with canvas - just delete this property
        public new Image Image
        {
            get => base.Image;
            set
            {
                base.Image?.Dispose();
                base.Image = value;
            }
        }
    }
}
