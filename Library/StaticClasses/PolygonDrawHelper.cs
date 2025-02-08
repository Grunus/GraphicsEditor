using Library.Enums;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class PolygonDrawHelper
    {
        private static Pen Tool { get; set; }

        private static SolidBrush SolidFillBrush { get; set; } = new SolidBrush(Color.Black);

        private static LinearGradientBrush LinearGradientFillBrush { get; set; }

        private static GraphicsPath DrawPath { get; set; }

        public static bool PolygonDrawNotStarted { get; set; } = true;

        public static void Activate()
        {
            Tool = (Pen)AppManager.SelectedTool.Clone();
            SetThickness();
            DetermineColor();
        }

        public static void DrawOnCanvas(Bitmap canvas, Graphics graphics)
        {
            if (PolygonDrawNotStarted)
            {
                DrawPath = new GraphicsPath();
                DrawPath.AddLine(
                            MouseTracker.MouseDownPoint,
                            MouseTracker.MouseUpPoint);
                PolygonDrawNotStarted = false;
            }
            else
            {
                if (Math.Abs(MouseTracker.MouseUpPoint.X - DrawPath.PathPoints[0].X) <= 10 && Math.Abs(MouseTracker.MouseUpPoint.Y - DrawPath.PathPoints[0].Y) <= 10)
                {
                    DrawPath.CloseFigure();
                    PolygonDrawNotStarted = true;
                }
                else
                    DrawPath.AddLine(
                            DrawPath.PathPoints[DrawPath.PointCount - 1],
                            MouseTracker.MouseUpPoint);
            }

            if (AppManager.SelectedShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            if (AppManager.SelectedShapeDrawMode != ShapeDrawMode.OnlyOutline)
            {
                if (AppManager.SelectedShapeFillMode == ShapeFillMode.Solid)
                    graphics.FillPath(SolidFillBrush, DrawPath);
                else if (AppManager.SelectedShapeFillMode == ShapeFillMode.LinearGradient)
                {
                    LinearGradientFillBrush = new LinearGradientBrush(new RectangleF(0, 0, canvas.Width, canvas.Height), SolidFillBrush.Color, Color.FromArgb(0, SolidFillBrush.Color), AppManager.SelectedShapeFillLinearGradientMode);
                    graphics.FillPath(LinearGradientFillBrush, DrawPath);
                }
            }

            if (AppManager.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                ConfigureGraphics(graphics);
                graphics.DrawPath(Tool, DrawPath);
                UnconfigureGraphics(graphics);
            }
        }

        public static void DrawOnCanvasView(Graphics graphics)
        {
            if (AppManager.SelectedShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            if (AppManager.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                ConfigureGraphics(graphics);
                Tool.Width *= AppManager.ZoomFactor;
                if (PolygonDrawNotStarted)
                {
                    graphics.DrawLine(
                                Tool,
                                MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor,
                                MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor,
                                MouseTracker.MouseMovePoint.X * AppManager.ZoomFactor,
                                MouseTracker.MouseMovePoint.Y * AppManager.ZoomFactor);
                }
                else
                    graphics.DrawLine(
                                Tool,
                                DrawPath.PathPoints[DrawPath.PointCount - 1].X * AppManager.ZoomFactor,
                                DrawPath.PathPoints[DrawPath.PointCount - 1].Y * AppManager.ZoomFactor,
                                MouseTracker.MouseMovePoint.X * AppManager.ZoomFactor,
                                MouseTracker.MouseMovePoint.Y * AppManager.ZoomFactor);
                Tool.Width /= AppManager.ZoomFactor;
                UnconfigureGraphics(graphics);
            }
        }

        private static void SetThickness() => Tool.Width = AppManager.ToolThickness;

        private static void DetermineColor()
        {
            if (MouseTracker.PressedButton == MouseButtons.Left)
            {
                Tool.Color = AppManager.PrimaryColor;
                SolidFillBrush.Color = AppManager.SecondaryColor;
            }
            else if (MouseTracker.PressedButton == MouseButtons.Right)
            {
                Tool.Color = AppManager.SecondaryColor;
                SolidFillBrush.Color = AppManager.PrimaryColor;
            }
        }

        private static void ConfigureGraphics(Graphics graphics)
        {
            if (AppManager.SelectedTool == PaintTools.Pen)
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private static void UnconfigureGraphics(Graphics graphics)
        {
            if (AppManager.SelectedTool == PaintTools.Pen)
                graphics.SmoothingMode = SmoothingMode.None;
        }
    }
}
