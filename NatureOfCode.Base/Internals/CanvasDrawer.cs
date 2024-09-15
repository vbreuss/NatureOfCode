using NatureOfCode.Base.UI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace NatureOfCode.Base.Internals
{
    internal class CanvasDrawer : ICanvas, INotifyPropertyChanged
    {
        private double _width;
        private double _height;
        private Brush _background;

        public CanvasDrawer(double width, double height, Brush? background)
        {
            _width = width;
            _height = height;
            _background = background ?? new SolidColorBrush(Colors.White);
        }

        public double Width
        {
            get => _width;
            private set
            {
                _width = value;
                OnPropertyChanged();
            }
        }
        public double Height
        {
            get => _height;
            private set
            {
                _height = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ICanvasItem> ItemsToDraw { get; } = new ObservableCollection<ICanvasItem>();

        public Brush Background
        {
            get => _background;
            private set
            {
                _background = value;
                OnPropertyChanged();
            }
        }

        public void Circle(double x, double y, double radius = 1.0, Brush? color = null, double opacity = 1.0)
        {
            ItemsToDraw.Add(new CanvasCircle(x, y, radius, color, opacity));
        }

        public void Rectangle(double x, double y, double width, double height, Brush? color = null, double opacity = 1.0)
        {
            ItemsToDraw.Add(new CanvasRectangle(x, y, width, height, color, opacity));
        }

        public void Reset(Brush? color = null)
        {
            ItemsToDraw.Clear();
            if (color != null)
            {
                Background = color;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
