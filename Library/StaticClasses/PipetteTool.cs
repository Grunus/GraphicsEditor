namespace Library.StaticClasses
{
    public static class PipetteTool
    {
        public static void Activate(Bitmap canvas)
        {
            Color selectedColor = canvas.GetPixel(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
            if (MouseTracker.PressedButton == MouseButtons.Left)
                AppManager.PrimaryColor = selectedColor;
            else if (MouseTracker.PressedButton == MouseButtons.Right)
                AppManager.SecondaryColor = selectedColor;
        }
    }
}
