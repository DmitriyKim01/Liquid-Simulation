using PaintDropSimulation;
using PatternGenerationLib;
using ShapeLibrary;
using Moq;

namespace PatternGenerationLibTests
{
    [TestClass]
    public class SpirographTests
    {
        [TestMethod]
        public void CalculatePatternPointTest()
        {
            var mockSurface = new Mock<ISurface>();
            var mockPaintDrop = new Mock<IPaintDrop>();
            IPatternGenerator patternGenerator = new Spirograph();

            // Setup the mock surface
            mockSurface.Setup(s => s.Width).Returns(800);
            mockSurface.Setup(s => s.Height).Returns(420);
            mockSurface.Setup(s => s.Drops).Returns(new List<IPaintDrop>());
            Vector? result = patternGenerator.CalculatePatternPoint(mockSurface.Object);

            Assert.AreEqual(578.37f, result.Value.X, 2);
            Assert.AreEqual(232.36f, result.Value.Y, 2);

            mockSurface.Setup(s => s.Drops).Returns(new List<IPaintDrop> { mockPaintDrop.Object });
            result = patternGenerator.CalculatePatternPoint(mockSurface.Object);
            Assert.AreEqual(573.56f, result.Value.X, 2);
            Assert.AreEqual(254.20f, result.Value.Y, 2);

            mockSurface.Setup(s => s.Drops).Returns(new List<IPaintDrop> { mockPaintDrop.Object, mockPaintDrop.Object });
            result = patternGenerator.CalculatePatternPoint(mockSurface.Object);
            Assert.AreEqual(565.69f, result.Value.X, 2);
            Assert.AreEqual(274.99f, result.Value.Y, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullPaintDropTest()
        {
            IPatternGenerator patternGenerator = new Spirograph();
            Vector? result = patternGenerator.CalculatePatternPoint(null);
        }
    }
}
