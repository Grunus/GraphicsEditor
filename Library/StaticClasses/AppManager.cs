using Library.Enums;
using Library.Miscellaneous;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class AppManager
    {
        static AppManager()
        {
            Pen toolBase = new Pen(Color.Black, 1)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round,
                DashCap = DashCap.Round,
                DashStyle = DashStyle.Solid,
            };
            PaintTools.Add(PaintTool.Eraser, ((Pen)toolBase.Clone()).With(p => p.Color = Color.White));
            PaintTools.Add(PaintTool.Pen, toolBase);
            PaintTools.Add(PaintTool.Pencil, toolBase); 
        }

        public static AppState State { get; } = new AppState();

        private static Dictionary<PaintTool, Pen> PaintTools { get; } = [];

        public static Color GetPrimaryColor()
        {
            if (MouseTracker.PressedButton == MouseButtons.Left)
                return State.Colors[0];
            else
                return State.Colors[1];
        }

        public static Color GetSecondaryColor()
        {
            if (MouseTracker.PressedButton == MouseButtons.Left)
                return State.Colors[1];
            else
                return State.Colors[0];
        }

        public static Pen GetSelectedTool() => ((Pen)PaintTools[State.Tool].Clone()).With(t => t.Width = State.ToolThickness);

        public static Pen GetSpecificTool(PaintTool tool) => ((Pen)PaintTools[tool].Clone()).With(t => t.Width = State.ToolThickness);

        public static void ChangeSelectedColor(Bitmap canvas)
        {
            Color selectedColor = canvas.GetPixel(MouseTracker.MouseDownPoint.X, MouseTracker.MouseDownPoint.Y);
            if (MouseTracker.PressedButton == MouseButtons.Left)
                State.Colors[0] = selectedColor;
            else if (MouseTracker.PressedButton == MouseButtons.Right)
                State.Colors[1] = selectedColor;
        }

        public static Graphics ConfigureGraphics(Graphics graphics)
        {
            if (State.Tool == PaintTool.Pen)
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

            return graphics;
        }
    }
}
