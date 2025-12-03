using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PatternGenerationLibTests")]
namespace PatternGenerationLib
{
    internal class Phyllotaxis : IPatternGenerator
    {
        private const float SCALING_FACTOR = 15;
        private const float GOLDEN_ANGLE = (float)(Math.PI / 180) * 137.5f;
        private int _index = 0;
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
            float i = _index;
            float r = SCALING_FACTOR * (float)Math.Sqrt(i);
            float angle = i * GOLDEN_ANGLE;
            float x = surface.Width / 2 + r * (float)Math.Cos(angle);
            float y = surface.Height / 2 + r * (float)Math.Sin(angle);
            _index++;
            if (x < 0 || x > surface.Width || y < 0 || y > surface.Height)
            {
                return null;
            }
            return new Vector(x, y);
        }
    }
}
