using NatureOfCode.Base;
using System.Windows.Media;

namespace NatureOfCode
{
    public class Example2 : Sketch
    {
        Walker _walker;

        public Example2()
        {
            _walker = new Walker(Canvas);
        }

        public override void Draw()
        {
            _walker.Step();
            _walker.Show();
        }

        class Walker
        {
            public double X;
            public double Y;

            public Walker(ICanvas canvas)
            {
                Canvas = canvas;
                X = canvas.Width / 2.0;
                Y = canvas.Height / 2.0;
            }

            public ICanvas Canvas { get; }

            internal void Show()
            {
                Canvas.Point(X, Y, 5, new SolidColorBrush(Colors.Turquoise));
            }

            internal void Step()
            {
                var choice = new Random().Next(4);
                if (choice == 0)
                {
                    X++;
                }
                else if (choice == 1)
                {
                    X--;
                }
                else if (choice == 2)
                {
                    Y++;
                }
                else
                {
                    Y--;
                }
            }
        }
    }
}
