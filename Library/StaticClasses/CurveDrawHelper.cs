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
            Tool = (Pen)AppManager.SelectedTool.Clone();
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
                    if (AppManager.SelectedShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                        return;
                    if (AppManager.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
                    {
                        var savedGraphicsState = graphics.Save();
                        ConfigureGraphics(graphics);

                        graphics.DrawPath(Tool, CanvasDrawPath);

                        graphics.Restore(savedGraphicsState);
                    }
                    CurveDrawNotStarted = true;
                    break;
            }
        }

        public static void DrawCurrentCurveOnCanvas(Graphics graphics)
        {
            if (AppManager.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                var savedGraphicsState = graphics.Save();

                ConfigureGraphics(graphics);
                graphics.DrawPath(Tool, CanvasDrawPath);

                graphics.Restore(savedGraphicsState);
            }
        }

        public static void CreateTemporaryCurve(Graphics graphics)
        {
            if (AppManager.SelectedShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            switch (CurrentIteration)
            {
                case 1:
                    CanvasViewDrawPath = new GraphicsPath();
                    CanvasViewDrawPath.AddBezier(
                                new PointF(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor),
                                new PointF((MouseTracker.MouseDownPoint.X + (MouseTracker.MouseMovePoint.X - MouseTracker.MouseDownPoint.X) / 3) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + (MouseTracker.MouseMovePoint.Y - MouseTracker.MouseDownPoint.Y) / 3) * AppManager.ZoomFactor),
                                new PointF((MouseTracker.MouseDownPoint.X + (MouseTracker.MouseMovePoint.X - MouseTracker.MouseDownPoint.X) / 3 * 2) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + (MouseTracker.MouseMovePoint.Y - MouseTracker.MouseDownPoint.Y) / 3 * 2) * AppManager.ZoomFactor),
                                new PointF(MouseTracker.MouseMovePoint.X * AppManager.ZoomFactor, MouseTracker.MouseMovePoint.Y * AppManager.ZoomFactor));
                    break;
                case 2:
                    CanvasViewDrawPath.Reset();
                    CanvasViewDrawPath.AddBezier(
                                new PointF(CanvasDrawPath.PathPoints[0].X * AppManager.ZoomFactor, CanvasDrawPath.PathPoints[0].Y * AppManager.ZoomFactor),
                                new PointF(MouseTracker.MouseMovePoint.X * AppManager.ZoomFactor, MouseTracker.MouseMovePoint.Y * AppManager.ZoomFactor),
                                new PointF(CanvasDrawPath.PathPoints[2].X * AppManager.ZoomFactor, CanvasDrawPath.PathPoints[2].Y * AppManager.ZoomFactor),
                                new PointF(CanvasDrawPath.PathPoints[3].X * AppManager.ZoomFactor, CanvasDrawPath.PathPoints[3].Y * AppManager.ZoomFactor));
                    break;
                case 3:
                    CanvasViewDrawPath.Reset();
                    CanvasViewDrawPath.AddBezier(
                                new PointF(CanvasDrawPath.PathPoints[0].X * AppManager.ZoomFactor, CanvasDrawPath.PathPoints[0].Y * AppManager.ZoomFactor),
                                new PointF(CanvasDrawPath.PathPoints[1].X * AppManager.ZoomFactor, CanvasDrawPath.PathPoints[1].Y * AppManager.ZoomFactor),
                                new PointF(MouseTracker.MouseMovePoint.X * AppManager.ZoomFactor, MouseTracker.MouseMovePoint.Y * AppManager.ZoomFactor),
                                new PointF(CanvasDrawPath.PathPoints[3].X * AppManager.ZoomFactor, CanvasDrawPath.PathPoints[3].Y * AppManager.ZoomFactor));
                    break;
            }

            DrawCurrentCurveOnCanvasView(graphics);
        }

        public static void DrawCurrentCurveOnCanvasView(Graphics graphics)
        {
            if (AppManager.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                var savedGraphicsState = graphics.Save();
                ConfigureGraphics(graphics);
                Tool.Width *= AppManager.ZoomFactor;
                graphics.DrawPath(Tool, CanvasViewDrawPath);
                Tool.Width /= AppManager.ZoomFactor;
                graphics.Restore(savedGraphicsState);
            }
        }

        private static void SetThickness() => Tool.Width = AppManager.ToolThickness;

        private static void DetermineColor()
        {
            if (MouseTracker.PressedButton == MouseButtons.Left)
                Tool.Color = AppManager.PrimaryColor;
            else if (MouseTracker.PressedButton == MouseButtons.Right)
                Tool.Color = AppManager.SecondaryColor;
        }

        private static void ConfigureGraphics(Graphics graphics)
        {
            if (AppManager.SelectedTool == PaintTools.Pen)
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }
    }
}
