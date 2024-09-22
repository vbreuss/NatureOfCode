using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using NatureOfCode.Base.Internals;

namespace NatureOfCode.Base
{
    public abstract class Sketch : INotifyPropertyChanged
    {
        private ICanvas? _canvas;
        private Control? _canvasControl;
        private string? _name;

        public ICanvas Canvas
        {
            get => _canvas ?? throw new Exception("The sketch is not yet initialized");
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

        public void Reset()
        {
            PerlinNoise.Reset();
            Canvas = new CanvasDrawer(640, 240, null);
        }

        public void Initialize(Control canvasControl)
        {
            if (_canvasControl == null)
            {
                _canvasControl = canvasControl;
                _canvas = new CanvasDrawer(640, 240, null);
            }
        }

        private Vector _previousMousePosition = new Vector(0.0, 0.0);
        public Vector GetMousePosition()
        {
            try
            {
                if (_canvasControl.IsMouseOver)
                {
                    var mousePosition = Mouse.GetPosition(_canvasControl);
                    _previousMousePosition = new Vector(mousePosition.X, mousePosition.Y);
                }
            }
            catch (Exception) { }
            return _previousMousePosition;
        }

        public virtual void Setup() { }

        public virtual void Draw() { }

        public override string ToString()
        {
            _name ??= GetName();
            return _name;
        }

        private string GetName()
        {
            string? name = null;
            var attributeType = typeof(SketchAttribute);

            if (Attribute.GetCustomAttribute(this.GetType(), attributeType) is SketchAttribute sketchAttribute)
            {
                name = sketchAttribute.Description;
            }
            return name ?? GetType().Name;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
