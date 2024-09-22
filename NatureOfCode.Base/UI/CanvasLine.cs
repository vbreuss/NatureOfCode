using System.Windows.Media;

namespace NatureOfCode.Base.UI
{
    public class CanvasLine : CanvasItem
    {
        public CanvasLine(double x1, double y1, double x2, double y2, Brush? color = null, double thickness = 1.0, double opacity = 1.0) : base(x1, y1, opacity)
        {
            X2 = x2;
            Y2 = y2;
            Color = color ?? new SolidColorBrush(Colors.Black);
            Thickness = thickness;
        }

        public double X2 { get; }
        public double Y2 { get; }
        public Brush Color { get; }
        public double Thickness { get; }
    }
}
