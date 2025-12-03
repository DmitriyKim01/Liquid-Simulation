using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulation
{
    public delegate Vector? CalculatePatternPoint(ISurface surface);
    public delegate void AddPaintDrop(IPaintDrop drop);
    public interface ISurface
    {
        /// <summary>
        /// Width of the surface
        /// </summary>
        int Width { get; }
        /// <summary>
        /// Height of the surface
        /// </summary>
        int Height { get; }

        /// <summary>
        /// The paint drops in the surface
        /// </summary>
        List<IPaintDrop> Drops { get; }

        event CalculatePatternPoint PatternGeneration;
        event AddPaintDrop AddPaintDropEvent;
        void GeneratePaintDropPattern(float radius, Colour colour);

        /// <summary>
        /// Adds a new paint drop to the surface and performs the marbling of all the paint drops
        /// </summary>
        /// <param name="drop">The new drop to be added to the surface</param>
        void AddPaintDrop(IPaintDrop drop);
    }
}
