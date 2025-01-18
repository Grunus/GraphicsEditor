using System.Drawing.Drawing2D;

namespace Library.StaticClasses
{
    public static class PaintTools
    {
        public static Pen Pencil { get; }

        public static Pen Pen {  get; }

        static PaintTools()
        {
            Pencil = new Pen(Color.Black, 1)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round,
                DashCap = DashCap.Round,
                DashStyle = DashStyle.Solid,
            };

            Pen = new Pen(Color.Black, 1)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round,
                DashCap = DashCap.Round,
                DashStyle = DashStyle.Solid,
            };
        }
    }
}
