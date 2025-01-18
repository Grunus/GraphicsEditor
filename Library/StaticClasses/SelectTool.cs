using Library.CustomControls;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class SelectTool
    {
        public static bool AlreadySelected { get; set; } = false;

        public static SelectArea SelectArea { get; set; }

        public static void SelectSomeArea(CanvasView Target, Bitmap canvas)
        {
            AlreadySelected = true;
            SelectArea = new SelectArea();
            SelectArea.Paint += SelectArea_Paint;
            Rectangle drawRect;
            if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                {
                    SelectArea.Size = new Size((int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.VerticalDistance);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y, Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                {
                    SelectArea.Size = new Size((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                    drawRect = new Rectangle(0, MouseTracker.MouseDownPoint.Y, MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), 0)))
                {
                    SelectArea.Size = new Size((int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(Math.Abs(MouseTracker.HorizontalDistance), canvas.Height - MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y, Math.Abs(MouseTracker.HorizontalDistance), canvas.Height - MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    SelectArea.Size = new Size((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(MouseTracker.MouseDownPoint.X, canvas.Height - MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(0, MouseTracker.MouseDownPoint.Y, MouseTracker.MouseDownPoint.X, canvas.Height - MouseTracker.MouseDownPoint.Y);
                }
            }
            else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                {
                    SelectArea.Size = new Size((int)Math.Round(MouseTracker.HorizontalDistance * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(MouseTracker.HorizontalDistance, Math.Abs(MouseTracker.VerticalDistance));
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, MouseTracker.HorizontalDistance, Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                {
                    SelectArea.Size = new Size((int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(canvas.Width - MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, canvas.Width - MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), 0)))
                {
                    SelectArea.Size = new Size((int)Math.Round(MouseTracker.HorizontalDistance * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, 0, MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    SelectArea.Size = new Size((int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(canvas.Width - MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, 0, canvas.Width - MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                }
            }
            else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                {
                    SelectArea.Size = new Size((int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(Math.Abs(MouseTracker.HorizontalDistance), Math.Abs(MouseTracker.VerticalDistance));
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, Math.Abs(MouseTracker.HorizontalDistance), Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                {
                    SelectArea.Size = new Size((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                    drawRect = new Rectangle(0, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), 0)))
                {
                    SelectArea.Size = new Size((int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, 0, Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    SelectArea.Size = new Size((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(0, 0, MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                }
            }
            else
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                {
                    SelectArea.Size = new Size((int)Math.Round(MouseTracker.HorizontalDistance * AppState.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(MouseTracker.HorizontalDistance, MouseTracker.VerticalDistance);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, MouseTracker.HorizontalDistance, MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                {
                    SelectArea.Size = new Size((int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(canvas.Width - MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, canvas.Width - MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), 0)))
                {
                    SelectArea.Size = new Size((int)Math.Round(MouseTracker.HorizontalDistance * AppState.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(MouseTracker.HorizontalDistance, canvas.Height - MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, MouseTracker.HorizontalDistance, canvas.Height - MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    SelectArea.Size = new Size((int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor));
                    SelectArea.Image = new Bitmap(canvas.Width - MouseTracker.MouseDownPoint.X, canvas.Height - MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, canvas.Width - MouseTracker.MouseDownPoint.X, canvas.Height - MouseTracker.MouseDownPoint.Y);
                }
            }
            Graphics selectAreaGraphics = Graphics.FromImage(SelectArea.Image);
            selectAreaGraphics.Clear(Color.White);
            selectAreaGraphics.DrawImage(canvas, 0, 0, drawRect, GraphicsUnit.Pixel);
            Graphics.FromImage(canvas).FillRectangle(new SolidBrush(Color.White), drawRect);
            SelectArea.Location = new Point((int)Math.Round(drawRect.X * AppState.ZoomFactor), (int)Math.Round(drawRect.Y * AppState.ZoomFactor));
            Target.Controls.Add(SelectArea);
        }

        public static void SelectPastedImage(CanvasView Target, Bitmap image)
        {
            AlreadySelected = true;
            SelectArea = new SelectArea();
            SelectArea.Paint += SelectArea_Paint;
            SelectArea.Size = new Size((int)Math.Round(image.Width * AppState.ZoomFactor), (int)Math.Round(image.Height * AppState.ZoomFactor));
            SelectArea.Image = image;
            SelectArea.Location = new Point(0, 0);
            Target.Controls.Add(SelectArea);
        }

        public static void SelectAll(CanvasView Target, Bitmap canvas)
        {
            AlreadySelected = true;
            SelectArea = new SelectArea();
            SelectArea.Paint += SelectArea_Paint;
            SelectArea.Size = Target.Size;
            SelectArea.Image = new Bitmap(canvas.Width, canvas.Height);
            Graphics selectAreaGraphics = Graphics.FromImage(SelectArea.Image);
            selectAreaGraphics.Clear(Color.White);
            selectAreaGraphics.DrawImage(canvas, 0, 0);
            Graphics.FromImage(canvas).FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, canvas.Width, canvas.Height));
            SelectArea.Location = new Point(0, 0);
            Target.Controls.Add(SelectArea);
        }

        public static void SelectAreaDispose(CanvasView Target, Bitmap canvas)
        {
            Graphics canvasGraphics = Graphics.FromImage(canvas);
            canvasGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            canvasGraphics.DrawImage(SelectArea.Image, SelectArea.Left / AppState.ZoomFactor, SelectArea.Top / AppState.ZoomFactor, SelectArea.Width / AppState.ZoomFactor, SelectArea.Height / AppState.ZoomFactor);
            Target.Controls.Remove(SelectArea);
            SelectArea.Dispose();
        }

        public static void SelectAreaDisposeWithoutDrawing(CanvasView Target)
        {
            Target.Controls.Remove(SelectArea);
            SelectArea.Dispose();
        }

        public static void ReverseSelection(CanvasView Target, Bitmap canvas)
        {
            Bitmap temp = new Bitmap(canvas);
            Graphics.FromImage(canvas).Clear(Color.White);
            SelectAreaDispose(Target, canvas);
            SelectArea = new SelectArea();
            SelectArea.Paint += SelectArea_Paint;
            SelectArea.Size = Target.Size;
            SelectArea.Image = temp;
            SelectArea.Location = new Point(0, 0);
            Target.Controls.Add(SelectArea);
        }

        public static void DrawPreviewBorder(CanvasView Target, Graphics graphics)
        {
            if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle(0, (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), 0)))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else
                    ControlPaint.DrawBorder(graphics, new Rectangle(0, (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
            }
            else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor), (int)Math.Round(MouseTracker.HorizontalDistance * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor), (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), 0)))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), 0, (int)Math.Round(MouseTracker.HorizontalDistance * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), 0, (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
            }
            else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle(0, (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), 0)))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor), 0, (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else
                    ControlPaint.DrawBorder(graphics, new Rectangle(0, 0, (int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);

            }
            else
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor), (int)Math.Round(MouseTracker.HorizontalDistance * AppState.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor), (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor), 0)))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor), (int)Math.Round(MouseTracker.HorizontalDistance * AppState.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor), (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
            }
        }

        private static void SelectArea_Paint(object? sender, PaintEventArgs e)
        {
            GraphicsState temp = e.Graphics.Save();
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            if (AppState.ZoomFactor >= 1)
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            else
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawImage(SelectArea.Image, 0, 0, SelectArea.Width, SelectArea.Height);

            e.Graphics.Restore(temp);

            if (AppState.GridEnabled)
            {
                using Pen p = new Pen(Color.LightGray);

                int cellSizeLength;

                if (AppState.ZoomFactor == 8)
                    cellSizeLength = 8;
                else if (AppState.ZoomFactor == 4)
                    cellSizeLength = 4;
                else if (AppState.ZoomFactor == 2)
                    cellSizeLength = 8;
                else
                    cellSizeLength = 10;

                for (int x = -SelectArea.Location.X; x <= SelectArea.Width; x += cellSizeLength)
                    e.Graphics.DrawLine(p, x, 0, x, SelectArea.Height);

                for (int y = -SelectArea.Location.Y; y <= SelectArea.Height; y += cellSizeLength)
                    e.Graphics.DrawLine(p, 0, y, SelectArea.Width, y);
            }
        }
    }
}
