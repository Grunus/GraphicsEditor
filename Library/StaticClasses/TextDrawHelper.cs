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
            TextArea.Width = (int)Math.Round(100 * AppManager.State.ZoomFactor);
            TextArea.Font = new Font(AppManager.State.FontForDrawingText.FontFamily, AppManager.State.FontForDrawingText.Size * AppManager.State.ZoomFactor, AppManager.State.FontForDrawingText.Style);
            TextArea.Location = new Point((int)Math.Round(MouseTracker.MouseDownPoint.X * AppManager.State.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppManager.State.ZoomFactor));
            PrevZoomFactor = AppManager.State.ZoomFactor;
            Target.Controls.Add(TextArea);
            TextArea.Focus();
        }

        public static void TextAreaDispose(CanvasView Target, Bitmap canvas) 
        {
            Graphics g = Graphics.FromImage(canvas);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            Font temp = new Font(TextArea.Font.FontFamily, AppManager.State.FontForDrawingText.Size, TextArea.Font.Style);
            g.DrawString(TextArea.Text, temp, new SolidBrush(AppManager.GetPrimaryColor()), new RectangleF(TextArea.Location.X / AppManager.State.ZoomFactor, TextArea.Location.Y / AppManager.State.ZoomFactor, TextArea.Width / AppManager.State.ZoomFactor, TextArea.Height / AppManager.State.ZoomFactor));
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
            TextArea.Size = new Size((int)Math.Round(TextArea.Width * AppManager.State.ZoomFactor / PrevZoomFactor), (int)Math.Round(TextArea.Height * AppManager.State.ZoomFactor / PrevZoomFactor));
            TextArea.Location = new Point((int)Math.Round(TextArea.Location.X * AppManager.State.ZoomFactor / PrevZoomFactor), (int)Math.Round(TextArea.Location.Y * AppManager.State.ZoomFactor / PrevZoomFactor));
            TextArea.Font = new Font(TextArea.Font.FontFamily, TextArea.Font.Size * AppManager.State.ZoomFactor / PrevZoomFactor, TextArea.Font.Style);
            PrevZoomFactor = AppManager.State.ZoomFactor;
        }

        public static void ApplyFont() => TextArea.Font = new Font(AppManager.State.FontForDrawingText.FontFamily, AppManager.State.FontForDrawingText.Size * AppManager.State.ZoomFactor, AppManager.State.FontForDrawingText.Style);
    }
}
