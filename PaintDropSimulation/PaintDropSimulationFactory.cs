using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulation
{
    public static class PaintDropSimulationFactory
    {
        public static IPaintDrop CreatePaintDrop(ICircle circle)
        {
            return new PaintDrop(circle);
        }
        public static ISurface CreateSurface(int width, int height)
        {
            return new Surface(width, height);
        }
    }
}
