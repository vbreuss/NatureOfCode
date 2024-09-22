
namespace NatureOfCode.Base
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double Magnitude => CalculateMagnitude(X, Y, Z);

        public Vector(double x, double y, double z = 0.0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Normalize()
        {
            DivideBy(Magnitude);
        }

        public void Add(Vector vector)
        {
            X += vector.X;
            Y += vector.Y;
            Z += vector.Z;
        }

        public void Subtract(Vector vector)
        {
            X -= vector.X;
            Y -= vector.Y;
            Z -= vector.Z;
        }

        public void MultiplyWith(double scalar)
        {
            X *= scalar;
            Y *= scalar;
            Z *= scalar;
        }

        public void DivideBy(double scalar)
        {
            X /= scalar;
            Y /= scalar;
            Z /= scalar;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
        }

        public static Vector operator /(Vector v, double scalar)
        {
            return new Vector(v.X / scalar, v.Y / scalar, v.Z / scalar);
        }

        private static double CalculateMagnitude(double x, double y, double z)
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}
