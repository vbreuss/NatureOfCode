using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NatureOfCode.Base.UI
{
    public abstract class CanvasItem : ICanvasItem, INotifyPropertyChanged
    {
        public double X { get; }
        public double Y { get; }
        public CanvasItem(double x, double y)
        {
            X = x;
            Y = y;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
