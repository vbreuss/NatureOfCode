namespace NatureOfCode;

public class Example0_3 : Sketch
{
    public Example0_3()
        : base("Example 0.3: A Walker That Tends to Move to the Right")
    {
        // Creating the Walker object!
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
            var choice = Random.Next();
            // A 40% of moving to the right!
            if (choice < 0.4)
            {
                X++;
            }
            else if (choice < 0.6)
            {
                X--;
            }
            else if (choice < 0.8)
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
