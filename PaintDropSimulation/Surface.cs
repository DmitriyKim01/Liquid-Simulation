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
    internal class Surface : ISurface
    {
        public int Width { get; }
        public int Height { get; }
        private IRectangle BoundingBox;
        public List<IPaintDrop> Drops { get; }

        public event CalculatePatternPoint PatternGeneration;
        public event AddPaintDrop AddPaintDropEvent;
        public Surface(int width, int height)
        {
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }

            Width = width;
            Height = height;
            Drops = new List<IPaintDrop>();
            BoundingBox = ShapesFactory.CreateRectangle(0, 0, width, height, new Colour(255, 255, 255));
        }

        public void AddPaintDrop(IPaintDrop drop)
        {

            if (drop == null)
            {
                throw new ArgumentNullException(nameof(drop));
            }
            bool isInsideOfSurface = BoundingBox.Intersect(drop.BoundingBox);
            if (!isInsideOfSurface)
            {
                return;
            }

            AddPaintDropEvent.Invoke(drop);

            int dropsNum = Drops.Count;
            List<IPaintDrop> paintdropToRemove = new List<IPaintDrop>();
            Parallel.For(0, dropsNum, i =>
            {
                bool isIntersecting = BoundingBox.Intersect(Drops[i].BoundingBox);
                // If a marbled paint drop is outside of the screen, then I remove it from the Drops list
                if (!isIntersecting)
                {
                    paintdropToRemove.Add(Drops[i]);
                }
                else
                {
                    Drops[i].Marble(drop);
                }
            });

            for (int i = 0; i < paintdropToRemove.Count; i++)
            {
                Drops.Remove(paintdropToRemove[i]);
            }
            Drops.Add(drop);
        }

        public void GeneratePaintDropPattern(float radius, Colour colour)
        {
            if (PatternGeneration == null)
            {
                throw new MissingMethodException(nameof(PatternGeneration));
            }
            Vector? point = PatternGeneration(this);
            if (point.HasValue)
            {
                ICircle circle = ShapesFactory.CreateCircle(point.Value.X, point.Value.Y, radius, colour);
                IPaintDrop drop = new PaintDrop(circle);

                AddPaintDrop(drop);
            }

        }
    }
}
