namespace NatureOfCode;

public class Example0_5 : Sketch
{
    public Example0_5()
        : base("Example 0.5: An Accept-Reject Distribution")
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
        // Pick a random number and increase the count
        var index = (int)(AcceptReject() * RandomCounts.Length);
        RandomCounts[index]++;

        // Draw a rectangle to graph results
        Canvas.Reset();
        var w = Canvas.Width / RandomCounts.Length;
        for (int i = 0; i < Total; i++)
        {
            Canvas.Rectangle(i * w, Canvas.Height - RandomCounts[i], w - 1, RandomCounts[i]);
        }
    }

    // An algorithm for picking a random number based on monte carlo method
    // Here probability is determined by formula y = x
    double AcceptReject()
    {
        // We do this “forever” until we find a qualifying random value.
        while (true)
        {
            // Pick a random value.
            var r1 = Random.Next(1);
            // Assign a probability.
            var probability = r1;
            // Pick a second random value.
            var r2 = Random.Next(1);

            //{!3} Does it qualify?  If so, we’re done!
            if (r2 < probability)
            {
                return r1;
            }
        }
    }
}
