using NatureOfCode.Base.UI;
using System.Windows.Media;

namespace NatureOfCode.Base
{
    public static class CanvasExtensions
    {
        public static IDrawnElement<CanvasCircle> DrawCircle(this ICanvas canvas, double x, double y, double radius = 1.0, Color? color = null, Color? borderColor = null, double borderThickness = 0.0, double opacity = 1.0)
        {
            return canvas.DrawCircle(x, y, radius,
                color == null ? null : new SolidColorBrush(color.Value),
                borderColor == null ? null : new SolidColorBrush(borderColor.Value),
                borderThickness, opacity);
        }
    }
}
