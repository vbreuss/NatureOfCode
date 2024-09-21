using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NatureOfCode.Base.UI
{
    public abstract class CanvasItem : ICanvasItem, INotifyPropertyChanged
    {
        public double Left { get; }
        public double Top { get; }
        public double Opacity { get; }
        public CanvasItem(double left, double top, double opacity = 1.0)
        {
            Left = left;
            Top = top;
            Opacity = opacity;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
