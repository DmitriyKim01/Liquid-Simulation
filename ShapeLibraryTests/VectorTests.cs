using ShapeLibrary;

namespace ShapeLibraryTests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void ConstructorTest()
        { 
            Vector vector = new Vector(4, 7);
            Vector vector2 = new Vector(vector);

            Assert.AreEqual(4, vector.X);
            Assert.AreEqual(7, vector.Y);
            Assert.AreEqual(vector, vector2);
        }

        [TestMethod]
        public void AdditionTest()
        { 
            Vector  vector1 = new Vector(65, 32);
            Vector vector2 = new Vector(72, 12);
            Vector negativeVector1 = new Vector(-34, -121);
            Vector negativeVector2 = new Vector(-35, -67);

            Vector vector3 = vector1 + vector2;
            Vector negativeVector3 = negativeVector1 + negativeVector2;

            Assert.AreEqual(new Vector(137, 44), vector3);
            Assert.AreEqual(new Vector(-69, -188), negativeVector3);
        }

        [TestMethod]
        public void SubstractionTest()
        {
            Vector vector1 = new Vector(123, 23);
            Vector vector2 = new Vector(34, 54);
            Vector negativeVector1 = new Vector(-34, -121);
            Vector negativeVector2 = new Vector(-35, -67);

            Vector vector3 = vector1 - vector2;
            Vector negativeVector3 = negativeVector1 - negativeVector2;

            Assert.AreEqual(new Vector(89, -31), vector3);
            Assert.AreEqual(new Vector(1, -54), negativeVector3);
        }

        [TestMethod]
        public void VectorMultiplicationByIntTest()
        {
            Vector vector = new Vector(2, 3);
            int scalar = 2;

            Vector result = vector * scalar;

            Assert.AreEqual(4, result.X);
            Assert.AreEqual(6, result.Y);
        }

        [TestMethod]
        public void IntMultiplicationByVectorTest()
        {
            Vector vector = new Vector(2, 3);
            int scalar = 2;

            Vector result = scalar * vector;

            Assert.AreEqual(4, result.X);
            Assert.AreEqual(6, result.Y);
        }

        [TestMethod]
        public void FloatMultiplicationByVectorTest()
        {
            Vector vector = new Vector(2, 3);
            float scalar = 2.5f;

            Vector result = scalar * vector;

            Assert.AreEqual(5, result.X);
            Assert.AreEqual(7.5f, result.Y);
        }

        [TestMethod]
        public void VectorDivisionByIntTest()
        {
            Vector vector = new Vector(4, 6);
            int scalar = 2;
            Vector result = vector / scalar;
            Assert.AreEqual(2, result.X);
            Assert.AreEqual(3, result.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void VectorDivisionByZeroTest()
        {
            Vector vector = new Vector(4, 6);
            int scalar = 0;
            Vector result = vector / scalar;
        }

        [TestMethod]
        public void IntDivisionByVectorTest()
        {
            Vector vector = new Vector(4, 6);
            int scalar = 2;
            Vector result = scalar / vector;
            Assert.AreEqual(2, result.X);
            Assert.AreEqual(3, result.Y);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            float scalar = 15;
            float negativeScalar = -34;
            Vector vector1 = new Vector(25, 4);
            Vector negativeVector1 = new Vector(-12, -123);

            Vector vector3 = vector1 * scalar;
            Vector negativeVector3 = negativeVector1 * scalar;

            Assert.AreEqual(new Vector(375, 60), vector3);
            Assert.AreEqual(new Vector(-180, -1845), negativeVector3);

            Assert.AreEqual(new Vector(-850, -136), vector1 * negativeScalar);
            Assert.AreEqual(new Vector(408, 4182), negativeVector1 * negativeScalar);
        }

        [TestMethod]
        public void DivisionTest()
        {
            float scalar = 5;
            float negativeScalar = -10;
            Vector vector1 = new Vector(100, 40);
            Vector negativeVector1 = new Vector(-150, -350);

            Vector vector3 = vector1 / scalar;
            Vector negativeVector3 = negativeVector1 / scalar;

            Assert.AreEqual(new Vector(20, 8), vector3);
            Assert.AreEqual(new Vector(-30, -70), negativeVector3);

            Assert.AreEqual(new Vector(-10, -4), vector1 / negativeScalar);
            Assert.AreEqual(new Vector(15, 35), negativeVector1 / negativeScalar);

        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionTestThrowException()
        {
            float scalar = 0;
            Vector vector1 = new Vector(123, 321);

            Vector result = vector1 / 0;
        }

        [TestMethod]
        public void MagnitudeTest()
        {
            Vector vector1 = new Vector(8, 6);

            Assert.AreEqual(10, Vector.Magnitude(vector1));
        }

        [TestMethod]
        public void NormalizeTest()
        {
            Vector vector1 = new Vector(16, 12);
            Vector zeroVector = new Vector(0, 0);

            Assert.AreEqual(new Vector(0.8f, 0.6f), Vector.Normalize(vector1));
            Assert.AreEqual(new Vector(0, 0), Vector.Normalize(zeroVector));
        }

        [TestMethod]
        public void ToStringTest()
        {
            Vector vector1 = new Vector(123, 543);

            Assert.AreEqual("(X: 123, Y: 543)", vector1.ToString());
        }
    }
}
