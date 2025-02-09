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
            Size newSize;
            Rectangle drawRect;
            if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    newSize = new Size(Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.VerticalDistance);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y, Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    newSize = new Size(MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                    drawRect = new Rectangle(0, MouseTracker.MouseDownPoint.Y, MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                {
                    newSize = new Size(Math.Abs(MouseTracker.HorizontalDistance), canvas.Height - MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y, Math.Abs(MouseTracker.HorizontalDistance), temp.Height - MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    newSize = new Size(MouseTracker.MouseDownPoint.X, canvas.Height - MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(0, MouseTracker.MouseDownPoint.Y, MouseTracker.MouseDownPoint.X, temp.Height - MouseTracker.MouseDownPoint.Y);
                }
            }
            else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    newSize = new Size(MouseTracker.HorizontalDistance, Math.Abs(MouseTracker.VerticalDistance));
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, MouseTracker.HorizontalDistance, Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    newSize = new Size(canvas.Width - MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, temp.Width - MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                {
                    newSize = new Size(MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, 0, MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    newSize = new Size(canvas.Width - MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, 0, temp.Width - MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                }
            }
            else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    newSize = new Size(Math.Abs(MouseTracker.HorizontalDistance), Math.Abs(MouseTracker.VerticalDistance));
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, Math.Abs(MouseTracker.HorizontalDistance), Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    newSize = new Size(MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                    drawRect = new Rectangle(0, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, MouseTracker.MouseDownPoint.X, Math.Abs(MouseTracker.VerticalDistance));
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                {
                    newSize = new Size(Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, 0, Math.Abs(MouseTracker.HorizontalDistance), MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    newSize = new Size(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(0, 0, MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
                }
            }
            else
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    newSize = new Size(MouseTracker.HorizontalDistance, MouseTracker.VerticalDistance);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, MouseTracker.HorizontalDistance, MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor))))
                {
                    newSize = new Size(canvas.Width - MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, temp.Width - MouseTracker.MouseDownPoint.X, MouseTracker.VerticalDistance);
                }
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor), 0)))
                {
                    newSize = new Size(MouseTracker.HorizontalDistance, canvas.Height - MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, MouseTracker.HorizontalDistance, temp.Height - MouseTracker.MouseDownPoint.Y);
                }
                else
                {
                    newSize = new Size(canvas.Width - MouseTracker.MouseDownPoint.X, canvas.Height - MouseTracker.MouseDownPoint.Y);
                    drawRect = new Rectangle(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y, temp.Width - MouseTracker.MouseDownPoint.X, temp.Height - MouseTracker.MouseDownPoint.Y);
                }
            }
            Target.Size = new Size((int)Math.Round(newSize.Width * AppManager.State.ZoomFactor), (int)Math.Round(newSize.Height * AppManager.State.ZoomFactor));
            canvas = new Bitmap(newSize.Width, newSize.Height);
            canvasGraphics = Graphics.FromImage(canvas);
            canvasGraphics.Clear(Color.White);
            canvasGraphics.DrawImage(temp, 0, 0, drawRect, GraphicsUnit.Pixel);
        }

        public static void DrawPreviewBorder(CanvasView Target, Graphics graphics)
        {
            float factor = AppManager.State.ZoomFactor;
            Rectangle borderRectangle;

            if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * factor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * factor))))
                    borderRectangle = new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor), (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * factor), (int)Math.Round(MouseTracker.VerticalDistance * factor));
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * factor))))
                    borderRectangle = new Rectangle(0, (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor), (int)Math.Round(MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(MouseTracker.VerticalDistance * factor));
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * factor), 0)))
                    borderRectangle = new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor), (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * factor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * factor));
                else
                    borderRectangle = new Rectangle(0, (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor), (int)Math.Round(MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * factor));
            }
            else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * factor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * factor))))
                    borderRectangle = new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * factor), (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor), (int)Math.Round(MouseTracker.HorizontalDistance * factor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * factor));
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * factor))))
                    borderRectangle = new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * factor), (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor), (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * factor));
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * factor), 0)))
                    borderRectangle = new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * factor), 0, (int)Math.Round(MouseTracker.HorizontalDistance * factor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor));
                else
                    borderRectangle = new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * factor), 0, (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor));
            }
            else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * factor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * factor))))
                    borderRectangle = new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor), (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor), (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * factor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * factor));
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * factor))))
                    borderRectangle = new Rectangle(0, (int)Math.Round((MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor), (int)Math.Round(MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(Math.Abs(MouseTracker.VerticalDistance) * factor));
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * factor), 0)))
                    borderRectangle = new Rectangle((int)Math.Round((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor), 0, (int)Math.Round(Math.Abs(MouseTracker.HorizontalDistance) * factor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor));
                else
                    borderRectangle = new Rectangle(0, 0, (int)Math.Round(MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor));

            }
            else
            {
                if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * factor), (int)Math.Round(MouseTracker.MouseMovePoint.Y * factor))))
                    borderRectangle = new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor), (int)Math.Round(MouseTracker.HorizontalDistance * factor), (int)Math.Round(MouseTracker.VerticalDistance * factor));
                else if (Target.ClientRectangle.Contains(new Point(0, (int)Math.Round(MouseTracker.MouseMovePoint.Y * factor))))
                    borderRectangle = new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor), (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(MouseTracker.VerticalDistance * factor));
                else if (Target.ClientRectangle.Contains(new Point((int)Math.Round(MouseTracker.MouseMovePoint.X * factor), 0)))
                    borderRectangle = new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor), (int)Math.Round(MouseTracker.HorizontalDistance * factor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * factor));
                else
                    borderRectangle = new Rectangle((int)Math.Round(MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * factor), (int)Math.Round(Target.Width - MouseTracker.MouseDownPoint.X * factor), (int)Math.Round(Target.Height - MouseTracker.MouseDownPoint.Y * factor));
            }

            ControlPaint.DrawBorder(graphics, borderRectangle, Color.Blue, ButtonBorderStyle.Dashed);
        }
    }
}
