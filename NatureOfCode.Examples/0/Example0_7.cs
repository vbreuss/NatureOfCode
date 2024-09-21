using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NatureOfCode;

[Sketch(Description = "Example 0.7: Noise 2D")]
public class Example0_7 : Sketch
{
    double ZOff = 0.0;

    public override void Setup()
    {
    }

    public override void Draw()
    {
        Canvas.DrawBitmap(bmp =>
        {
            var xoff = 0.0;

            // Updating pixels with perlin noise
            for (var x = 0; x < Canvas.Width; x++)
            {
                var yoff = 0.0;

                for (var y = 0; y < Canvas.Height; y++)
                {
                    // Calculating brightness value for noise
                    var bright = (byte)(Random.Noise(xoff, yoff, ZOff) * 255);
                    bmp.SetPixel(x, y, Color.FromRgb(bright, bright, bright));
                    yoff += 0.01; // Incrementing y-offset perlins noise
                }
                xoff += 0.01; // Incrementing x-offset perlins noise
            }
        });
        ZOff += 0.01;
    }
}
