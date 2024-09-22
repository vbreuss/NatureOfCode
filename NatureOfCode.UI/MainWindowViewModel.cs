using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using NatureOfCode.Base;

namespace NatureOfCode.UI
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private Sketch? _sketch;
        private CancellationTokenSource? _sketchCancellation;
        private int delay = 20;

        public ICommand RefreshCommand { get; }

        public MainWindowViewModel()
        {
            RefreshCommand = new DelegateCommand(_ =>
            {
                var sketch = Sketch;
                if (sketch != null)
                {
                    RunSketch(sketch, true);
                }
            });
        }

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
                    RunSketch(value);
                }
            }
        }

        public ObservableCollection<Sketch> Sketches { get; } = new ObservableCollection<Sketch>();

        private void RunSketch(Sketch sketch, bool reset = false)
        {
            _sketchCancellation?.Cancel();
            _sketchCancellation = new CancellationTokenSource();
            var cancellationToken = _sketchCancellation.Token;
            if (reset)
            {
                sketch.Reset();
            }
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
            Application.Current?.Dispatcher.Invoke(sketch.Setup);
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    Application.Current?.Dispatcher.Invoke(sketch.Draw);
                    Application.Current?.Dispatcher.Invoke(sketch.Canvas.Animate);
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
            Sketch = Sketches.LastOrDefault();
        }

        private class DelegateCommand : ICommand
        {
            private readonly Action<object?> _execute;

            public DelegateCommand(Action<object?> execute)
            {
                _execute = execute;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public void Execute(object? parameter)
            {
                _execute.Invoke(parameter);
            }
        }
    }
}
