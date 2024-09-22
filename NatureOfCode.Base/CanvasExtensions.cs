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

        public static IDrawnElement<CanvasRectangle> DrawRectangle(this ICanvas canvas, double x, double y, double width, double height, Color? color = null, double opacity = 1.0)
        {
            return canvas.DrawRectangle(x, y, width, height,
                color == null ? null : new SolidColorBrush(color.Value),
                opacity);
        }

        public static IDrawnElement<CanvasLine> DrawLine(this ICanvas canvas, double x, double y, double left, double top, Color? color = null, double thickness = 1.0, double opacity = 1.0)
        {
            return canvas.DrawLine(x, y, left, top,
                color == null ? null : new SolidColorBrush(color.Value),
                thickness,
                opacity);
        }
    }
}
