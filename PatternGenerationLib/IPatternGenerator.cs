using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;
using PaintDropSimulation;

namespace PatternGenerationLib
{
    public interface IPatternGenerator
    {
        /// <summary>
        /// Computes the point on the surface where a PaintDrop should be added for the given pattern
        /// </summary>
        /// <param name="surface">Surface where the drop is being added</param>
        /// <returns>The location of the drop</returns>
        Vector? CalculatePatternPoint(ISurface surface);
    }
}
