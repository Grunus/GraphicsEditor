using Library.Enums;
using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public class AppState
    {
        public AppState() { }

        public Size DefaultCanvasSize { get; } = new Size(1000, 600);

        public bool GridEnabled { get; set; } = false;

        public ActionMode CurrentActionMode { get; set; } = ActionMode.ArbitraryDrawing;

        public float ZoomFactor { get; set; } = 1.0f;

        public Color[] Colors { get; } = [Color.Black, Color.Indigo];

        public Color SecondaryColor { get; set; } = Color.Indigo;

        public float ToolThickness { get; set; } = 1.0f;

        public PaintTool Tool { get; set; } = PaintTool.Pen;

        public OrdinaryShape Shape { get; set; }

        public ShapeDrawMode ShapeDrawMode { get; set; } = ShapeDrawMode.OnlyOutline;

        public ShapeFillMode ShapeFillMode { get; set; } = ShapeFillMode.Solid;

        public LinearGradientMode ShapeFillLinearGradientMode { get; set; } = LinearGradientMode.Vertical;

        public Font FontForDrawingText { get; set; } = SystemFonts.DefaultFont;
    }
}
