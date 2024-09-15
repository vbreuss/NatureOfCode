using System.Windows.Media;

namespace NatureOfCode.Base.UI
{
    public class CanvasCircle : CanvasItem
    {
        public CanvasCircle(double x, double y, double radius = 1.0, Brush? color = null, double opacity = 1.0) : base(x, y)
        {
            Radius = radius;
            Color = color ?? new SolidColorBrush(Colors.Black);
            Opacity = opacity;
        }

        public double Radius { get; }
        public double Opacity { get; }
        public Brush Color { get; }
    }
}
