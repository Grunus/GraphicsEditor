using Library.Enums;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class CurveDrawHelper
    {
        private static Pen Tool { get; set; }

        private static GraphicsPath CanvasDrawPath { get; set; }

        private static GraphicsPath CanvasViewDrawPath { get; set; }

        private static bool curveDrawNotStarted = true;

        public static bool CurveDrawNotStarted 
        { 
            get => curveDrawNotStarted; 
            set
            {
                curveDrawNotStarted = value;
                if (value == true)
                    CurrentIteration = 1;
            }
        }

        private static int CurrentIteration { get; set; } = 1;

        public static void Activate()
        {
            Tool = (Pen)AppState.SelectedTool.Clone();
            SetThickness();
            DetermineColor();
        }

        public static void CreateCurve(Graphics graphics)
        {
            PointF[] temp;
            switch (CurrentIteration)
            {
                case 1:
                    CanvasDrawPath = new GraphicsPath();
                    CanvasDrawPath.AddBezier(
                                MouseTracker.MouseDownPoint,
                                new PointF(MouseTracker.MouseDownPoint.X + (MouseTracker.MouseUpPoint.X - MouseTracker.MouseDownPoint.X) / 3, MouseTracker.MouseDownPoint.Y + (MouseTracker.MouseUpPoint.Y - MouseTracker.MouseDownPoint.Y) / 3),
                                new PointF(MouseTracker.MouseDownPoint.X + (MouseTracker.MouseUpPoint.X - MouseTracker.MouseDownPoint.X) / 3 * 2, MouseTracker.MouseDownPoint.Y + (MouseTracker.MouseUpPoint.Y - MouseTracker.MouseDownPoint.Y) / 3 * 2),
                                MouseTracker.MouseUpPoint);
                    CurveDrawNotStarted = false;
                    CurrentIteration++;
                    break;
                case 2:
                    temp = [CanvasDrawPath.PathPoints[0], CanvasDrawPath.PathPoints[2], CanvasDrawPath.PathPoints[3]];
                    CanvasDrawPath.Reset();
                    CanvasDrawPath.AddBezier(temp[0], MouseTracker.MouseUpPoint, temp[1], temp[2]);
                    CurrentIteration++;
                    break;
                case 3:
                    temp = [CanvasDrawPath.PathPoints[0], CanvasDrawPath.PathPoints[1], CanvasDrawPath.PathPoints[3]];
                    CanvasDrawPath.Reset();
                    CanvasDrawPath.AddBezier(temp[0], temp[1], MouseTracker.MouseUpPoint, temp[2]);
                    if (AppState.SelectedShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                        return;
                    if (AppState.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
                    {
                        ConfigureGraphics(graphics);
                        graphics.DrawPath(Tool, CanvasDrawPath);
                        UnconfigureGraphics(graphics);
                    }
                    CurveDrawNotStarted = true;
                    break;
            }
        }

        public static void DrawCurrentCurveOnCanvas(Graphics graphics)
        {
            if (AppState.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                ConfigureGraphics(graphics);
                graphics.DrawPath(Tool, CanvasDrawPath);
                UnconfigureGraphics(graphics);
            }
        }

        public static void CreateTemporaryCurve(Graphics graphics)
        {
            if (AppState.SelectedShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            switch (CurrentIteration)
            {
                case 1:
                    CanvasViewDrawPath = new GraphicsPath();
                    CanvasViewDrawPath.AddBezier(
                                new PointF(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor),
                                new PointF((MouseTracker.MouseDownPoint.X + (MouseTracker.MouseMovePoint.X - MouseTracker.MouseDownPoint.X) / 3) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + (MouseTracker.MouseMovePoint.Y - MouseTracker.MouseDownPoint.Y) / 3) * AppState.ZoomFactor),
                                new PointF((MouseTracker.MouseDownPoint.X + (MouseTracker.MouseMovePoint.X - MouseTracker.MouseDownPoint.X) / 3 * 2) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + (MouseTracker.MouseMovePoint.Y - MouseTracker.MouseDownPoint.Y) / 3 * 2) * AppState.ZoomFactor),
                                new PointF(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor, MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor));
                    break;
                case 2:
                    CanvasViewDrawPath.Reset();
                    CanvasViewDrawPath.AddBezier(
                                new PointF(CanvasDrawPath.PathPoints[0].X * AppState.ZoomFactor, CanvasDrawPath.PathPoints[0].Y * AppState.ZoomFactor),
                                new PointF(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor, MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor),
                                new PointF(CanvasDrawPath.PathPoints[2].X * AppState.ZoomFactor, CanvasDrawPath.PathPoints[2].Y * AppState.ZoomFactor),
                                new PointF(CanvasDrawPath.PathPoints[3].X * AppState.ZoomFactor, CanvasDrawPath.PathPoints[3].Y * AppState.ZoomFactor));
                    break;
                case 3:
                    CanvasViewDrawPath.Reset();
                    CanvasViewDrawPath.AddBezier(
                                new PointF(CanvasDrawPath.PathPoints[0].X * AppState.ZoomFactor, CanvasDrawPath.PathPoints[0].Y * AppState.ZoomFactor),
                                new PointF(CanvasDrawPath.PathPoints[1].X * AppState.ZoomFactor, CanvasDrawPath.PathPoints[1].Y * AppState.ZoomFactor),
                                new PointF(MouseTracker.MouseMovePoint.X * AppState.ZoomFactor, MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor),
                                new PointF(CanvasDrawPath.PathPoints[3].X * AppState.ZoomFactor, CanvasDrawPath.PathPoints[3].Y * AppState.ZoomFactor));
                    break;
            }

            DrawCurrentCurveOnCanvasView(graphics);
        }

        public static void DrawCurrentCurveOnCanvasView(Graphics graphics)
        {
            if (AppState.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                ConfigureGraphics(graphics);
                Tool.Width *= AppState.ZoomFactor;
                graphics.DrawPath(Tool, CanvasViewDrawPath);
                Tool.Width /= AppState.ZoomFactor;
                UnconfigureGraphics(graphics);
            }
        }

        private static void SetThickness() => Tool.Width = AppState.ToolThickness;

        private static void DetermineColor()
        {
            if (MouseTracker.PressedButton == MouseButtons.Left)
                Tool.Color = AppState.PrimaryColor;
            else if (MouseTracker.PressedButton == MouseButtons.Right)
                Tool.Color = AppState.SecondaryColor;
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
