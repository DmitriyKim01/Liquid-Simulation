using PaintDropSimulation;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulationTests
{
    [TestClass]
    public class PaintDropTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            ICircle circle1 = ShapesFactory.CreateCircle(150, 200, 50, new Colour(255, 255, 255));
            IPaintDrop drop1 = new PaintDrop(circle1);

            Assert.IsNotNull(drop1);
            Assert.AreEqual(circle1, drop1.Circle);
            // Check the initial bounding box sizing
            Assert.IsNotNull(drop1.BoundingBox);
            Assert.AreEqual(100, drop1.BoundingBox.X);
            Assert.AreEqual(150, drop1.BoundingBox.Y);
            Assert.AreEqual(100, drop1.BoundingBox.Width);
            Assert.AreEqual(100, drop1.BoundingBox.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CostructorNullCircleTest()
        {
            IPaintDrop drop = new PaintDrop(null);
        }

        [TestMethod]
        public void MarbleSameCenterTest()
        {
            ICircle circle1 = ShapesFactory.CreateCircle(150, 200, 50, new Colour(255, 255, 255));
            ICircle circle2 = ShapesFactory.CreateCircle(150, 200, 50, new Colour(255, 255, 255));

            IPaintDrop drop1 = new PaintDrop(circle1);
            IPaintDrop drop2 = new PaintDrop(circle2);

            drop1.Marble(drop2);

            foreach (Vector vertex1 in drop1.Circle.Vertices)
            {
                foreach (Vector vertex2 in drop2.Circle.Vertices)
                {
                    Assert.AreNotEqual(vertex1, vertex2);
                }
            }
        }

        [TestMethod]
        public void MarbleBoundingBoxTest()
        {
            ICircle circle1 = ShapesFactory.CreateCircle(150, 200, 50, new Colour(255, 255, 255));
            ICircle circle2 = ShapesFactory.CreateCircle(150, 200, 50, new Colour(255, 255, 255));

            IPaintDrop drop1 = new PaintDrop(circle1);
            IPaintDrop drop2 = new PaintDrop(circle2);

            drop1.Marble(drop2);

            float rectMinX = drop1.BoundingBox.X;
            float rectMinY = drop1.BoundingBox.Y;
            float rectMaxX = drop1.BoundingBox.X + drop1.BoundingBox.Width;
            float rectMaxY = drop1.BoundingBox.Y + drop1.BoundingBox.Height;

            float circleMinX = drop1.Circle.Vertices.Min(v => v.X);
            float circleMinY = drop1.Circle.Vertices.Min(v => v.Y);
            float circleMaxX = drop1.Circle.Vertices.Max(v => v.X);
            float circleMaxY = drop1.Circle.Vertices.Max(v => v.Y);

            Assert.IsTrue(circleMinX == rectMinX);
            Assert.IsTrue(circleMinY == rectMinY);
            Assert.IsTrue(circleMaxX == rectMaxX);
            Assert.IsTrue(circleMaxY == rectMaxY);

        }

        [TestMethod]
        public void MarbleBottomRightInteractionTest()
        {
            ICircle circle1 = ShapesFactory.CreateCircle(150, 150, 50, new Colour(255, 255, 255));
            ICircle circle2 = ShapesFactory.CreateCircle(200, 200, 50, new Colour(255, 255, 255));

            IPaintDrop drop1 = new PaintDrop(circle1);
            IPaintDrop drop2 = new PaintDrop(circle2);

            drop1.Marble(drop2);

            foreach (Vector vertex1 in drop1.Circle.Vertices)
            {
                foreach (Vector vertex2 in drop2.Circle.Vertices)
                {
                    Assert.AreNotEqual(vertex1, vertex2);
                }
            }
        }

        [TestMethod]
        public void MarbleNoInteractionTest()
        {
            ICircle circle1 = ShapesFactory.CreateCircle(150, 150, 50, new Colour(255, 255, 255));
            ICircle circle2 = ShapesFactory.CreateCircle(400, 400, 50, new Colour(255, 255, 255));

            IPaintDrop drop1 = new PaintDrop(circle1);
            IPaintDrop drop2 = new PaintDrop(circle2);

            drop1.Marble(drop2);

            foreach (Vector vertex1 in drop1.Circle.Vertices)
            {
                foreach (Vector vertex2 in drop2.Circle.Vertices)
                {
                    Assert.AreNotEqual(vertex1, vertex2);
                }
            }
        }

        [TestMethod]
        public void MarbleZeroVectorTest()
        {
            ICircle circle1 = ShapesFactory.CreateCircle(0, 0, 50, new Colour(255, 255, 255));
            ICircle circle2 = ShapesFactory.CreateCircle(0, 0, 50, new Colour(255, 255, 255));

            IPaintDrop drop1 = new PaintDrop(circle1);
            IPaintDrop drop2 = new PaintDrop(circle2);

            drop1.Marble(drop2);

            foreach (Vector vertex1 in drop1.Circle.Vertices)
            {
                foreach (Vector vertex2 in drop2.Circle.Vertices)
                {
                    Assert.AreNotEqual(vertex1, vertex2);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullPaintDropTest()
        {
            ICircle circle1 = ShapesFactory.CreateCircle(150, 150, 50, new Colour(255, 255, 255));
            ICircle circle2 = ShapesFactory.CreateCircle(400, 400, 50, new Colour(255, 255, 255));

            IPaintDrop drop1 = new PaintDrop(circle1);
            IPaintDrop drop2 = new PaintDrop(circle2);

            drop1.Marble(null);
        }

    }
}
