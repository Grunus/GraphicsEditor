using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class ArbitraryDrawingHelper
    {
        private static Pen Tool { get; set; }

        public static void Activate(Graphics graphics, bool mouseMove)
        {
            Tool = (Pen)AppState.SelectedTool.Clone();
            SetThickness();
            DetermineColor();

            ConfigureGraphics(graphics);

            if (mouseMove)
                graphics.DrawLine(Tool, MouseTracker.PrevMouseMovePoint, MouseTracker.MouseMovePoint);
            else
                graphics.DrawLine(Tool, MouseTracker.MouseDownPoint, new PointF(MouseTracker.MouseDownPoint.X + 0.75f, MouseTracker.MouseDownPoint.Y + 0.75f));

            UnconfigureGraphics(graphics);
        }

        private static void SetThickness() => Tool.Width = AppState.ToolThickness;

        private static void DetermineColor()
        {
            if (MouseTracker.PressedButton == MouseButtons.Left) Tool.Color = AppState.PrimaryColor;
            else if (MouseTracker.PressedButton == MouseButtons.Right) Tool.Color = AppState.SecondaryColor;
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

