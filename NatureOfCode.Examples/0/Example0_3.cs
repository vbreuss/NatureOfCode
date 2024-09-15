namespace NatureOfCode;

public class Example0_3 : Sketch
{
    public Example0_3()
        : base("Example 0.3: A Walker That Tends to Move to the Right")
    {
        _walker = new Walker(Canvas);
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
            var choice = new Random().NextDouble();
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
