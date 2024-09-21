using System.Security.Permissions;
using System.Windows.Media;

namespace NatureOfCode.Base.UI
{
    public class CanvasCircle : CanvasItem
    {
        public CanvasCircle(double x, double y, double radius = 1.0, Brush? color = null, double opacity = 1.0) : base(x - radius, y - radius, opacity)
        {
            X = x;
            Y = y;
            Radius = radius;
            Color = color ?? new SolidColorBrush(Colors.Black);
        }

        public double X { get; }
        public double Y { get; }
        public double Radius { get; }
        public double Diameter => Radius * 2.0;
        public Brush Color { get; }
    }
}
