namespace NatureOfCode;

public class Example0_1 : Sketch
{
    public Example0_1()
        : base("Example 0.1: A Traditional Random Walk")
    {
        _walker = new Walker(Canvas, Random);
    }

    Walker _walker;

    public override void Draw()
    {
        _walker.Step();
        _walker.Show();
    }

    class Walker
    {
        public double X;
        public double Y;

        public Walker(ICanvas canvas, IRandom random)
        {
            Canvas = canvas;
            Random = random;
            X = canvas.Width / 2.0;
            Y = canvas.Height / 2.0;
        }

        public ICanvas Canvas { get; }
        public IRandom Random { get; }

        internal void Show()
        {
            Canvas.Circle(X, Y);
        }

        internal void Step()
        {
            var choice = Random.NextInteger(4);
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
