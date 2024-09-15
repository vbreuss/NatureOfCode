using System.Windows.Media;

namespace NatureOfCode.Base
{
    public interface ICanvas
    {
        double Width { get; }
        double Height { get; }
        Brush Background { get; }

        void Reset(Brush? color = null);

        void Point(double x, double y, double radius = 1.0, Brush? color = null);
        void Rect(double x, double y, double width, double height, Brush? color = null);
    }
}