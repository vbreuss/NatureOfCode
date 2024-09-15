using System.Windows.Media.Media3D;

namespace NatureOfCode;

public class Example0_6 : Sketch
{
    public Example0_6()
        : base("Example 0.6: A Perlin Noise Walker")
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
        public double TX;
        public double TY;

        public Walker(ICanvas canvas, IRandom random)
        {
            Canvas = canvas;
            Random = random;
            TX = 0.0;
            TY = 10000.0;
        }

        public ICanvas Canvas { get; }
        public IRandom Random { get; }

        internal void Show()
        {
            Canvas.DrawCircle(X, Y, radius: 5);
        }

        internal void Step()
        {
            //{!2} x- and y-position mapped from noise
            X = Random.Noise(TX) * Canvas.Width;
            Y = Random.Noise(TY) * Canvas.Height;

            //{!2} Move forward through “time.”
            TX += 0.01;
            TY += 0.01;
        }
    }
}
