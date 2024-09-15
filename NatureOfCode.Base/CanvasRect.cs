using System.Windows.Media;

namespace NatureOfCode.Base
{
    public class CanvasRect : CanvasItem
    {
        public CanvasRect(double x, double y, double width, double height, Brush? color = null) : base(x, y)
        {
            Width = width;
            Height = height;
            Color = color ?? new SolidColorBrush(Colors.Black);
        }

        public double Width { get; }
        public double Height { get; }
        public Brush Color { get; }
    }
}
