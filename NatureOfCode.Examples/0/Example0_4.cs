namespace NatureOfCode;

[Sketch(Description = "Example 0.4: A Gaussian Distribution")]
public class Example0_4 : Sketch
{
    public override void Draw()
    {
        var y = Canvas.Height / 2.0;

        //{!1} A normal distribution with mean the half width of the canvas and standard deviation 60
        var x = Random.Gaussian(Canvas.Width / 2.0, 60);

        Canvas.DrawCircle(x, y, 16.0, opacity: 0.1);
    }
}
