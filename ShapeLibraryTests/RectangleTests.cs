using ShapeLibrary;

namespace ShapeLibraryTests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void ConstructorPositiveTest()
        {
            Rectangle rectangle = new Rectangle(50, 50, 100, 100, new Colour(123, 221, 43));

            Assert.AreEqual(50, rectangle.X);
            Assert.AreEqual(50, rectangle.Y);
            Assert.AreEqual(100, rectangle.Width);
            Assert.AreEqual(100, rectangle.Height);
            Assert.AreEqual(new Colour(123, 221, 43), rectangle.Colour);
        }

        [TestMethod]
        public void VerticiesTest()
        {
            Rectangle rectangle = new Rectangle(50, 50, 100, 100, new Colour(123, 221, 43));
            Assert.IsNotNull(rectangle);
            Assert.AreEqual(4, rectangle.Vertices.Length);
            Assert.AreEqual(new Vector(50, 50), rectangle.Vertices[0]);
            Assert.AreEqual(new Vector(150, 50), rectangle.Vertices[1]);
            Assert.AreEqual(new Vector(150, 150), rectangle.Vertices[2]);
            Assert.AreEqual(new Vector(50, 150), rectangle.Vertices[3]);
        }

        [TestMethod]
        public void IntersectTest()
        {
            Rectangle rectangle1 = new Rectangle(50, 50, 100, 100, new Colour(123, 221, 43));
            Rectangle rectangle2 = new Rectangle(55, 55, 100, 100, new Colour(123, 221, 43));
            bool isIntersecting = rectangle1.Intersect(rectangle2);
            Assert.IsTrue(isIntersecting);
        }
        [TestMethod]
        public void NotIntersectTest()
        {
            Rectangle rectangle1 = new Rectangle(15, 15, 100, 100, new Colour(123, 221, 43));
            Rectangle rectangle2 = new Rectangle(500, 500, 100, 100, new Colour(123, 221, 43));
            bool isIntersecting = rectangle1.Intersect(rectangle2);
            Assert.IsFalse(isIntersecting);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorNegativeWidthTest()
        {
            Rectangle rectangle = new Rectangle(50, 50, -100, 100, new Colour(123, 221, 43));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorNegativeHeightTest()
        {
            Rectangle rectangle = new Rectangle(50, 50, 100, -100, new Colour(123, 221, 43));
        }
    }
}
