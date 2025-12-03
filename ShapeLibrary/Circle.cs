using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace ShapeLibrary
{
    internal class Circle : ICircle
    {
        public float Radius { get; }
        public Vector Center { get; }
        public Colour Colour { get; set; }
        public const int NUM_OF_VERTICIES = 50;
        private Vector[] _verticies;
        public Vector[] Vertices
        {
            get
            {
                if (_verticies == null)
                {
                    _verticies = GenerateCircleVerticies();
                }

                return _verticies;
            }
        }
        public Circle(float x, float y, float radius, Colour colour)
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius));
            }
            Radius = radius;
            Center = new Vector(x, y);
            Colour = colour;

        }

        private Vector[] GenerateCircleVerticies()
        {
            Vector[] vertArray = new Vector[NUM_OF_VERTICIES];
            float angle = (float)(2 * Math.PI / NUM_OF_VERTICIES);
            for (int i = 0; i < NUM_OF_VERTICIES; i++)
            {
                float vertAngle = i * angle;
                float vertX = (float)(Center.X + Radius * Math.Cos(vertAngle));
                float vertY = (float)(Center.Y + Radius * Math.Sin(vertAngle));
                vertArray[i] = new Vector(vertX, vertY);
            }
            return vertArray;
        }
    }
}
