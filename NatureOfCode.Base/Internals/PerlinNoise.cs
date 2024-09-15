using System.Windows.Controls;

namespace NatureOfCode.Base.Internals
{
    /// <summary>
    /// https://github.com/chriscourses/perlin-noise/blob/master/index.js
    /// </summary>
    internal class PerlinNoise
    {
        //////////////////////////////////////////////////////////////

        // http://mrl.nyu.edu/~perlin/noise/
        // Adapting from PApplet.java
        // which was adapted from toxi
        // which was adapted from the german demo group farbrausch
        // as used in their demo "art": http://www.farb-rausch.de/fr010src.zip

        // someday we might consider using "improved noise"
        // http://mrl.nyu.edu/~perlin/paper445.pdf
        // See: https://github.com/shiffman/The-Nature-of-Code-Examples-p5.js/
        //      blob/main/introduction/Noise1D/noise.js

        const int PERLIN_YWRAPB = 4;
        const int PERLIN_YWRAP = 1 << PERLIN_YWRAPB;
        const int PERLIN_ZWRAPB = 8;
        const int PERLIN_ZWRAP = 1 << PERLIN_ZWRAPB;
        const int PERLIN_SIZE = 4095;

        static double scaled_cosine(double i) => 0.5 * (1.0 - Math.Cos(i * Math.PI));

        const int perlin_octaves = 4; // default to medium smooth
        const double perlin_amp_falloff = 0.5; // 50% reduction/octave

        // will be initialized lazily by noise() or noiseSeed()
        static Lazy<double[]> _perlin = new Lazy<double[]>(InitializePerlin);

        private static double[] InitializePerlin()
        {
            var random = Random.Shared;
            var perlin = new double[PERLIN_SIZE + 1];
            for (var i = 0; i < PERLIN_SIZE + 1; i++)
            {
                perlin[i] = random.NextDouble();
            }
            return perlin;
        }

        public static void Reset()
        {
            _perlin = new Lazy<double[]>(InitializePerlin);
        }

        public static double Noise(double x, double y = 0.0, double z = 0.0)
        {
            var perlin = _perlin.Value;

            if (x < 0)
            {
                x = -x;
            }
            if (y < 0)
            {
                y = -y;
            }
            if (z < 0)
            {
                z = -z;
            }

            int xi = (int)x;
            int yi = (int)y;
            int zi = (int)z;
            var xf = x - xi;
            var yf = y - yi;
            var zf = z - zi;
            double rxf, ryf;

            double r = 0.0;
            var ampl = 0.5;

            double n1, n2, n3;

            for (var o = 0; o < perlin_octaves; o++)
            {
                var of = xi + (yi << PERLIN_YWRAPB) + (zi << PERLIN_ZWRAPB);

                rxf = scaled_cosine(xf);
                ryf = scaled_cosine(yf);

                n1 = perlin[of & PERLIN_SIZE];
                n1 += rxf * (perlin[(of + 1) & PERLIN_SIZE] - n1);
                n2 = perlin[(of + PERLIN_YWRAP) & PERLIN_SIZE];
                n2 += rxf * (perlin[(of + PERLIN_YWRAP + 1) & PERLIN_SIZE] - n2);
                n1 += ryf * (n2 - n1);

                of += PERLIN_ZWRAP;
                n2 = perlin[of & PERLIN_SIZE];
                n2 += rxf * (perlin[(of + 1) & PERLIN_SIZE] - n2);
                n3 = perlin[(of + PERLIN_YWRAP) & PERLIN_SIZE];
                n3 += rxf * (perlin[(of + PERLIN_YWRAP + 1) & PERLIN_SIZE] - n3);
                n2 += ryf * (n3 - n2);

                n1 += scaled_cosine(zf) * (n2 - n1);

                r += n1 * ampl;
                ampl *= perlin_amp_falloff;
                xi <<= 1;
                xf *= 2;
                yi <<= 1;
                yf *= 2;
                zi <<= 1;
                zf *= 2;

                if (xf >= 1.0)
                    {
                        xi++;
                  xf--;
                }
                if (yf >= 1.0)
                {
                    yi++;
                  yf--;
                }
                if (zf >= 1.0)
                {
                    zi++;
                  zf--;
                }
            }
            return r;
        } 
    }
}
