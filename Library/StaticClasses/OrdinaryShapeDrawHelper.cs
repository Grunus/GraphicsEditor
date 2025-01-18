using Library.Enums;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class OrdinaryShapeDrawHelper
    {
        private static Pen Tool { get; set; }

        private static SolidBrush SolidFillBrush { get; set; } = new SolidBrush(Color.Black);

        private static LinearGradientBrush LinearGradientFillBrush { get; set; }

        public static void Activate(Graphics graphics, bool drawActualShape)
        {
            if (MouseTracker.HorizontalDistance == 0 || MouseTracker.VerticalDistance == 0)
                return;

            Tool = (Pen)AppState.SelectedTool.Clone();
            SetThickness();
            DetermineColor();

            if (drawActualShape)
                LinearGradientFillBrush = new LinearGradientBrush(new RectangleF(MouseTracker.MouseDownPoint.X, 
                    MouseTracker.MouseDownPoint.Y, MouseTracker.HorizontalDistance, 
                    MouseTracker.VerticalDistance), SolidFillBrush.Color, Color.FromArgb(0, SolidFillBrush.Color), 
                    AppState.SelectedShapeFillLinearGradientMode);
            else
                LinearGradientFillBrush = new LinearGradientBrush(new RectangleF(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor, 
                    MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor, MouseTracker.HorizontalDistance * AppState.ZoomFactor, 
                    MouseTracker.VerticalDistance * AppState.ZoomFactor), SolidFillBrush.Color, Color.FromArgb(0, SolidFillBrush.Color), 
                    AppState.SelectedShapeFillLinearGradientMode);

            ConfigureGraphics(graphics);

            if (drawActualShape)
                DrawActualShape(graphics);  
            else
                DrawTemporaryShape(graphics);

            UnconfigureGraphics(graphics);
        }

        private static void DrawActualShape(Graphics graphics)
        {
            GraphicsPath path = new GraphicsPath();

            switch (AppState.SelectedShape)
            {
                case OrdinaryShape.Line:
                    path.AddLine(
                            MouseTracker.MouseDownPoint.X,
                            MouseTracker.MouseDownPoint.Y,
                            MouseTracker.MouseUpPoint.X,
                            MouseTracker.MouseUpPoint.Y);
                    break;
                case OrdinaryShape.Ellipse:
                    path.AddEllipse(
                            MouseTracker.MouseDownPoint.X,
                            MouseTracker.MouseDownPoint.Y,
                            MouseTracker.HorizontalDistance,
                            MouseTracker.VerticalDistance);
                    break;
                case OrdinaryShape.Rectangle:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddRectangle(new RectangleF(
                                MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, 
                                MouseTracker.MouseDownPoint.Y, 
                                Math.Abs(MouseTracker.HorizontalDistance), 
                                MouseTracker.VerticalDistance));
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddRectangle(new RectangleF(
                                MouseTracker.MouseDownPoint.X, 
                                MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, 
                                MouseTracker.HorizontalDistance,
                                Math.Abs(MouseTracker.VerticalDistance)));
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddRectangle(new RectangleF(
                                MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, 
                                MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance, 
                                Math.Abs(MouseTracker.HorizontalDistance), 
                                Math.Abs(MouseTracker.VerticalDistance)));
                    else
                        path.AddRectangle(new RectangleF(
                                MouseTracker.MouseDownPoint.X,
                                MouseTracker.MouseDownPoint.Y,
                                MouseTracker.HorizontalDistance,
                                MouseTracker.VerticalDistance));
                    break;
                case OrdinaryShape.Triangle:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddPolygon([new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance),
                        new PointF(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance)]);
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance),
                        new PointF(MouseTracker.MouseDownPoint.X , MouseTracker.MouseDownPoint.Y),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y)]);
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y),
                        new PointF(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y)]);
                    else
                        path.AddPolygon([new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y),
                        new PointF(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance)]);
                    break;
                case OrdinaryShape.Rhomb:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddPolygon([new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance),
                        new PointF(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f)]);
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance),
                        new PointF(MouseTracker.MouseDownPoint.X , MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f)]);
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y),
                        new PointF(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f)]);
                    else
                        path.AddPolygon([new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y),
                        new PointF(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance),
                        new PointF(MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance, MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f)]);
                    break;
            }
            Draw(graphics, path);
        }

        private static void DrawTemporaryShape(Graphics graphics)
        {
            GraphicsPath path = new GraphicsPath();

            switch (AppState.SelectedShape)
            {
                case OrdinaryShape.Line:
                    path.AddLine(
                            MouseTracker.MouseDownPoint.X * AppState.ZoomFactor,
                            MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor,
                            MouseTracker.MouseMovePoint.X * AppState.ZoomFactor,
                            MouseTracker.MouseMovePoint.Y * AppState.ZoomFactor);
                    break;
                case OrdinaryShape.Ellipse:
                    path.AddEllipse(
                            MouseTracker.MouseDownPoint.X * AppState.ZoomFactor,
                            MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor,
                            MouseTracker.HorizontalDistance * AppState.ZoomFactor,
                            MouseTracker.VerticalDistance * AppState.ZoomFactor);
                    break;
                case OrdinaryShape.Rectangle:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddRectangle(new RectangleF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor,
                                MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor,
                                Math.Abs(MouseTracker.HorizontalDistance) * AppState.ZoomFactor,
                                MouseTracker.VerticalDistance * AppState.ZoomFactor));
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddRectangle(new RectangleF(
                                MouseTracker.MouseDownPoint.X * AppState.ZoomFactor,
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor,
                                MouseTracker.HorizontalDistance * AppState.ZoomFactor,
                                Math.Abs(MouseTracker.VerticalDistance) * AppState.ZoomFactor));
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddRectangle(new RectangleF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor,
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor,
                                Math.Abs(MouseTracker.HorizontalDistance) * AppState.ZoomFactor,
                                Math.Abs(MouseTracker.VerticalDistance) * AppState.ZoomFactor));
                    else
                        path.AddRectangle(new RectangleF(
                                MouseTracker.MouseDownPoint.X * AppState.ZoomFactor,
                                MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor,
                                MouseTracker.HorizontalDistance * AppState.ZoomFactor,
                                MouseTracker.VerticalDistance * AppState.ZoomFactor));
                    break;
                case OrdinaryShape.Triangle:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor)]);
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor)]);
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor)]);
                    else
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor)]);
                    break;
                case OrdinaryShape.Rhomb:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppState.ZoomFactor)]);
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppState.ZoomFactor)]);
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppState.ZoomFactor)]);
                    else
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppState.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppState.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppState.ZoomFactor)]);
                    break;
            }
            Tool.Width *= AppState.ZoomFactor;
            Draw(graphics, path);
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

        private static void Draw(Graphics graphics, GraphicsPath path)
        {
            if (AppState.SelectedShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            if (AppState.SelectedShapeDrawMode != ShapeDrawMode.OnlyOutline)
            {
                if (AppState.SelectedShapeFillMode == ShapeFillMode.Solid)
                    graphics.FillPath(SolidFillBrush, path);
                else if (AppState.SelectedShapeFillMode == ShapeFillMode.LinearGradient)
                    graphics.FillPath(LinearGradientFillBrush, path);
            }

            if (AppState.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
                graphics.DrawPath(Tool, path);
        }
    }
}
