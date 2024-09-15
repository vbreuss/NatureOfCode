using System.Windows.Media;

namespace NatureOfCode.Base
{
    public interface ICanvas
    {
        double Width { get; }
        double Height { get; }
        Brush Background { get; }

        void Point(double x, double y, double radius = 1.0, Brush? color = null);
    }
}