namespace NatureOfCode;

[Sketch(Description = "Example 1.1: Bouncing Ball with No Vectors")]
public class Example1_1 : Sketch
{
    double X = 100.0;
    double Y = 100.0;
    double XSpeed = 2.5;
    double YSpeed = 2.0;

    public override void Draw()
    {
        Canvas.Reset();
        X = X + XSpeed;
        Y = Y + YSpeed;
        if (X > Canvas.Width || X < 0)
        {
            XSpeed = XSpeed * -1.0;
        }
        if (Y > Canvas.Height || Y < 0)
        {
            YSpeed = YSpeed * -1.0;
        }

        Canvas.DrawCircle(X, Y, 24);
    }
}
