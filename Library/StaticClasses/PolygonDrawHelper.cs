using Library.Enums;
using Library.Miscellaneous;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class PolygonDrawHelper
    {
        private static Pen Tool { get; set; }

        private static GraphicsPath PolygonPath { get; set; }

        public static bool PolygonDrawNotStarted { get; set; } = true;

        public static void Activate()
        {
            Tool = AppManager.GetSelectedTool().With(t => t.Color = AppManager.GetPrimaryColor());
        }

        public static void DrawTruePolygon(Bitmap canvas, Graphics graphics)
        {
            if (PolygonDrawNotStarted)
            {
                PolygonPath = new GraphicsPath();
                PolygonPath.AddLine(
                            MouseTracker.MouseDownPoint,
                            MouseTracker.MouseUpPoint);
                PolygonDrawNotStarted = false;
            }
            else
            {
                if (Math.Abs(MouseTracker.MouseUpPoint.X - PolygonPath.PathPoints[0].X) <= 10 && Math.Abs(MouseTracker.MouseUpPoint.Y - PolygonPath.PathPoints[0].Y) <= 10)
                {
                    PolygonPath.CloseFigure();
                    PolygonDrawNotStarted = true;
                }
                else
                    PolygonPath.AddLine(
                            PolygonPath.PathPoints[PolygonPath.PointCount - 1],
                            MouseTracker.MouseUpPoint);
            }

            if (AppManager.State.ShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            if (AppManager.State.ShapeDrawMode != ShapeDrawMode.OnlyOutline)
            {
                Brush fillTool;

                if (AppManager.State.ShapeFillMode == ShapeFillMode.Solid)
                    fillTool = new SolidBrush(AppManager.GetSecondaryColor());
                else
                {
                    fillTool = new LinearGradientBrush(
                        new RectangleF(0, 0, canvas.Width, canvas.Height),
                        AppManager.GetSecondaryColor(), 
                        Color.FromArgb(0, AppManager.GetSecondaryColor()), 
                        AppManager.State.ShapeFillLinearGradientMode);
                    
                }

                graphics.FillPath(fillTool, PolygonPath);
                fillTool.Dispose();
            }

            if (AppManager.State.ShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                var savedGraphicsState = graphics.Save();
                AppManager.ConfigureGraphics(graphics);
                graphics.DrawPath(Tool, PolygonPath);
                graphics.Restore(savedGraphicsState);
            }
        }

        public static void DrawTemporaryPolygon(Graphics graphics)
        {
            if (AppManager.State.ShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            if (AppManager.State.ShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                var savedGraphicsState = graphics.Save();
                AppManager.ConfigureGraphics(graphics);
                Tool.Width *= AppManager.State.ZoomFactor;
                if (PolygonDrawNotStarted)
                {
                    graphics.DrawLine(
                                Tool,
                                MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor,
                                MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor,
                                MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor,
                                MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor);
                }
                else
                    graphics.DrawLine(
                                Tool,
                                PolygonPath.PathPoints[PolygonPath.PointCount - 1].X * AppManager.State.ZoomFactor,
                                PolygonPath.PathPoints[PolygonPath.PointCount - 1].Y * AppManager.State.ZoomFactor,
                                MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor,
                                MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor);
                Tool.Width /= AppManager.State.ZoomFactor;
                graphics.Restore(savedGraphicsState);
            }
        }
    }
}
