using System.Drawing.Drawing2D;
using Library.Miscellaneous;

namespace Library.StaticClasses
{
    public static class ArbitraryDrawingHelper
    {
        public static void Activate(Graphics graphics, bool mouseMove, bool erase)
        {
            Pen drawTool;

            if (!erase)
                drawTool = AppManager.GetSelectedTool().With(t => t.Color = AppManager.GetPrimaryColor());
            else
                drawTool = AppManager.GetSpecificTool(Enums.PaintTool.Eraser);

            var savedGraphicsState = graphics.Save();

            AppManager.ConfigureGraphics(graphics);

            if (mouseMove)
                graphics.DrawLine(drawTool, MouseTracker.PrevMouseMovePoint, MouseTracker.MouseMovePoint);
            else
                graphics.DrawLine(drawTool, MouseTracker.MouseDownPoint, new PointF(MouseTracker.MouseDownPoint.X + 0.75f, MouseTracker.MouseDownPoint.Y + 0.75f));

            graphics.Restore(savedGraphicsState);

            drawTool.Dispose();
        }
    }
}

