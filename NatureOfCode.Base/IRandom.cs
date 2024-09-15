namespace NatureOfCode.Base
{
    public interface IRandom
    {
        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
        /// </summary>
        public double Next();

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified <paramref name="maximum" />.
        /// </summary>
        public int NextInteger(int maximum);

        public double Gaussian();
    }
}
