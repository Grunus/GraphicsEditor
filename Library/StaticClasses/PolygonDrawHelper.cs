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
            Tool = (Pen)AppState.SelectedTool.Clone();
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

            if (AppState.SelectedShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            if (AppState.SelectedShapeDrawMode != ShapeDrawMode.OnlyOutline)
            {
                if (AppState.SelectedShapeFillMode == ShapeFillMode.Solid)
                    graphics.FillPath(SolidFillBrush, DrawPath);
                else if (AppState.SelectedShapeFillMode == ShapeFillMode.LinearGradient)
                {
                    LinearGradientFillBrush = new LinearGradientBrush(new RectangleF(0, 0, canvas.Width, canvas.Height), SolidFillBrush.Color, Color.FromArgb(0, SolidFillBrush.Color), AppState.SelectedShapeFillLinearGradientMode);
                    graphics.FillPath(LinearGradientFillBrush, DrawPath);
                }
            }

            if (AppState.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                ConfigureGraphics(graphics);
                graphics.DrawPath(Tool, DrawPath);
                UnconfigureGraphics(graphics);
            }
        }

        public static void DrawOnCanvasView(Graphics graphics)
        {
            if (AppState.SelectedShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            if (AppState.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                ConfigureGraphics(graphics);
                Tool.Width *= AppState.ZoomFactor;
                if (PolygonDrawNotStarted)
                {
                    graphics.DrawLine(
                                Tool,
                                MouseTracker.MouseDownPoint.X * AppState.ZoomFactor,
                                MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor,
                                MouseTracker.MouseMovePoint.X * AppState.ZoomFactor,
                                MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor);
                }
                else
                    graphics.DrawLine(
                                Tool,
                                DrawPath.PathPoints[DrawPath.PointCount - 1].X * AppState.ZoomFactor,
                                DrawPath.PathPoints[DrawPath.PointCount - 1].Y * AppState.ZoomFactor,
                                MouseTracker.MouseMovePoint.X * AppState.ZoomFactor,
                                MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor);
                Tool.Width /= AppState.ZoomFactor;
                UnconfigureGraphics(graphics);
            }
        }

        private static void SetThickness() => Tool.Width = AppState.ToolThickness;

        private static void DetermineColor()
        {
            if (MouseTracker.PressedButton == MouseButtons.Left)
            {
                Tool.Color = AppState.PrimaryColor;
                SolidFillBrush.Color = AppState.SecondaryColor;
            }
            else if (MouseTracker.PressedButton == MouseButtons.Right)
            {
                Tool.Color = AppState.SecondaryColor;
                SolidFillBrush.Color = AppState.PrimaryColor;
            }
        }

        private static void ConfigureGraphics(Graphics graphics)
        {
            if (AppState.SelectedTool == PaintTools.Pen)
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private static void UnconfigureGraphics(Graphics graphics)
        {
            if (AppState.SelectedTool == PaintTools.Pen)
                graphics.SmoothingMode = SmoothingMode.None;
        }
    }
}
