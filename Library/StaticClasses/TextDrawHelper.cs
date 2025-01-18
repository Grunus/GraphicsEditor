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
            TextArea.Width = (int)Math.Round(100 * AppState.ZoomFactor);
            TextArea.Font = new Font(AppState.FontForDrawingText.FontFamily, AppState.FontForDrawingText.Size * AppState.ZoomFactor, AppState.FontForDrawingText.Style);
            TextArea.Location = new Point((int)Math.Round(MouseTracker.MouseDownPoint.X * AppState.ZoomFactor), (int)Math.Round(MouseTracker.MouseDownPoint.Y * AppState.ZoomFactor));
            PrevZoomFactor = AppState.ZoomFactor;
            Target.Controls.Add(TextArea);
            TextArea.Focus();
        }

        public static void TextAreaDispose(CanvasView Target, Bitmap canvas) 
        {
            Graphics g = Graphics.FromImage(canvas);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            Font temp = new Font(TextArea.Font.FontFamily, AppState.FontForDrawingText.Size, TextArea.Font.Style);
            g.DrawString(TextArea.Text, temp, new SolidBrush(AppState.PrimaryColor), new RectangleF(TextArea.Location.X / AppState.ZoomFactor, TextArea.Location.Y / AppState.ZoomFactor, TextArea.Width / AppState.ZoomFactor, TextArea.Height / AppState.ZoomFactor));
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
            TextArea.Size = new Size((int)Math.Round(TextArea.Width * AppState.ZoomFactor / PrevZoomFactor), (int)Math.Round(TextArea.Height * AppState.ZoomFactor / PrevZoomFactor));
            TextArea.Location = new Point((int)Math.Round(TextArea.Location.X * AppState.ZoomFactor / PrevZoomFactor), (int)Math.Round(TextArea.Location.Y * AppState.ZoomFactor / PrevZoomFactor));
            TextArea.Font = new Font(TextArea.Font.FontFamily, TextArea.Font.Size * AppState.ZoomFactor / PrevZoomFactor, TextArea.Font.Style);
            PrevZoomFactor = AppState.ZoomFactor;
        }

        public static void ApplyFont() => TextArea.Font = new Font(AppState.FontForDrawingText.FontFamily, AppState.FontForDrawingText.Size * AppState.ZoomFactor, AppState.FontForDrawingText.Style);
    }
}
