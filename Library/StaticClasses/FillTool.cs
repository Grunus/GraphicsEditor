namespace Library.StaticClasses
{
    public static class FillTool
    {
        public static void Activate(Bitmap canvas)
        {
            Point startPoint = MouseTracker.MouseDownPoint;

            Color oldColor = canvas.GetPixel(startPoint.X, startPoint.Y);
            Color newColor = Color.Black;

            if (MouseTracker.PressedButton == MouseButtons.Left)
                newColor = AppManager.GetPrimaryColor();
            else if (MouseTracker.PressedButton == MouseButtons.Right)
                newColor = AppManager.GetSecondaryColor();

            if (oldColor.ToArgb() == newColor.ToArgb())
                return;

            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(startPoint);
            canvas.SetPixel(startPoint.X, startPoint.Y, newColor);
            while (pixels.Count > 0)
            {
                Point pixel = pixels.Pop();          
                if (pixel.X > 0 && pixel.Y > 0 && pixel.X < canvas.Width - 1 && pixel.Y < canvas.Height - 1)
                {
                    Validate(canvas, pixels, new Point(pixel.X - 1, pixel.Y), oldColor, newColor);
                    Validate(canvas, pixels, new Point(pixel.X, pixel.Y - 1), oldColor, newColor);
                    Validate(canvas, pixels, new Point(pixel.X + 1, pixel.Y), oldColor, newColor);
                    Validate(canvas, pixels, new Point(pixel.X, pixel.Y + 1), oldColor, newColor);
                }
            }

            static void Validate(Bitmap canvas, Stack<Point> pixels, Point currentPoint, Color oldColor, Color newColor)
            {
                Color temp = canvas.GetPixel(currentPoint.X, currentPoint.Y);
                if (temp == oldColor)
                {
                    pixels.Push(currentPoint);
                    canvas.SetPixel(currentPoint.X, currentPoint.Y, newColor);
                }
            }
        }
    }
}
