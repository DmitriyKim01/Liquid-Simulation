using PaintDropSimulation;
using ShapeLibrary;
using System.Runtime.CompilerServices;

// Formula was taken from the folowing website: https://www.101computing.net/python-turtle-spirograph/
[assembly: InternalsVisibleTo("PatternGenerationLibTests")]
namespace PatternGenerationLib
{
    internal class Spirograph : IPatternGenerator
    {
        private const int R = 175;
        private const int r = 120;
        private const int d = 125;
        private float angle = 0;
        private float theta = 0.2f;
        private float steps;

        public Spirograph()
        {
            steps = 8 * (int)6 * 3.14f / theta;
        }

        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if (surface == null)
            {
                throw new ArgumentNullException(nameof(surface));
            }
            if (surface.Drops == null)
            {
                return null;
            }
            angle += theta;

            float x = (R - r) * (float)Math.Cos(angle) + d * (float)Math.Cos(((float)(R - r) / r) * angle);
            float y = (R - r) * (float)Math.Sin(angle) + d * (float)Math.Sin(((float)(R - r) / r) * angle);

            x += surface.Width / 2;
            y += surface.Height / 2;

            if (x < 0 || x > surface.Width || y < 0 || y > surface.Height)
            {
                return null;
            }
            return new Vector(x, y);
        }
    }
}
