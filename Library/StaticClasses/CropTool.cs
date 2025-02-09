using Library.CustomControls;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class CropTool
    {
        public static bool CropHappened { get; set; } = false;

        public static void Activate(CanvasView Target, ref Bitmap canvas, ref Graphics canvasGraphics, bool IsSelectAreaActive = false)
        {
            CropHappened = true;
            using Bitmap temp = new Bitmap(canvas);
            if (!IsSelectAreaActive)
                DoAllTheStuff(Target, ref canvas, ref canvasGraphics, temp);
            else
            {
                Target.Size = SelectTool.SelectArea.Size;
                canvas = new Bitmap((int)Math.Round(SelectTool.SelectArea.Width / AppManager.State.ZoomFactor), (int)Math.Round(SelectTool.SelectArea.Height / AppManager.State.ZoomFactor));
                canvasGraphics = Graphics.FromImage(canvas);
                canvasGraphics.Clear(Color.White);
                canvasGraphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                canvasGraphics.DrawImage(SelectTool.SelectArea.Image, 0, 0, canvas.Width, canvas.Height);
                canvasGraphics.InterpolationMode = InterpolationMode.Default;
                SelectTool.SelectAreaDisposeWithoutDrawing(Target);
            }
            Target.Image = canvas;
        }

        private static void DoAllTheStuff(CanvasView Target, ref Bitmap canvas, ref Graphics canvasGraphics, Bitmap temp)
        {
            Rectangle drawRect;
            if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    Target.Size = new Size((int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.VerticalDistance);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y, Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    Target.Size = new Size((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(0, MouseTracker.MouseDownPoint.Y, MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                {
                    Target.Size = new Size((int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(Math.Abs(MouseTracker.HorizontalDistance), canvas.Height - MouseTracker.MouseDownPoint.Y);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y, Math.Abs(MouseTracker.HorizontalDistance), temp.Height - MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    Target.Size = new Size((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(MouseTracker.MouseDownPoint.X, canvas.Height - MouseTracker.MouseDownPoint.Y);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(0, MouseTracker.MouseDownPoint.Y, MouseTracker.MouseDownPoint.X, temp.Height - MouseTracker.MouseDownPoint.Y);
                }
            }
            else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    Target.Size = new Size((int)Math.Round(MouseTracker.HorizontalDistance * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(MouseTracker.HorizontalDistance, Math.Abs(MouseTracker.VerticalDistance));
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, MouseTracker.HorizontalDistance, Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    Target.Size = new Size((int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(canvas.Width - MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, temp.Width - MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                {
                    Target.Size = new Size((int)Math.Round(MouseTracker.HorizontalDistance * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, 0, MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    Target.Size = new Size((int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(canvas.Width - MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, 0, temp.Width - MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                }
            }
            else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    Target.Size = new Size((int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(Math.Abs(MouseTracker.HorizontalDistance), Math.Abs(MouseTracker.VerticalDistance));
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, Math.Abs(MouseTracker.HorizontalDistance), Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    Target.Size = new Size((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(0, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                {
                    Target.Size = new Size((int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.MouseDownPoint.Y);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, 0, Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    Target.Size = new Size((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(0, 0, MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                }
            }
            else
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    Target.Size = new Size((int)Math.Round(MouseTracker.HorizontalDistance * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(MouseTracker.HorizontalDistance, MouseTracker.VerticalDistance);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, MouseTracker.HorizontalDistance, MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    Target.Size = new Size((int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(canvas.Width - MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, temp.Width - MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                {
                    Target.Size = new Size((int)Math.Round(MouseTracker.HorizontalDistance * AppManager.State.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(MouseTracker.HorizontalDistance, canvas.Height - MouseTracker.MouseDownPoint.Y);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, MouseTracker.HorizontalDistance, temp.Height - MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    Target.Size = new Size((int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor));
                    canvas = new Bitmap(canvas.Width - MouseTracker.MouseDownPoint.X, canvas.Height - MouseTracker.MouseDownPoint.Y);
                    canvasGraphics = Graphics.FromImage(canvas);
                    canvasGraphics.Clear(Color.White);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, temp.Width - MouseTracker.MouseDownPoint.X, temp.Height - MouseTracker.MouseDownPoint.Y);
                }
            }
            canvasGraphics.DrawImage(temp, 0, 0, drawRect, GraphicsUnit.Pixel);
        }

        public static void DrawPreviewBorder(CanvasView Target, Graphics graphics)
        {
            if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle(0, (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else
                    ControlPaint.DrawBorder(graphics, new Rectangle(0, (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
            }
            else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.HorizontalDistance * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), 0, (int)Math.Round(MouseTracker.HorizontalDistance * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), 0, (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
            }
            else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle(0, (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), 0, (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else
                    ControlPaint.DrawBorder(graphics, new Rectangle(0, 0, (int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);

            }
            else
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.HorizontalDistance * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor), (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.VerticalDistance * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.HorizontalDistance * AppManager.State.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
                else
                    ControlPaint.DrawBorder(graphics, new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor), (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor)), Color.Blue, ButtonBorderStyle.Dashed);
            }
        }
    }
}
