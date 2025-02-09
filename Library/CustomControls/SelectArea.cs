using Library.Enums;

namespace Library.CustomControls
{
    public class SelectArea : PictureBox
    {
        private const int grab = 10;

        private Point PointForMoving;

        public bool IsResizing { get; set; } = false;

        public bool IsMoving { get; set; } = false;

        private DragHandle DragHandle { get; set; } = DragHandle.None;

        public SelectArea() : base()
        {
            Margin = new Padding(0);
            Padding = new Padding(0);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Location.X <= grab && e.Location.Y <= grab)
            {
                IsResizing = true;
                DragHandle = DragHandle.TopLeftCorner;
            }
            else if (e.Location.X > grab && e.Location.X < Width - grab && e.Location.Y <= grab)
            {
                IsResizing = true;
                DragHandle = DragHandle.TopSide;
            }
            else if (e.Location.X >= Width - grab && e.Location.Y <= grab)
            {
                IsResizing = true;
                DragHandle = DragHandle.TopRightCorner;
            }
            else if (e.Location.X >= Width - grab && e.Location.Y > grab && e.Location.Y < Height - grab)
            {
                IsResizing = true;
                DragHandle = DragHandle.RightSide;
            }
            else if (e.Location.X >= Width - grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                DragHandle = DragHandle.BottomRightCorner;
            }
            else if (e.Location.X > grab && e.Location.X < Width - grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                DragHandle = DragHandle.BottomSide;
            }
            else if (e.Location.X <= grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                DragHandle = DragHandle.BottomLeftCorner;
            }
            else if (e.Location.X <= grab && e.Location.Y > grab && e.Location.Y < Height - grab)
            {
                IsResizing = true;
                DragHandle = DragHandle.LeftSide;
            }
            else
            {
                IsMoving = true;
                PointForMoving = e.Location;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!IsResizing && !IsMoving)
            {
                if (e.Location.X <= grab && e.Location.Y <= grab)
                    Cursor.Current = Cursors.SizeNWSE;
                else if (e.Location.X > grab && e.Location.X < Width - grab && e.Location.Y <= grab)
                    Cursor.Current = Cursors.SizeNS;
                else if (e.Location.X >= Width - grab && e.Location.Y <= grab)
                    Cursor.Current = Cursors.SizeNESW;
                else if (e.Location.X >= Width - grab && e.Location.Y > grab && e.Location.Y < Height - grab)
                    Cursor.Current = Cursors.SizeWE;
                else if (e.Location.X >= Width - grab && e.Location.Y >= Height - grab)
                    Cursor.Current = Cursors.SizeNWSE;
                else if (e.Location.X > grab && e.Location.X < Width - grab && e.Location.Y >= Height - grab)
                    Cursor.Current = Cursors.SizeNS;
                else if (e.Location.X <= grab && e.Location.Y >= Height - grab)
                    Cursor.Current = Cursors.SizeNESW;
                else if (e.Location.X <= grab && e.Location.Y > grab && e.Location.Y < Height - grab)
                    Cursor.Current = Cursors.SizeWE;
                else
                    Cursor.Current = Cursors.SizeAll;
            }
            else if (!IsMoving)
            {
                if (DragHandle == DragHandle.TopSide)
                {
                    Size = new Size(Width, Height - e.Location.Y);
                    Top += e.Location.Y;
                    Cursor.Current = Cursors.SizeNS;
                }
                else if (DragHandle == DragHandle.RightSide)
                {
                    Size = new Size(e.Location.X, Height);
                    Cursor.Current = Cursors.SizeWE;
                }
                else if (DragHandle == DragHandle.BottomSide)
                {
                    Size = new Size(Width, e.Location.Y);
                    Cursor.Current = Cursors.SizeNS;
                }
                else if (DragHandle == DragHandle.LeftSide)
                {
                    Size = new Size(Width - e.Location.X, Height);
                    Left += e.Location.X;
                    Cursor.Current = Cursors.SizeWE;
                }
                else if (DragHandle == DragHandle.TopRightCorner)
                {
                    Size = new Size(e.Location.X, Height - e.Location.Y);
                    Top += e.Location.Y;
                    Cursor.Current = Cursors.SizeNESW;
                }
                else if (DragHandle == DragHandle.BottomRightCorner)
                {
                    Size = new Size(e.Location.X, e.Location.Y);
                    Cursor.Current = Cursors.SizeNWSE;
                }
                else if (DragHandle == DragHandle.BottomLeftCorner)
                {
                    Size = new Size(Width - e.Location.X, e.Location.Y);
                    Left += e.Location.X;
                    Cursor.Current = Cursors.SizeNESW;
                }
                else if (DragHandle == DragHandle.TopLeftCorner)
                {
                    Size = new Size(Width - e.Location.X, Height - e.Location.Y);
                    Top += e.Location.Y;
                    Left += e.Location.X;
                    Cursor.Current = Cursors.SizeNWSE;
                }
            }
            else
            {
                Location = new Point(Left + e.Location.X - PointForMoving.X, Top + e.Location.Y - PointForMoving.Y);
                Cursor.Current = Cursors.SizeAll;
            }
            Application.DoEvents();
            Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            IsResizing = false;
            IsMoving = false;
            DragHandle = DragHandle.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, Width, Height), Color.Blue, ButtonBorderStyle.Dashed);
        }
    }
}
