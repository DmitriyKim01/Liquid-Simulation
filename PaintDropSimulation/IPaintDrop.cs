using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;

namespace PaintDropSimulation
{
    public interface IPaintDrop
    {
        /// <summary>
        /// Represents a circle to be marbled
        /// </summary>
        ICircle Circle { get; }
        IRectangle BoundingBox { get; }

        /// <summary>
        /// Performs the marbling algorithm
        /// </summary>
        /// <param name="other">The other paintdrop to be combined with</param>
        void Marble(IPaintDrop other);
    }
}
