using Library.Enums;
using Library.Miscellaneous;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class OrdinaryShapeDrawHelper
    {
        public static void Activate(Graphics graphics, bool drawActualShape)
        {
            if (MouseTracker.HorizontalDistance == 0 || MouseTracker.VerticalDistance == 0)
                return;

            var savedGraphicsState = graphics.Save();
            AppManager.ConfigureGraphics(graphics);

            Draw(graphics, drawActualShape);

            graphics.Restore(savedGraphicsState);
        }

        private static void Draw(Graphics graphics, bool drawActualShape)
        {
            if (AppManager.State.ShapeDrawMode == ShapeDrawMode.NoOutlineAndFill)
                return;

            float factor;

            if (drawActualShape)
                factor = 1.0f;
            else factor = AppManager.State.ZoomFactor;

            var path = GetShapePath(factor);

            if (AppManager.State.ShapeDrawMode != ShapeDrawMode.OnlyOutline)
            {
                Brush fillTool;

                if (AppManager.State.ShapeFillMode == ShapeFillMode.Solid)
                    fillTool = new SolidBrush(AppManager.GetSecondaryColor());
                else
                {
                    fillTool = new LinearGradientBrush(
                            new RectangleF(
                                MouseTracker.MouseDownPoint.X * factor,
                                MouseTracker.MouseDownPoint.Y * factor,
                                MouseTracker.HorizontalDistance * factor,
                                MouseTracker.VerticalDistance * factor
                                ),
                            AppManager.GetSecondaryColor(),
                            Color.FromArgb(0, AppManager.GetSecondaryColor()),
                            AppManager.State.ShapeFillLinearGradientMode
                            );
                }

                graphics.FillPath(fillTool, path);

                fillTool.Dispose();
            }

            if (AppManager.State.ShapeDrawMode != ShapeDrawMode.OnlyFill)
            {
                Pen drawTool = AppManager.GetSelectedTool().With(t =>
                {
                    t.Color = AppManager.GetPrimaryColor();
                    t.Width *= factor;
                });

                graphics.DrawPath(drawTool, path);

                drawTool.Dispose();
            }
        }

        private static GraphicsPath GetShapePath(float factor = 1)
        {
            GraphicsPath path = new GraphicsPath();

            switch (AppManager.State.Shape)
            {
                case OrdinaryShape.Line:
                    path.AddLine(
                            MouseTracker.MouseDownPoint.X * factor,
                            MouseTracker.MouseDownPoint.Y * factor,
                            MouseTracker.MouseMovePoint.X * factor,
                            MouseTracker.MouseMovePoint.Y * factor);
                    break;
                case OrdinaryShape.Ellipse:
                    path.AddEllipse(
                            MouseTracker.MouseDownPoint.X * factor,
                            MouseTracker.MouseDownPoint.Y * factor,
                            MouseTracker.HorizontalDistance * factor,
                            MouseTracker.VerticalDistance * factor);
                    break;
                case OrdinaryShape.Rectangle:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddRectangle(new RectangleF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor,
                                MouseTracker.MouseDownPoint.Y * factor,
                                Math.Abs(MouseTracker.HorizontalDistance) * factor,
                                MouseTracker.VerticalDistance * factor));
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddRectangle(new RectangleF(
                                MouseTracker.MouseDownPoint.X * factor,
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor,
                                MouseTracker.HorizontalDistance * factor,
                                Math.Abs(MouseTracker.VerticalDistance) * factor));
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddRectangle(new RectangleF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor,
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor,
                                Math.Abs(MouseTracker.HorizontalDistance) * factor,
                                Math.Abs(MouseTracker.VerticalDistance) * factor));
                    else
                        path.AddRectangle(new RectangleF(
                                MouseTracker.MouseDownPoint.X * factor,
                                MouseTracker.MouseDownPoint.Y * factor,
                                MouseTracker.HorizontalDistance * factor,
                                MouseTracker.VerticalDistance * factor));
                    break;
                case OrdinaryShape.Triangle:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddPolygon(
                            [new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                MouseTracker.MouseDownPoint.Y * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor
                                ),
                            new PointF(
                                MouseTracker.MouseDownPoint.X * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor
                                )
                            ]);
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon(
                            [new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor
                                ),
                            new PointF(
                                MouseTracker.MouseDownPoint.X * factor, 
                                MouseTracker.MouseDownPoint.Y * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor, 
                                MouseTracker.MouseDownPoint.Y * factor)
                            ]);
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon(
                            [new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor, 
                                MouseTracker.MouseDownPoint.Y * factor
                                ),
                            new PointF(
                                MouseTracker.MouseDownPoint.X * factor, 
                                MouseTracker.MouseDownPoint.Y * factor)
                            ]);
                    else
                        path.AddPolygon(
                            [new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                MouseTracker.MouseDownPoint.Y * factor
                                ),
                            new PointF(
                                MouseTracker.MouseDownPoint.X * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor)
                            ]);
                    break;
                case OrdinaryShape.Rhomb:
                    if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance > 0)
                        path.AddPolygon(
                            [new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                MouseTracker.MouseDownPoint.Y * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor),
                            new PointF(
                                MouseTracker.MouseDownPoint.X * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * factor)
                            ]);
                    else if (MouseTracker.HorizontalDistance > 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon(
                            [new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor
                                ),
                            new PointF(
                                MouseTracker.MouseDownPoint.X * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                MouseTracker.MouseDownPoint.Y * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * factor)
                            ]);
                    else if (MouseTracker.HorizontalDistance < 0 && MouseTracker.VerticalDistance < 0)
                        path.AddPolygon(
                            [new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                MouseTracker.MouseDownPoint.Y * factor
                                ),
                            new PointF(
                                MouseTracker.MouseDownPoint.X * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * factor)
                            ]);
                    else
                        path.AddPolygon(
                            [new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                MouseTracker.MouseDownPoint.Y * factor
                                ),
                            new PointF(
                                MouseTracker.MouseDownPoint.X * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance / 2.0f) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance) * factor
                                ),
                            new PointF(
                                (MouseTracker.MouseDownPoint.X + MouseTracker.HorizontalDistance) * factor, 
                                (MouseTracker.MouseDownPoint.Y + MouseTracker.VerticalDistance / 2.0f) * factor)
                            ]);
                    break;
            }

            return path;
        }
    }
}
