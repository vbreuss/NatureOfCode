using NatureOfCode.Base.UI;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        public IDrawnElement<CanvasCircle> DrawCircle(double x, double y, double radius = 1.0, Brush? color = null, Brush? borderColor = null, double borderThickness = 0.0, double opacity = 1.0)
        {
            var returnValue = new DrawnElement<CanvasCircle>(this, new CanvasCircle(x, y, radius, color, borderColor, borderThickness, opacity));
            ItemsToDraw.Add(returnValue.Item);
            return returnValue;
        }

        public IDrawnElement<CanvasRectangle> DrawRectangle(double x, double y, double width, double height, Brush? color = null, double opacity = 1.0)
        {
            var returnValue = new DrawnElement<CanvasRectangle>(this, new CanvasRectangle(x, y, width, height, color, opacity));
            ItemsToDraw.Add(returnValue.Item);
            return returnValue;
        }

        public IDrawnElement<CanvasBitmap> DrawBitmap(Action<WriteableBitmap> value)
        {
            WriteableBitmap writeableBmp = BitmapFactory.New((int)Width, (int)Height);
            using (writeableBmp.GetBitmapContext())
            {
                value?.Invoke(writeableBmp);
            }
            var loadedBitmap = _loadedBitmap;
            var returnValue = new DrawnElement<CanvasBitmap>(this, new CanvasBitmap(writeableBmp));
            _loadedBitmap = returnValue.Item;
            ItemsToDraw.Add(_loadedBitmap);
            if (loadedBitmap != null)
            {
                ItemsToDraw.Remove(loadedBitmap);
            }
            return returnValue;
        }
        private CanvasBitmap? _loadedBitmap;

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

        internal void StartAnimation<TItem>(DrawnElement<TItem> element, IAnimation<TItem> animation) where TItem : CanvasItem
        {
            Func<CanvasItem, AnimationResult> func = e => animation.Animate((TItem)e);
            _animations.AddOrUpdate(element.Item, _ => func, (_,_) => func);
        }

        private ConcurrentDictionary<CanvasItem, Func<CanvasItem, AnimationResult>> _animations = new();

        public void Animate()
        {
            foreach (var animation in _animations)
            {
                var result = animation.Value.Invoke(animation.Key);
                switch (result)
                {
                    case AnimationResult.StopAnimation:
                    {
                        _animations.TryRemove(animation.Key, out _);
                            break;
                        }
                    case AnimationResult.StopAnimationAndRemoveItem:
                        {
                            _animations.TryRemove(animation.Key, out _);
                            ItemsToDraw.Remove(animation.Key);
                            break;
                        }
                }
            }
        }
    }
}
