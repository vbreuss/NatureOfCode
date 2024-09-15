using System.Windows.Media;

namespace NatureOfCode.Base
{
    public static class CanvasExtensions
    {
        public static void Circle(this ICanvas canvas, double x, double y, double radius = 1.0, Color? color = null, double opacity = 1.0)
        {
            canvas.Circle(x, y, radius, color == null ? null : new SolidColorBrush(color.Value), opacity);
        }
    }
}
