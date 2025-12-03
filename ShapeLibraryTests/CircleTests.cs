using ShapeLibrary;

namespace ShapeLibraryTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Circle circle = new Circle(100, 200, 50, new Colour(255, 0, 0));

            Assert.AreEqual(100, circle.Center.X);
            Assert.AreEqual(200, circle.Center.Y);
            Assert.AreEqual(50, circle.Radius);
            Assert.AreEqual(new Colour(255, 0, 0), circle.Colour);

        }

        [TestMethod]
        public void VerticiesTest()
        {
            Circle circle = new Circle(100, 200, 50, new Colour(255, 0, 0));
            Assert.IsNotNull(circle.Vertices);
            Assert.IsTrue(circle.Vertices.Length == Circle.NUM_OF_VERTICIES);
            foreach (var vertex in circle.Vertices)
            {
                float radius = Vector.Magnitude(vertex - circle.Center);
                Assert.AreEqual(50, Math.Round(radius));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorNegativeRadiusTest()
        {
            Circle circle = new Circle(100, 200, -50, new Colour(50, 0, 0));
        }
    }
}
