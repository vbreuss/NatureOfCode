namespace NatureOfCode;

[Sketch(Description = "Example 1.4: Multiplying a Vector")]
public class Example1_4 : Sketch
{
    public override void Draw()
    {
        Canvas.Reset();

        var mouse = GetMousePosition();
        var center = new Vector(Canvas.Width / 2.0, Canvas.Height / 2.0);
        var sub = mouse - center;

        Canvas.DrawLine(center.X, center.Y, sub.X, sub.Y, Colors.Gray, 2.0);

        sub.MultiplyWith(0.5);

        Canvas.DrawLine(center.X, center.Y, sub.X, sub.Y, Colors.Black, 8.0);
    }
}
