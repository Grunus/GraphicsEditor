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

            Tool = (Pen)AppManager.SelectedTool.Clone();
            SetThickness();
            DetermineColor();

            if (drawActualShape)
                LinearGradientFillBrush = new LinearGradientBrush(new RectangleF(MouseTracker.MouseDownPoint.X, 
                    MouseTracker.MouseDownPoint.Y, MouseTracker.HorizontalDistance, 
                    MouseTracker.VerticalDistance), SolidFillBrush.Color, Color.FromArgb(0, SolidFillBrush.Color), 
                    AppManager.SelectedShapeFillLinearGradientMode);
            else
                LinearGradientFillBrush = new LinearGradientBrush(new RectangleF(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor, 
                    MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor, MouseTracker.HorizontalDistance * AppManager.ZoomFactor, 
                    MouseTracker.VerticalDistance * AppManager.ZoomFactor), SolidFillBrush.Color, Color.FromArgb(0, SolidFillBrush.Color), 
                    AppManager.SelectedShapeFillLinearGradientMode);

            var savedGraphicsState = graphics.Save();
            ConfigureGraphics(graphics);

            if (drawActualShape)
                DrawActualShape(graphics);  
            else
                DrawTemporaryShape(graphics);

            graphics.Restore(savedGraphicsState);
        }

        private static void DrawActualShape(Graphics graphics)
        {
            GraphicsPath path = new GraphicsPath();

            switch (AppManager.SelectedShape)
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

            switch (AppManager.SelectedShape)
            {
                case OrdinaryShape.Line:
                    path.AddLine(
                            MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor,
                            MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor,
                            MouseTracker.MouseMovePoint.X * AppManager.ZoomFactor,
                            MouseTracker.MouseMovePoint.Y * AppManager.ZoomFactor);
                    break;
                case OrdinaryShape.Ellipse:
                    path.AddEllipse(
                            MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor,
                            MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor,
                            MouseTracker.HorizontalDistance * AppManager.ZoomFactor,
                            MouseTracker.VerticalDistance * AppManager.ZoomFactor);
                    break;
                case OrdinaryShape.Rectangle:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddRectangle(new RectangleF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.ZoomFactor,
                                MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor,
                                Math.Abs(MouseTracker.HorizontalDistance) * AppManager.ZoomFactor,
                                MouseTracker.VerticalDistance * AppManager.ZoomFactor));
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddRectangle(new RectangleF(
                                MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor,
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor,
                                MouseTracker.HorizontalDistance * AppManager.ZoomFactor,
                                Math.Abs(MouseTracker.VerticalDistance) * AppManager.ZoomFactor));
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddRectangle(new RectangleF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.ZoomFactor,
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor,
                                Math.Abs(MouseTracker.HorizontalDistance) * AppManager.ZoomFactor,
                                Math.Abs(MouseTracker.VerticalDistance) * AppManager.ZoomFactor));
                    else
                        path.AddRectangle(new RectangleF(
                                MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor,
                                MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor,
                                MouseTracker.HorizontalDistance * AppManager.ZoomFactor,
                                MouseTracker.VerticalDistance * AppManager.ZoomFactor));
                    break;
                case OrdinaryShape.Triangle:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor)]);
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor)]);
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor)]);
                    else
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor)]);
                    break;
                case OrdinaryShape.Rhomb:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppManager.ZoomFactor)]);
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppManager.ZoomFactor)]);
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppManager.ZoomFactor)]);
                    else
                        path.AddPolygon([new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor),
                        new PointF(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * AppManager.ZoomFactor),
                        new PointF((MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * AppManager.ZoomFactor, (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * AppManager.ZoomFactor)]);
                    break;
            }
            Tool.Width *= AppManager.ZoomFactor;
            Draw(graphics, path);
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

        private static void Draw(Graphics graphics, GraphicsPath path)
        {
            if (AppManager.SelectedShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            if (AppManager.SelectedShapeDrawMode != ShapeDrawMode.OnlyOutline)
            {
                if (AppManager.SelectedShapeFillMode == ShapeFillMode.Solid)
                    graphics.FillPath(SolidFillBrush, path);
                else if (AppManager.SelectedShapeFillMode == ShapeFillMode.LinearGradient)
                    graphics.FillPath(LinearGradientFillBrush, path);
            }

            if (AppManager.SelectedShapeDrawMode != ShapeDrawMode.OnlyFill)
                graphics.DrawPath(Tool, path);
        }
    }
}
