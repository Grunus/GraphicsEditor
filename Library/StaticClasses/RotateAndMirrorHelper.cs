namespace Library.StaticClasses
{
    public static class RotateAndMirrorHelper
    {
        public static bool RotateHappened { get; set; }

        public static void Rotate(PictureBox Target, ref Bitmap canvas, float degrees)
        {
            RotateHappened = true;
            if (degrees == -90)
            {
                canvas.RotateFlip(RotateFlipType.Rotate90FlipXY);
                Target.Size = new Size(Target.Height, Target.Width);
            }
            else if (degrees == 90)
            {
                canvas.RotateFlip(RotateFlipType.Rotate90FlipNone);
                Target.Size = new Size(Target.Height, Target.Width);
            }
            else if (degrees == 180)
                canvas.RotateFlip(RotateFlipType.Rotate180FlipNone);
            Target.Image = canvas;
        }

        public static void Mirror(PictureBox Target, ref Bitmap canvas, bool horizontally)
        {
            if (horizontally)
                canvas.RotateFlip(RotateFlipType.RotateNoneFlipX);
            else
                canvas.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Target.Image = canvas;
        }
    }
}
