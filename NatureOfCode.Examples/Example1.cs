using NatureOfCode.Base;

namespace NatureOfCode
{
    public class Example1 : Sketch
    {
        Walker _walker;

        public Example1()
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
                Canvas.Point(X, Y);
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
