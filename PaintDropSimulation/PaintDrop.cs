using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("PaintDropSimulationTests")]
namespace PaintDropSimulation
{
    internal class PaintDrop : IPaintDrop
    {
        public ICircle Circle { get; }
        public IRectangle BoundingBox { get; private set; }
        public PaintDrop(ICircle circle)
        {
            if (circle == null)
            {
                throw new ArgumentNullException(nameof(circle));
            }

            Circle = circle;
            float minX = circle.Center.X - circle.Radius;
            float minY = circle.Center.Y - circle.Radius;
            float width = circle.Center.X + circle.Radius - minX;
            float height = circle.Center.Y + circle.Radius - minY;
            BoundingBox = ShapesFactory.CreateRectangle(minX, minY, width, height, new Colour(255, 0, 0));
        }
        public void Marble(IPaintDrop other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            Vector center = other.Circle.Center;
            float radius = other.Circle.Radius;
            float dividend = (float)Math.Pow(radius, 2);
            for (int i = 0; i < Circle.Vertices.Length; i++)
            {
                Vector distance = Circle.Vertices[i] - center;
                Debug.Assert(Vector.Magnitude(distance) != 0);
                float divisor = (float)Math.Pow(Vector.Magnitude(distance), 2);
                Circle.Vertices[i] = center + (distance) * (float)Math.Sqrt(1 + (dividend / divisor));
            }

            ResizeBoundingBox();
        }

        private void ResizeBoundingBox()
        {
            float minX = Circle.Vertices.Min(v => v.X);
            float minY = Circle.Vertices.Min(v => v.Y);
            float maxX = Circle.Vertices.Max(v => v.X);
            float maxY = Circle.Vertices.Max(v => v.Y);
            BoundingBox = ShapesFactory.CreateRectangle(minX, minY, maxX - minX, maxY - minY, BoundingBox.Colour);
        }
    }
}
