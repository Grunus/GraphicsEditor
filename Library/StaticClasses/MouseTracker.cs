namespace Library.StaticClasses
{
    public static class MouseTracker
    {
        public static Point MouseDownPoint { get; set; }

        public static Point PrevMouseMovePoint { get; set; }

        public static Point MouseMovePoint { get; set; }

        public static Point MouseUpPoint { get; set; }

        public static int HorizontalDistance => MouseMovePoint.X - MouseDownPoint.X;

        public static int VerticalDistance => MouseMovePoint.Y - MouseDownPoint.Y;

        public static MouseButtons PressedButton { get; set; }

        public static void RegisterDown(MouseEventArgs e)
        {
            MouseDownPoint = new Point((int)Math.Floor(e.Location.X / AppManager.State.ZoomFactor), (int)Math.Floor(e.Location.Y / AppManager.State.ZoomFactor));

            MouseMovePoint = new Point((int)Math.Floor(e.Location.X / AppManager.State.ZoomFactor), (int)Math.Floor(e.Location.Y / AppManager.State.ZoomFactor));

            PressedButton = e.Button;
        }

        public static void RegisterMove(MouseEventArgs e)
        {
            PrevMouseMovePoint = MouseMovePoint;

            MouseMovePoint = new Point((int)Math.Floor(e.Location.X / AppManager.State.ZoomFactor), (int)Math.Floor(e.Location.Y / AppManager.State.ZoomFactor));
        }

        public static void RegisterUp(MouseEventArgs e)
        {
            MouseUpPoint = new Point((int)Math.Floor(e.Location.X / AppManager.State.ZoomFactor), (int)Math.Floor(e.Location.Y / AppManager.State.ZoomFactor));
        }
    }
}
