namespace Library.StaticClasses
{
    public static class MouseTracker
    {
        public static Point MouseDownPoint { get; set; }

        public static Point PrevMouseMovePoint { get; set; }

        public static Point MouseMovePoint { get; set; }

        public static Point MouseUpPoint { get; set; }

        public static int HorizontalDistance { get; set; }

        public static int VerticalDistance { get; set; }

        public static MouseButtons PressedButton { get; set; }

        public static void RegisterDown(MouseEventArgs e)
        {
            MouseDownPoint = new Point((int)Math.Floor(e.Location.X / AppState.ZoomFactor), (int)Math.Floor(e.Location.Y / AppState.ZoomFactor));

            MouseMovePoint = new Point((int)Math.Floor(e.Location.X / AppState.ZoomFactor), (int)Math.Floor(e.Location.Y / AppState.ZoomFactor));

            PressedButton = e.Button;
        }

        public static void RegisterMove(MouseEventArgs e)
        {
            PrevMouseMovePoint = MouseMovePoint;

            MouseMovePoint = new Point((int)Math.Floor(e.Location.X / AppState.ZoomFactor), (int)Math.Floor(e.Location.Y / AppState.ZoomFactor));

            CalculateDistances();
        }

        public static void RegisterUp(MouseEventArgs e)
        {
            MouseUpPoint = new Point((int)Math.Floor(e.Location.X / AppState.ZoomFactor), (int)Math.Floor(e.Location.Y / AppState.ZoomFactor));

            CalculateDistances();
        }

        private static void CalculateDistances()
        {
            HorizontalDistance = MouseMovePoint.X - MouseDownPoint.X;
            VerticalDistance = MouseMovePoint.Y - MouseDownPoint.Y;
        }
    }
}
