using Library.CustomControls;
using System.Drawing.Text;

namespace Library.StaticClasses
{
    public static class TextDrawHelper
    {
        public static bool IsActive { get; set; } = false;

        public static TextArea TextArea { get; set; }

        private static float PrevZoomFactor { get; set; }

        public static void CreateTextArea(CanvasView Target)
        {
            IsActive = true;
            TextArea = new TextArea();
            TextArea.Width = (int)Math.Round(100 * AppManager.ZoomFactor);
            TextArea.Font = new Font(AppManager.FontForDrawingText.FontFamily, AppManager.FontForDrawingText.Size * AppManager.ZoomFactor, AppManager.FontForDrawingText.Style);
            TextArea.Location = new Point((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.ZoomFactor));
            PrevZoomFactor = AppManager.ZoomFactor;
            Target.Controls.Add(TextArea);
            TextArea.Focus();
        }

        public static void TextAreaDispose(CanvasView Target, Bitmap canvas) 
        {
            Graphics g = Graphics.FromImage(canvas);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            Font temp = new Font(TextArea.Font.FontFamily, AppManager.FontForDrawingText.Size, TextArea.Font.Style);
            g.DrawString(TextArea.Text, temp, new SolidBrush(AppManager.PrimaryColor), new RectangleF(TextArea.Location.X / AppManager.ZoomFactor, TextArea.Location.Y / AppManager.ZoomFactor, TextArea.Width / AppManager.ZoomFactor, TextArea.Height / AppManager.ZoomFactor));
            Target.Controls.Remove(TextArea);
            TextArea.Dispose();
        }

        public static void TextAreaDisposeWithoutDrawing(CanvasView Target)
        {
            Target.Controls.Remove(TextArea);
            TextArea.Dispose();
        }

        public static void AdjustTextArea()
        {
            TextArea.Size = new Size((int)Math.Round(TextArea.Width * AppManager.ZoomFactor / PrevZoomFactor), (int)Math.Round(TextArea.Height * AppManager.ZoomFactor / PrevZoomFactor));
            TextArea.Location = new Point((int)Math.Round(TextArea.Location.X * AppManager.ZoomFactor / PrevZoomFactor), (int)Math.Round(TextArea.Location.Y * AppManager.ZoomFactor / PrevZoomFactor));
            TextArea.Font = new Font(TextArea.Font.FontFamily, TextArea.Font.Size * AppManager.ZoomFactor / PrevZoomFactor, TextArea.Font.Style);
            PrevZoomFactor = AppManager.ZoomFactor;
        }

        public static void ApplyFont() => TextArea.Font = new Font(AppManager.FontForDrawingText.FontFamily, AppManager.FontForDrawingText.Size * AppManager.ZoomFactor, AppManager.FontForDrawingText.Style);
    }
}
