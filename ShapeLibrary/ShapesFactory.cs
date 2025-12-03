
namespace ShapeLibrary
{
    public static class ShapesFactory
    {
        public static ICircle CreateCircle(float x, float y, float radius, Colour colour)
        {
            Circle circle = new Circle(x, y, radius, colour);
            return circle;
        }

        public static IRectangle CreateRectangle(float x, float y, float width, float height, Colour colour)
        {
            Rectangle rectangle = new Rectangle(x, y, width, height, colour);
            return rectangle;
        }
    }
}
