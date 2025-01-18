using Library.CustomControls;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class ResizeHelper
    {
        public static bool ResizeWithoutCropHappened { get; set; } = false;

        public static void Activate(CanvasView Target, ref Bitmap canvas, ref Graphics canvasGraphics)
        {
            using Bitmap temp = new Bitmap(canvas);
            canvas = new Bitmap((int)Math.Round(Target.Width / AppState.ZoomFactor), (int)Math.Round(Target.Height / AppState.ZoomFactor));
            canvasGraphics = Graphics.FromImage(canvas);
            canvasGraphics.Clear(Color.White);
            for (int i = 0; i < canvas.Width && i < temp.Width; i++)
            {
                for (int j = 0; j < canvas.Height && j < temp.Height; j++) 
                {
                    canvas.SetPixel(i, j, temp.GetPixel(i, j));
                }
            }
            Target.Image = canvas;
        }

        public static void Activate(CanvasView Target, ref Bitmap canvas, ref Graphics canvasGraphics, Size newSize)
        {
            ResizeWithoutCropHappened = true;
            using Bitmap temp = new Bitmap(canvas);
            canvas = new Bitmap(newSize.Width >= 16 ? newSize.Width : 16, newSize.Height >= 16 ? newSize.Height : 16);
            canvasGraphics = Graphics.FromImage(canvas);
            canvasGraphics.Clear(Color.White);
            canvasGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            canvasGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            canvasGraphics.CompositingQuality = CompositingQuality.HighQuality;
            canvasGraphics.DrawImage(temp, 0, 0, canvas.Width, canvas.Height);
            canvasGraphics.InterpolationMode = InterpolationMode.Default;
            Target.Image = canvas;
            Target.Size = new Size((int)Math.Round(newSize.Width * AppState.ZoomFactor), (int)Math.Round(newSize.Height * AppState.ZoomFactor));
        }
    }
}
