using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using NatureOfCode.Base;

namespace NatureOfCode.UI
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private Sketch? _sketch;
        private CancellationTokenSource? _sketchCancellation;
        private int delay = 50;

        public int Velocity
        {
            get => 202 - delay;
            set
            {
                if (value < 200 && value > 0)
                {
                    delay = 202 - value;
                }
            }
        }
        public Sketch? Sketch {
            get => _sketch;
            set
            {
                _sketch = value;
                OnPropertyChanged();
                if (value != null)
                {
                    _sketchCancellation?.Cancel();
                    _sketchCancellation = new CancellationTokenSource();
                    var token = _sketchCancellation.Token;
                    RunSketch(value, token);
                }
            }
        }

        public ObservableCollection<Sketch> Sketches { get; } = new ObservableCollection<Sketch>();

        private void RunSketch(Sketch sketch, CancellationToken cancellationToken)
        {
            _ = Task.Run(() => 
            {
                try
                {
                    _ = RunSketchAsync(sketch, cancellationToken);
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }
        private async Task RunSketchAsync(Sketch sketch, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    Application.Current?.Dispatcher.Invoke(sketch.Draw);
                }
                catch (Exception)
                {
                }
                await Task.Delay(delay);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        internal void Initialize()
        {
            Type sketchType = typeof(Sketch);
            foreach (Type type in typeof(Example0_1).Assembly.GetTypes()
                //.Select(a => a.GetTypes())
                .Where(x => x.IsClass && !x.IsAbstract)
                .Where(x => x.BaseType == sketchType))
            {
                try
                {
                    Sketch? sketch = (Sketch?)Activator.CreateInstance(type);
                    if (sketch != null)
                    {
                        Sketches.Add(sketch);
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"Could not instantiate sketch '{type.Name}'!", ex);
                }
            }
            Sketch = Sketches.FirstOrDefault();
        }
    }
}
