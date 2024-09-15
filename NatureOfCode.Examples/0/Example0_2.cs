namespace NatureOfCode;

public class Example0_2 : Sketch
{
    public Example0_2()
        : base("Example 0.2: A Random-Number Distribution")
    {
        RandomCounts = new int[Total];
        for (int i = 0; i < Total; i++)
        {
            RandomCounts[i] = 0;
        }
    }

    const int Total = 20;
    // An array to keep track of how often random numbers are picked
    int[] RandomCounts;

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
