using Library.Enums;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class AppManager
    {
        public static Size DefaultCanvasSize { get; } = new Size(1000, 600);

        public static bool GridEnabled { get; set; } = false;

        public static ActionMode CurrentActionMode { get; set; } = ActionMode.ArbitraryDrawing;

        public static float ZoomFactor { get; set; } = 1.0f;

        public static Color PrimaryColor { get; set; } = Color.Black;

        public static Color SecondaryColor { get; set; } = Color.Indigo;

        public static float ToolThickness { get; set; } = 1.0f;

        public static Pen SelectedTool { get; set; } = PaintTools.Pencil;

        public static OrdinaryShape SelectedShape { get; set; }

        public static ShapeDrawMode SelectedShapeDrawMode { get; set; } = ShapeDrawMode.OnlyOutline;

        public static ShapeFillMode SelectedShapeFillMode { get; set; } = ShapeFillMode.Solid;

        public static LinearGradientMode SelectedShapeFillLinearGradientMode { get; set; } = LinearGradientMode.Vertical;

        public static Font FontForDrawingText { get; set; } = SystemFonts.DefaultFont;
    }
}
