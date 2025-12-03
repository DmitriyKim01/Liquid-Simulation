namespace ShapeLibraryTests;
using ShapeLibrary;

[TestClass]
public class ColourTests
{
    [TestMethod]
    public void ConstructorTest()
    {
        Colour colour = new Colour(120, 230, 75);
        Assert.AreEqual(120, colour.Red);
        Assert.AreEqual(230, colour.Green);
        Assert.AreEqual(75, colour.Blue);
    }
    [TestMethod]
    public void ConstructorInvalidDataTest()
    {
        Colour colour = new Colour(-100, 300, 0);
        Assert.AreEqual(0, colour.Red);
        Assert.AreEqual(255, colour.Green);
        Assert.AreEqual(0, colour.Blue);
    }

    [TestMethod]
    public void PlusOperatorTest()
    {
        Colour colour1 = new Colour(100, 150, 0);
        Colour colour2 = new Colour(123, 43, 243);

        Assert.AreEqual(new Colour(223, 193, 243), colour1 + colour2);
    }

    [TestMethod]
    public void PlusOperatorInvalidDataTest()
    {
        Colour colour1 = new Colour(-100, -300, -500);
        Colour colour2 = new Colour(300, 450, 780);

        Assert.AreEqual(new Colour(255, 255, 255), colour1 + colour2);
    }
    [TestMethod]
    public void MinusOperatorTest()
    {
        Colour colour1 = new Colour(132, 165, 75);

        Colour colour2 = new Colour(200, 167, 121);
        Assert.AreEqual(new Colour(68, 2, 46),  colour2 - colour1);
    }

    [TestMethod]
    public void MinusOperatorInvalidDataTest()
    {
        Colour colour1 = new Colour(-123, -325, -11);
        Colour colour2 = new Colour(432, 765, 1500);
        Colour colour3 = new Colour(1321,4324, 1265);

        Assert.AreEqual(new Colour(255, 255, 255), colour2 - colour1);
        Assert.AreEqual(new Colour(0, 0, 0), colour3 - colour2);
    }

    [TestMethod]
    public void MultiplyOperatorTest()
    {
        Colour colour1 = new Colour(15, 4, 32);
        Colour colour2 = new Colour(6, 20, 2);

        Assert.AreEqual(new Colour(90, 80, 64), colour2 * colour1);
    }

    [TestMethod]
    public void MultiplyOperatorInvalidDataTest()
    {
        Colour colour1 = new Colour(-143, -321, -435);
        Colour colour2 = new Colour(432, 765, 1500);
        Colour colour3 = new Colour(1321, 231, 456);

        Assert.AreEqual(new Colour(0, 0, 0), colour2 * colour1);
        Assert.AreEqual(new Colour(255, 255, 255), colour2 * colour3);
    }

    [TestMethod]
    public void MultiplyIntOperatorTest()
    {
        Colour colour1 = new Colour(15, 4, 32);
        int multiplier = 10;

        Assert.AreEqual(new Colour(150, 40, 320), multiplier * colour1);
        Assert.AreEqual(new Colour(150, 40, 320), colour1 * multiplier);
    }

    [TestMethod]
    public void EqualOperatorTest()
    {
        Colour colour1 = new Colour(432, 765, 1500);
        Colour colour2 = new Colour(432, 765, 1500);
        Colour colour3 = new Colour(231, 765, 1500);

        Assert.IsTrue(colour1 == colour2);
        Assert.IsFalse(colour1 == colour3);
    }

    [TestMethod]
    public void NotEqualOperatorTest()
    {
        Colour colour1 = new Colour(4312, 5432, 1232);
        Colour colour2 = new Colour(4312, 5432, 1232);
        Colour colour3 = new Colour(4312, 5432, 232);

        Assert.IsFalse(colour1 != colour2);
        Assert.IsTrue(colour1 != colour3);
    }

    [TestMethod]
    public void ToStringTest()
    {
        Colour colour = new Colour(231, 12, 42);

        Assert.AreEqual("(Red: 231, Green: 12, Blue: 42)", colour.ToString());
    }
}