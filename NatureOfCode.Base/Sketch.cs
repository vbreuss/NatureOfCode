using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using NatureOfCode.Base.Internals;

namespace NatureOfCode.Base
{
    public abstract class Sketch : INotifyPropertyChanged
    {
        protected Sketch()
        {
            _canvas = new CanvasDrawer(640, 240, null);
        }

        protected Sketch(string name) : this()
        {
            _name = name;
        }

        private ICanvas _canvas;
        private string? _name;

        public ICanvas Canvas
        {
            get => _canvas;
            private set
            {
                _canvas = value;
                OnPropertyChanged();
            }
        }

        public IRandom Random { get; } = new RandomProvider();

        public void CreateCanvas(int width, int height, Brush? background = null)
        {
            Canvas = new CanvasDrawer(width, height, background);
        }

        public abstract void Draw();

        public override string ToString()
        {
            return _name ?? GetType().Name;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
