namespace NatureOfCode;

[Sketch(Description = "Example 0.2: A Random-Number Distribution")]
public class Example0_2 : Sketch
{
    const int Total = 20;
    // An array to keep track of how often random numbers are picked
    int[] RandomCounts = new int[Total];

    public override void Setup()
    {
        for (int i = 0; i < Total; i++)
        {
            RandomCounts[i] = 0;
        }
    }

    public override void Draw()
    {
        var index = Random.NextInteger(RandomCounts.Length);
        RandomCounts[index]++;

        // Draw a rectangle to graph results
        Canvas.Reset();
        var w = Canvas.Width / RandomCounts.Length;

        for (int i = 0; i < Total; i++)
        {
            Canvas.DrawRectangle(i * w, Canvas.Height - RandomCounts[i], w - 1, RandomCounts[i]);
        }
    }
}
