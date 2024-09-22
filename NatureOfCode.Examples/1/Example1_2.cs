namespace NatureOfCode;

[Sketch(Description = "Example 1.2: Bouncing Ball with Vectors!")]
public class Example1_2 : Sketch
{
    Vector Position = new Vector(100.0, 100.0);
    Vector Velocity = new Vector(2.5, 2.0);

    public override void Draw()
    {
        Position = Position + Velocity;
        if (Position.X > Canvas.Width || Position.X < 0)
        {
            Velocity.X = Velocity.X * -1.0;
        }
        if (Position.Y > Canvas.Height || Position.Y < 0)
        {
            Velocity.Y = Velocity.Y * -1.0;
        }

        Canvas.DrawCircle(Position.X, Position.Y, 24)
            .WithAnimation(Animation.FadeOut(1));
    }
}
