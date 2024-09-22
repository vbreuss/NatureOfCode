namespace NatureOfCode;

[Sketch(Description = "Example 1.7: Motion 101 (Velocity)")]
public class Example1_7 : Sketch
{
    private Mover mover;

    public override void Setup()
    {
        mover = new Mover(this);
    }

    public override void Draw()
    {
        Canvas.Reset();

        mover.Update();
        mover.CheckEdges();
        mover.Show();
    }
    private class Mover
    {
        private readonly Sketch _sketch;

        public Vector Position { get; private set; }
        public Vector Velocity { get; private set; }

        public Mover(Sketch sketch)
        {
            _sketch = sketch;
            Position = new Vector(_sketch.Random.Next(_sketch.Canvas.Width), _sketch.Random.Next(_sketch.Canvas.Height));
            Velocity = new Vector(_sketch.Random.Next(-2.0, 2.0), _sketch.Random.Next(-2.0, 2.0));
        }

        public void Update()
        {
            Position.Add(Velocity);
        }

        public void Show()
        {
            _sketch.Canvas.DrawCircle(Position.X, Position.Y, 24, Colors.Gray, Colors.Black, 2.0);
        }

        public void CheckEdges()
        {
            if (Position.X > _sketch.Canvas.Width)
            {
                Position.X = 0;
            }
            else if (Position.X < 0)
            {
                Position.X = _sketch.Canvas.Width;
            }

            if (Position.Y > _sketch.Canvas.Height)
            {
                Position.Y = 0;
            }
            else if (Position.Y < 0)
            {
                Position.Y = _sketch.Canvas.Height;
            }
        }
    }
}
