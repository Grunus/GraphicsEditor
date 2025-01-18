using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class EraserTool
    {
        private static Pen Eraser { get; }

        static EraserTool()
        {
            Eraser = new Pen(Color.White, 1)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round,
                DashCap = DashCap.Round,
                DashStyle = DashStyle.Solid,
            };
        }

        public static void Activate(Graphics graphics, bool mouseMove)
        {
            SetThickness();
            if (mouseMove)
                graphics.DrawLine(Eraser, MouseTracker.PrevMouseMovePoint, MouseTracker.MouseMovePoint);
            else
                graphics.DrawLine(Eraser, MouseTracker.MouseDownPoint, new PointF(MouseTracker.MouseDownPoint.X + 0.75f, MouseTracker.MouseDownPoint.Y + 0.75f));
        }

        private static void SetThickness() => Eraser.Width = AppState.ToolThickness;
    }
}
