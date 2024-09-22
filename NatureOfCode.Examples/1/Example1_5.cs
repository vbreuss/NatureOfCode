namespace NatureOfCode;

[Sketch(Description = "Example 1.5: Vector Magnitude")]
public class Example1_5 : Sketch
{
    public override void Draw()
    {
        Canvas.Reset();

        var mouse = GetMousePosition();
        var center = new Vector(Canvas.Width / 2.0, Canvas.Height / 2.0);
        var sub = mouse - center;

        var m = sub.Magnitude;

        Canvas.DrawRectangle(10, 10, m, 10);

        Canvas.DrawLine(center.X, center.Y, sub.X, sub.Y);
    }
}
