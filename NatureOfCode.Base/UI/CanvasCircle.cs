using System.Security.Permissions;
using System.Windows.Media;

namespace NatureOfCode.Base.UI
{
    public class CanvasCircle : CanvasItem
    {
        private Brush _color;
        private Brush _borderColor;
        private double _borderThickness;

        public CanvasCircle(double x, double y, double radius = 1.0, Brush? color = null, Brush? borderColor = null, double borderThickness = 0.0, double opacity = 1.0) : base(x - radius, y - radius, opacity)
        {
            X = x;
            Y = y;
            Radius = radius;
            FillColor = color ?? new SolidColorBrush(Colors.Black);
            BorderColor = borderColor ?? new SolidColorBrush(Colors.Transparent);
            BorderThickness = borderThickness;
        }

        public double X { get; }
        public double Y { get; }
        public double Radius { get; }
        public double Diameter => Radius * 2.0;
        public Brush FillColor 
        {
            get => _color;
            set {
                _color = value;
                OnPropertyChanged();
            } 
        }
        public Brush BorderColor
        {
            get => _borderColor;
            set { 
                _borderColor = value;
                OnPropertyChanged();
            }
        }
        public double BorderThickness
        {
            get => _borderThickness;
            set { 
                _borderThickness = value;
                OnPropertyChanged();
            }
        }
    }
}
