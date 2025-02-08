namespace Library.CustomControls
{
    public class SelectArea : PictureBox
    {
        private const int grab = 10;

        private Point PointForMoving;

        public bool IsResizing { get; set; } = false;

        public bool IsMoving { get; set; } = false;

        private bool IsDraggingTopSide { get; set; } = false;

        private bool IsDraggingRightSide { get; set; } = false;

        private bool IsDraggingBottomSide { get; set; } = false;

        private bool IsDraggingLeftSide { get; set; } = false;

        private bool IsDraggingTopRightCorner { get; set; } = false;

        private bool IsDraggingBottomRightCorner { get; set; } = false;

        private bool IsDraggingBottomLeftCorner { get; set; } = false;

        private bool IsDraggingTopLeftCorner { get; set; } = false;

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
                IsDraggingTopLeftCorner = true;
            }
            else if (e.Location.X > grab && e.Location.X < Width - grab && e.Location.Y <= grab)
            {
                IsResizing = true;
                IsDraggingTopSide = true;
            }
            else if (e.Location.X >= Width - grab && e.Location.Y <= grab)
            {
                IsResizing = true;
                IsDraggingTopRightCorner = true;
            }
            else if (e.Location.X >= Width - grab && e.Location.Y > grab && e.Location.Y < Height - grab)
            {
                IsResizing = true;
                IsDraggingRightSide = true;
            }
            else if (e.Location.X >= Width - grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                IsDraggingBottomRightCorner = true;
            }
            else if (e.Location.X > grab && e.Location.X < Width - grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                IsDraggingBottomSide = true;
            }
            else if (e.Location.X <= grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                IsDraggingBottomLeftCorner = true;
            }
            else if (e.Location.X <= grab && e.Location.Y > grab && e.Location.Y < Height - grab)
            {
                IsResizing = true;
                IsDraggingLeftSide = true;
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
                if (IsDraggingTopSide)
                {
                    Size = new Size(Width, Height - e.Location.Y);
                    Top += e.Location.Y;
                    Cursor.Current = Cursors.SizeNS;
                }
                else if (IsDraggingRightSide)
                {
                    Size = new Size(e.Location.X, Height);
                    Cursor.Current = Cursors.SizeWE;
                }
                else if (IsDraggingBottomSide)
                {
                    Size = new Size(Width, e.Location.Y);
                    Cursor.Current = Cursors.SizeNS;
                }
                else if (IsDraggingLeftSide)
                {
                    Size = new Size(Width - e.Location.X, Height);
                    Left += e.Location.X;
                    Cursor.Current = Cursors.SizeWE;
                }
                else if (IsDraggingTopRightCorner)
                {
                    Size = new Size(e.Location.X, Height - e.Location.Y);
                    Top += e.Location.Y;
                    Cursor.Current = Cursors.SizeNESW;
                }
                else if (IsDraggingBottomRightCorner)
                {
                    Size = new Size(e.Location.X, e.Location.Y);
                    Cursor.Current = Cursors.SizeNWSE;
                }
                else if (IsDraggingBottomLeftCorner)
                {
                    Size = new Size(Width - e.Location.X, e.Location.Y);
                    Left += e.Location.X;
                    Cursor.Current = Cursors.SizeNESW;
                }
                else if (IsDraggingTopLeftCorner)
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
            IsDraggingTopSide = false;
            IsDraggingRightSide = false;
            IsDraggingBottomSide = false;
            IsDraggingLeftSide = false;
            IsDraggingTopRightCorner = false;
            IsDraggingBottomRightCorner = false;
            IsDraggingBottomLeftCorner = false;
            IsDraggingTopLeftCorner = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, Width, Height), Color.Blue, ButtonBorderStyle.Dashed);
        }
    }
}
