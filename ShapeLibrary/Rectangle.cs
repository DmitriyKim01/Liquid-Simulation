using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace ShapeLibrary
{
    internal class Rectangle : IRectangle
    {
        public float X { get; }
        public float Y { get; }
        public float Width { get; }
        public float Height { get; }
        public Colour Colour { get; set; }
        private Vector[] _verticies;
        public Vector[] Vertices
        {
            get
            {
                if (_verticies == null)
                {
                    _verticies = GenerateRectangleVerticies();
                }

                return _verticies;
            }
        }

        public Rectangle(float x, float y, float width, float height, Colour colour)
        {
            X = x;
            Y = y;

            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }
            Width = width;
            Height = height;
            Colour = colour;
        }

        public bool Intersect(IRectangle other)
        {
            bool isIntersecting = X < other.X + other.Width &&
                                  Y < other.Y + other.Height &&
                                  other.X < X + Width &&
                                  other.Y < Y + Height;
            return isIntersecting;
        }

        private Vector[] GenerateRectangleVerticies()
        {
            Vector[] vectors = new Vector[4];
            vectors[0] = new Vector(X, Y);
            vectors[1] = new Vector(X + Width, Y);
            vectors[2] = new Vector(X + Width, Y + Height);
            vectors[3] = new Vector(X, Y + Height);
            return vectors;
        }
    }
}
