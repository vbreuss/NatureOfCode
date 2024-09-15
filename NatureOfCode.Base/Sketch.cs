using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace NatureOfCode.Base
{

    public abstract class Sketch : INotifyPropertyChanged
    {
        protected Sketch()
        {
            _canvas = new CanvasDrawer(640, 240, null);
        }

        private ICanvas _canvas;

        public ICanvas Canvas
        {
            get => _canvas;
            private set
            {
                _canvas = value;
                OnPropertyChanged();
            }
        }

        public void CreateCanvas(int width, int height, Brush? background = null)
        {
            Canvas = new CanvasDrawer(width, height, background);
        }

        public abstract void Draw();

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
