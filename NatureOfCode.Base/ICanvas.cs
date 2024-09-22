using NatureOfCode.Base.UI;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NatureOfCode.Base
{
    public interface ICanvas
    {
        double Width { get; }
        double Height { get; }
        Brush Background { get; }

        void Reset(Brush? color = null);

        void Animate();

        IDrawnElement<CanvasCircle> DrawCircle(double x, double y, double radius = 1.0, Brush? color = null, Brush? borderColor = null, double borderThickness = 0.0, double opacity = 1.0);
        IDrawnElement<CanvasRectangle> DrawRectangle(double x, double y, double width, double height, Brush? color = null, double opacity = 1.0);
        IDrawnElement<CanvasLine> DrawLine(double x, double y, double left, double top, Brush? color = null, double thickness = 1.0, double opacity = 1.0);
        IDrawnElement<CanvasBitmap> DrawBitmap(Action<WriteableBitmap> value);
    }
}