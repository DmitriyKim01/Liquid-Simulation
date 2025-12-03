namespace PatternGenerationLibTests;

using PaintDropSimulation;
using PatternGenerationLib;
using ShapeLibrary;
using Moq;

[TestClass]
public class PhyllotaxisTests
{
    [TestMethod]
    public void CalculatePatternPointTest()
    {
        var mockSurface = new Mock<ISurface>();
        var mockPaintDrop = new Mock<IPaintDrop>();
        IPatternGenerator patternGenerator = new Phyllotaxis();

        // Setup the mock surface
        mockSurface.Setup(s => s.Width).Returns(800);
        mockSurface.Setup(s => s.Height).Returns(420);
        mockSurface.Setup(s => s.Drops).Returns(new List<IPaintDrop>());
        Vector? result = patternGenerator.CalculatePatternPoint(mockSurface.Object);
        // Values from prelab
        Assert.AreEqual(new Vector(400, 210), result);

        mockSurface.Setup(s => s.Drops).Returns(new List<IPaintDrop> { mockPaintDrop.Object });
        result = patternGenerator.CalculatePatternPoint(mockSurface.Object);
        Assert.AreEqual(388.94f, result.Value.X, 2);
        Assert.AreEqual(220.13f, result.Value.Y, 2);

        mockSurface.Setup(s => s.Drops).Returns(new List<IPaintDrop> { mockPaintDrop.Object, mockPaintDrop.Object });
        result = patternGenerator.CalculatePatternPoint(mockSurface.Object);
        Assert.AreEqual(401.84f, result.Value.X, 2);
        Assert.AreEqual(188.86f, result.Value.Y, 2);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void AddNullPaintDropTest()
    {
        IPatternGenerator patternGenerator = new Phyllotaxis();
        Vector? result = patternGenerator.CalculatePatternPoint(null);
    }
}