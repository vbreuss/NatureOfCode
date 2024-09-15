using System.Windows.Media;

namespace NatureOfCode.Base
{
    public class CanvasItem : ICanvasItem
    {
        public double X { get; }
        public double Y { get; }
        public CanvasItem(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
    public class CanvasPoint : CanvasItem
    {
        public CanvasPoint(double x, double y, double radius = 1.0, Brush? color = null) : base(x, y)
        {
            Radius = radius;
            Color = color ?? new SolidColorBrush(Colors.Black);
        }

        public double Radius { get; }
        public Brush Color { get; }
    }
}
