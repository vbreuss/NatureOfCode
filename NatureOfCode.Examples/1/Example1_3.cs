namespace NatureOfCode;

[Sketch(Description = "Example 1.3: Vector Subtraction")]
public class Example1_3 : Sketch
{
    public override void Draw()
    {
        Canvas.Reset();

        var mouse = GetMousePosition();
        var center = new Vector(Canvas.Width / 2.0, Canvas.Height / 2.0);

        Canvas.DrawLine(0, 0, mouse.X, mouse.Y, Colors.Gray, 4.0);
        Canvas.DrawLine(0, 0, center.X, center.Y, Colors.Gray, 4.0);

        var sub = mouse - center;

        Canvas.DrawLine(center.X, center.Y, sub.X, sub.Y, Colors.Black, 4.0);
    }
}
