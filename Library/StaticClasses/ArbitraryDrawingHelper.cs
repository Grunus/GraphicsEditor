using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class ArbitraryDrawingHelper
    {
        private static Pen Tool { get; set; }

        public static void Activate(Graphics graphics, bool mouseMove)
        {
            Tool = (Pen)AppManager.SelectedTool.Clone();
            SetThickness();
            DetermineColor();

            var savedGraphicsState = graphics.Save();

            ConfigureGraphics(graphics);

            if (mouseMove)
                graphics.DrawLine(Tool, MouseTracker.PrevMouseMovePoint, MouseTracker.MouseMovePoint);
            else
                graphics.DrawLine(Tool, MouseTracker.MouseDownPoint, new PointF(MouseTracker.MouseDownPoint.X + 0.75f, MouseTracker.MouseDownPoint.Y + 0.75f));

            graphics.Restore(savedGraphicsState);

            Tool.Dispose();
        }

        private static void SetThickness() => Tool.Width = AppManager.ToolThickness;

        private static void DetermineColor()
        {
            if (MouseTracker.PressedButton == MouseButtons.Left) Tool.Color = AppManager.PrimaryColor;
            else if (MouseTracker.PressedButton == MouseButtons.Right) Tool.Color = AppManager.SecondaryColor;
        }

        private static void ConfigureGraphics(Graphics graphics)
        {
            if (AppManager.SelectedTool == PaintTools.Pen)
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }
    }
}

