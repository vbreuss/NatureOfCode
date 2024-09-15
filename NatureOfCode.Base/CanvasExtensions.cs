using System.Windows.Media;

namespace NatureOfCode.Base
{
    public static class CanvasExtensions
    {
        public static void Point(this ICanvas canvas, double x, double y, double radius = 1.0, Color? color = null)
        {
            canvas.Point(x, y, radius, color == null ? null : new SolidColorBrush(color.Value));
        }
    }
}
