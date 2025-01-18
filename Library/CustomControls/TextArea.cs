using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CustomControls
{
    public class TextArea : TextBox
    {
        private const int grab = 8;

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

        public TextArea() : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            AutoSize = false;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            ScrollBars = ScrollBars.None;
            Multiline = true;
            AcceptsTab = true;
            AcceptsReturn = true;
            WordWrap = true;
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
            else if (e.Location.X > Width / 2.0f - grab && e.Location.X < Width / 2.0f + grab && e.Location.Y <= grab)
            {
                IsResizing = true;
                IsDraggingTopSide = true;
            }
            else if (e.Location.X >= Width - grab && e.Location.Y <= grab)
            {
                IsResizing = true;
                IsDraggingTopRightCorner = true;
            }
            else if (e.Location.X >= Width - grab && e.Location.Y > Height / 2.0f - grab && e.Location.Y < Height / 2.0f + grab)
            {
                IsResizing = true;
                IsDraggingRightSide = true;
            }
            else if (e.Location.X >= Width - grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                IsDraggingBottomRightCorner = true;
            }
            else if (e.Location.X > Width / 2.0f - grab && e.Location.X < Width / 2.0f + grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                IsDraggingBottomSide = true;
            }
            else if (e.Location.X <= grab && e.Location.Y >= Height - grab)
            {
                IsResizing = true;
                IsDraggingBottomLeftCorner = true;
            }
            else if (e.Location.X <= grab && e.Location.Y > Height / 2.0f - grab && e.Location.Y < Height / 2.0f + grab)
            {
                IsResizing = true;
                IsDraggingLeftSide = true;
            }
            else if (!(e.Location.X > grab && e.Location.X < Width - grab && e.Location.Y > grab && e.Location.Y < Height - grab))
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
                else if (e.Location.X > Width / 2.0f - grab && e.Location.X < Width / 2.0f + grab && e.Location.Y <= grab)
                    Cursor.Current = Cursors.SizeNS;
                else if (e.Location.X >= Width - grab && e.Location.Y <= grab)
                    Cursor.Current = Cursors.SizeNESW;
                else if (e.Location.X >= Width - grab && e.Location.Y > Height / 2.0f - grab && e.Location.Y < Height / 2.0f + grab)
                    Cursor.Current = Cursors.SizeWE;
                else if (e.Location.X >= Width - grab && e.Location.Y >= Height - grab)
                    Cursor.Current = Cursors.SizeNWSE;
                else if (e.Location.X > Width / 2.0f - grab && e.Location.X < Width / 2.0f + grab && e.Location.Y >= Height - grab)
                    Cursor.Current = Cursors.SizeNS;
                else if (e.Location.X <= grab && e.Location.Y >= Height - grab)
                    Cursor.Current = Cursors.SizeNESW;
                else if (e.Location.X <= grab && e.Location.Y > Height / 2.0f - grab && e.Location.Y < Height / 2.0f + grab)
                    Cursor.Current = Cursors.SizeWE;
                else if (!(e.Location.X > grab && e.Location.X < Width - grab && e.Location.Y > grab && e.Location.Y < Height - grab))
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

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == '\r')
                AdjustHeightSomehow();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            AdjustHeightSomehow();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            AdjustHeightSomehow();
        }

        private void AdjustHeightSomehow()
        {
            using Graphics g = CreateGraphics();
            if (Text != string.Empty)
                Height = (int)Math.Ceiling(g.MeasureString(Text, Font, Width).Height) + 4;
            else
                Height = (int)Math.Ceiling(g.MeasureString(" ", Font, Width).Height) + 4;
        }
    }
}
