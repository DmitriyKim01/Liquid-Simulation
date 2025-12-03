using PaintDropSimulation;
using ShapeLibrary;

namespace PaintDropSimulationTests
{
    [TestClass]
    public class SurfaceTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Surface surface = new Surface(400, 300);

            Assert.IsNotNull(surface);
            Assert.AreEqual(400, surface.Width);
            Assert.AreEqual(300, surface.Height);
            Assert.AreEqual(0, surface.Drops.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CostructorNegativeWidthTest()
        {
            Surface surface = new Surface(-400, 300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CostructorNegativeHeightTest()
        {
            Surface surface = new Surface(400, -300);
        }

        [TestMethod]
        public void AddPaintDropTest()
        {
            Surface surface = new Surface(1000, 1000);
            ICircle circle1 = ShapesFactory.CreateCircle(150, 200, 50, new Colour(255, 255, 255));
            ICircle circle2 = ShapesFactory.CreateCircle(300, 400, 30, new Colour(255, 255, 255));

            IPaintDrop drop1 = new PaintDrop(circle1);
            IPaintDrop drop2 = new PaintDrop(circle2);
            surface.AddPaintDropEvent += (IPaintDrop drop) => { };

            surface.AddPaintDrop(drop1);
            surface.AddPaintDrop(drop2);

            Assert.AreEqual(2, surface.Drops.Count);
        }

        [TestMethod]
        public void AddPaintDropOutsideOfBoundries()
        {
            Surface surface = new Surface(1000, 1000);
            ICircle circle1 = ShapesFactory.CreateCircle(1500, 2000, 50, new Colour(255, 255, 255));
            ICircle circle2 = ShapesFactory.CreateCircle(3000, 4000, 30, new Colour(255, 255, 255));

            IPaintDrop drop1 = new PaintDrop(circle1);
            IPaintDrop drop2 = new PaintDrop(circle2);
            surface.AddPaintDropEvent += (IPaintDrop drop) => { };

            surface.AddPaintDrop(drop1);
            surface.AddPaintDrop(drop2);

            Assert.AreEqual(0, surface.Drops.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullPaintDropTest()
        {
            List<IPaintDrop> drops = new List<IPaintDrop>();
            Surface surface = new Surface(400, 300);
            surface.AddPaintDropEvent += (IPaintDrop drop) => { };

            surface.AddPaintDrop(null);
        }

        [TestMethod]
        public void GeneratePaintDropPatternTest()
        {
            Surface surface = new Surface(1000, 1000);
            surface.AddPaintDropEvent += (IPaintDrop drop) => { };
            surface.PatternGeneration += (ISurface surface) => new Vector(10, 5);
            surface.GeneratePaintDropPattern(15, new Colour(255, 0, 0));
            // Check if drop is added to list
            Assert.AreEqual(1, surface.Drops.Count);
            // Check if drop has correct position
            Assert.AreEqual(new Vector(10, 5), surface.Drops[0].Circle.Center);
            // Check if drop has correct radius
            Assert.AreEqual(15, surface.Drops[0].Circle.Radius);
            // Check if drop has correct color
            Assert.AreEqual(new Colour(255, 0, 0), surface.Drops[0].Circle.Colour);

        }

        [TestMethod]
        [ExpectedException(typeof(MissingMethodException))]
        public void GeneratePaintDropPatternNoPatternGeneratorTest()
        {
            Surface surface = new Surface(1000, 1000);
            surface.GeneratePaintDropPattern(15, new Colour(255, 0, 0));
        }

    }
}
