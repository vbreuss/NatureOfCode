namespace NatureOfCode.Base
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less than the specified <paramref name="maximum" />.
        /// </summary>
        public static double Next(this IRandom random, double maximum)
        {
            return random.Next() * maximum;
        }

        public static double Gaussian(this IRandom random, double mean, double standardDeviation)
        {
            var randStdNormal = random.Gaussian();
            double randNormal = mean + standardDeviation * randStdNormal; //random normal(mean,stdDev^2)
            return randNormal;
        }
    }
}
