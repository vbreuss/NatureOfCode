namespace NatureOfCode.Base.Internals
{
    internal class RandomProvider : IRandom
    {
        private Random _random = new Random();

        public double Gaussian()
        {
            double u1 = 1.0 - _random.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - _random.NextDouble();
            return Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        }

        public double Gaussian(double mean, double standardDeviation)
        {
            double u1 = 1.0 - _random.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - _random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal =
                         mean + standardDeviation * randStdNormal; //random normal(mean,stdDev^2)
            return randNormal;
        }

        public double Next()
        {
            return _random.NextDouble();
        }

        public double Next(double max)
        {
            return Next() * max;
        }

        public int NextInteger(int max)
        {
            return _random.Next(max);
        }

        public double Noise(double x, double y = 0.0, double z = 0.0)
        {
            return PerlinNoise.Noise(x, y, z);
        }
    }
}
