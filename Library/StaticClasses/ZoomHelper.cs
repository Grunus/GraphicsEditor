using Library.CustomControls;

namespace Library.StaticClasses
{
    public static class ZoomHelper
    {
        public static bool ZoomHappened { get; set; } = false;

        public static void Activate(CanvasView Target)
        {
            ZoomHappened = true;
            Target.Size = new Size((int)Math.Round(Target.Image.Width * AppManager.State.ZoomFactor), (int)Math.Round(Target.Image.Height * AppManager.State.ZoomFactor));
        }
    }
}
