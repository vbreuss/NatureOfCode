namespace NatureOfCode;

[Sketch(Description = "Example 0.1: A Traditional Random Walk")]
public class Example0_1 : Sketch
{
    Walker _walker = null!;

    public override void Setup()
    {
        // Creating the Walker object!
        _walker = new Walker(Canvas, Random);
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
            Canvas.DrawCircle(X, Y);
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
