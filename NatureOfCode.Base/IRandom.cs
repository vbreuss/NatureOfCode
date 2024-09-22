namespace NatureOfCode.Base
{
    public interface IRandom
    {
        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
        /// </summary>
        double Next();
        
        /// <summary>
        /// Returns a non-negative random integer that is less than the specified <paramref name="maximum" />.
        /// </summary>
        int NextInteger(int maximum);

        double Gaussian();

        /// <summary>
        ///     Returns the Perlin noise value at specified coordinates. Perlin noise is a random sequence generator producing a more naturally ordered, harmonic succession of numbers compared to the standard <see cref="IRandom.Next()" /> function.
        ///     It was invented by Ken Perlin in the 1980s and been used since in graphical applications to produce procedural textures, natural motion, shapes, terrains etc.
        ///     <para />
        ///     The main difference is that Perlin noise is defined in an infinite n-dimensional space where each pair of coordinates corresponds to a fixed semi-random value (fixed only for the lifespan of the program).
        ///     This method can compute 1D, 2D and 3D noise, depending on the number of coordinates given. The resulting value will always be between 0.0 and 1.0. The noise value can be animated by moving through the noise space. The 2nd and 3rd dimension can also be interpreted as time.
        ///     <para />
        ///     The actual noise is structured similar to an audio signal, in respect to the function's use of frequencies. Similar to the concept of harmonics in physics, perlin noise is computed over several octaves which are added together for the final result.
        ///     <para />
        ///     Another way to adjust the character of the resulting sequence is the scale of the input coordinates. As the function works within an infinite space the value of the coordinates doesn't matter as such, only the distance between successive coordinates does (eg.when using <see cref="Noise" /> within a loop).<br />
        ///     As a general rule the smaller the difference between coordinates, the smoother the resulting noise sequence will be. Steps of <c>0.005</c> - <c>0.03</c> work best for most applications, but this will differ depending on use.
        /// </summary>
        double Noise(double x, double y = 0.0, double z = 0.0);
    }
}
