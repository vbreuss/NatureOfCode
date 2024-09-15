using System.Windows.Media;

namespace NatureOfCode.Base.UI
{
    public class CanvasRectangle : CanvasItem
    {
        public CanvasRectangle(double x, double y, double width, double height, Brush? color = null, double opacity = 1.0) : base(x, y)
        {
            Width = width;
            Height = height;
            Color = color ?? new SolidColorBrush(Colors.Black);
            Opacity = opacity;
        }

        public double Width { get; }
        public double Height { get; }
        public double Opacity { get; }
        public Brush Color { get; }
    }
}
