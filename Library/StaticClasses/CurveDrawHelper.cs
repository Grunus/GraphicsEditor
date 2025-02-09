using Library.Enums;
using Library.Miscellaneous;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class CurveDrawHelper
    {
        private static Pen Tool { get; set; }

        private static GraphicsPath TrueCurvePath { get; set; } = new GraphicsPath();

        private static GraphicsPath TemporaryCurvePath { get; set; }

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
            Tool = AppManager.GetSelectedTool().With(t => t.Color = AppManager.GetPrimaryColor());
        }

        public static void CreateTrueCurve(Graphics graphics)
        {
            var lastCurvePath = TrueCurvePath;
            TrueCurvePath = new GraphicsPath();
            switch (CurrentIteration)
            {
                case 1:
                    TrueCurvePath.AddBezier(
                                MouseTracker.MouseDownPoint,
                                new PointF(
                                    MouseTracker.MouseDownPoint.X + (MouseTracker.MouseUpPoint.X - MouseTracker.MouseDownPoint.X) / 3, 
                                    MouseTracker.MouseDownPoint.Y + (MouseTracker.MouseUpPoint.Y - MouseTracker.MouseDownPoint.Y) / 3
                                    ),
                                new PointF(
                                    MouseTracker.MouseDownPoint.X + (MouseTracker.MouseUpPoint.X - MouseTracker.MouseDownPoint.X) / 3 * 2, 
                                    MouseTracker.MouseDownPoint.Y + (MouseTracker.MouseUpPoint.Y - MouseTracker.MouseDownPoint.Y) / 3 * 2
                                    ),
                                MouseTracker.MouseUpPoint
                                );
                    CurveDrawNotStarted = false;
                    CurrentIteration++;
                    break;
                case 2:
                    TrueCurvePath.AddBezier(lastCurvePath.PathPoints[0], MouseTracker.MouseUpPoint, lastCurvePath.PathPoints[1], lastCurvePath.PathPoints[2]);
                    CurrentIteration++;
                    break;
                case 3:
                    TrueCurvePath.AddBezier(lastCurvePath.PathPoints[0], lastCurvePath.PathPoints[1], MouseTracker.MouseUpPoint, lastCurvePath.PathPoints[2]);
                    DrawCurve(graphics);
                    break;
            }
        }

        public static void DrawCurve(Graphics graphics, bool trueCurve = true)
        {
            if (AppManager.State.ShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            if (AppManager.State.ShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                float factor;

                if (trueCurve)
                    factor = 1.0f;
                else
                    factor = AppManager.State.ZoomFactor;

                Tool.Width *= factor;

                var savedGraphicsState = graphics.Save();
                AppManager.ConfigureGraphics(graphics);

                if (trueCurve)
                    graphics.DrawPath(Tool, TrueCurvePath);
                else
                    graphics.DrawPath(Tool, TemporaryCurvePath);

                graphics.Restore(savedGraphicsState);

                Tool.Width /= factor;
            }

            if (trueCurve)
            {
                CurveDrawNotStarted = true;
                Tool.Dispose();
            }
        }

        public static void CreateTemporaryCurve(Graphics graphics)
        {
            TemporaryCurvePath = new GraphicsPath();
            switch (CurrentIteration)
            {
                case 1:
                    TemporaryCurvePath.AddBezier(
                                new PointF(
                                    MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor, 
                                    MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor
                                    ),
                                new PointF(
                                    (MouseTracker.MouseDownPoint.X + (MouseTracker.MouseMovePoint.X - MouseTracker.MouseDownPoint.X) / 3) * AppManager.State.ZoomFactor, 
                                    (MouseTracker.MouseDownPoint.Y + (MouseTracker.MouseMovePoint.Y - MouseTracker.MouseDownPoint.Y) / 3) * AppManager.State.ZoomFactor
                                    ),
                                new PointF(
                                    (MouseTracker.MouseDownPoint.X + (MouseTracker.MouseMovePoint.X - MouseTracker.MouseDownPoint.X) / 3 * 2) * AppManager.State.ZoomFactor, 
                                    (MouseTracker.MouseDownPoint.Y + (MouseTracker.MouseMovePoint.Y - MouseTracker.MouseDownPoint.Y) / 3 * 2) * AppManager.State.ZoomFactor
                                    ),
                                new PointF(
                                    MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor, 
                                    MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor
                                    )
                                );
                    break;
                case 2:
                    TemporaryCurvePath.AddBezier(
                                new PointF(
                                    TrueCurvePath.PathPoints[0].X * AppManager.State.ZoomFactor,
                                    TrueCurvePath.PathPoints[0].Y * AppManager.State.ZoomFactor
                                    ),
                                new PointF(
                                    MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor, 
                                    MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor
                                    ),
                                new PointF(
                                    TrueCurvePath.PathPoints[2].X * AppManager.State.ZoomFactor,
                                    TrueCurvePath.PathPoints[2].Y * AppManager.State.ZoomFactor
                                    ),
                                new PointF(
                                    TrueCurvePath.PathPoints[3].X * AppManager.State.ZoomFactor,
                                    TrueCurvePath.PathPoints[3].Y * AppManager.State.ZoomFactor
                                    )
                                );
                    break;
                case 3:
                    TemporaryCurvePath.AddBezier(
                                new PointF(
                                    TrueCurvePath.PathPoints[0].X * AppManager.State.ZoomFactor, 
                                    TrueCurvePath.PathPoints[0].Y * AppManager.State.ZoomFactor
                                    ),
                                new PointF(
                                    TrueCurvePath.PathPoints[1].X * AppManager.State.ZoomFactor, TrueCurvePath.PathPoints[1].Y * AppManager.State.ZoomFactor
                                    ),
                                new PointF(
                                    MouseTracker.MouseMovePoint.X * AppManager.State.ZoomFactor, 
                                    MouseTracker.MouseMovePoint.Y * AppManager.State.ZoomFactor
                                    ),
                                new PointF(
                                    TrueCurvePath.PathPoints[3].X * AppManager.State.ZoomFactor, 
                                    TrueCurvePath.PathPoints[3].Y * AppManager.State.ZoomFactor
                                    )
                                );
                    break;
            }

            DrawCurve(graphics, false);
        }
    }
}
