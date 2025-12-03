using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public struct Vector
    {
        public float X { get; }
        public float Y { get; }
        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Vector (Vector v)
        {
            X = v.X;
            Y = v.Y;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1.X + vector2.X, vector2 .Y + vector1.Y);
            return result;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1.X - vector2.X, vector1.Y - vector2.Y);
            return result;
        }

        public static Vector operator *(Vector vector1, int scalar)
        {
            Vector result = new Vector(vector1.X * (float) scalar, vector1.Y * (float) scalar);
            return result;
        }

        public static Vector operator *(int scalar, Vector vector1)
        {
            return vector1 * scalar;
        }

        public static Vector operator *(Vector vector1, float scalar)
        {
            Vector result = new Vector(vector1.X * scalar, vector1.Y * scalar);
            return result;
        }

        public static Vector operator *(float scalar, Vector vector1)
        {
            return vector1 * scalar;
        }

        public static Vector operator /(Vector vector1, int scalar)
        {
            if (scalar == 0)
            {
                throw new DivideByZeroException("Cannot divide vector by 0!");
            }
            Vector result = new Vector(vector1.X / (float) scalar, vector1.Y / (float) scalar);
            return result;
        }

        public static Vector operator /(int scalar, Vector vector1)
        {
            return vector1 / scalar;
        }

        public static Vector operator /(Vector vector1, float scalar)
        {
            if (scalar == 0)
            {
                throw new DivideByZeroException("Cannot divide vector by 0!");
            }
            Vector result = new Vector(vector1.X / scalar, vector1.Y / scalar);
            return result;
        }

        public static float Magnitude(Vector vector)
        {
            double x = vector.X;
            double y = vector.Y;
            float magnitude = (float) Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return magnitude;
        }

        public static Vector Normalize(Vector vector)
        {
            float magnitude = Magnitude(vector);
            if (magnitude == 0)
            {
                return new Vector(0, 0);
            }
            return new Vector(vector.X / magnitude, vector.Y / magnitude);
        }

        public override string ToString()
        {
            return $"(X: {X}, Y: {Y})";
        }
    }
}
