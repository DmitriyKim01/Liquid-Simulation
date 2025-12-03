using System.Drawing;

// Operator overloading: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading
// Structure type: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct

namespace ShapeLibrary;
public struct Colour
{
    private const int MIN_VALUE = 0;
    private const int MAX_VALUE = 255;

    public int Red { get; }
    public int Blue { get; }
    public int Green { get; }
    public Colour(int red, int green, int blue)
    {
        Red = ClampColor(red);
        Green = ClampColor(green);
        Blue = ClampColor(blue);
    }

    public static Colour operator + (Colour colour1, Colour colour2)
    {
        int red = ClampColor(colour1.Red + colour2.Red);
        int green = ClampColor(colour1.Green + colour2.Green);
        int blue = ClampColor(colour1.Blue + colour2.Blue);
        return new Colour(red, green, blue);
    }

    public static Colour operator - (Colour colour1, Colour colour2)
    {
        int red = ClampColor(colour1.Red - colour2.Red);
        int green = ClampColor(colour1.Green - colour2.Green);
        int blue = ClampColor(colour1.Blue - colour2.Blue);
        return new Colour(red, green, blue);
    }

    public static Colour operator *(Colour colour1, Colour colour2)
    {
        int red = ClampColor(colour1.Red * colour2.Red);
        int green = ClampColor(colour1.Green * colour2.Green);
        int blue = ClampColor(colour1.Blue * colour2.Blue);
        return new Colour(red, green, blue);
    }

    public static Colour operator *(Colour colour, int multiplier)
    {
        int red = ClampColor(colour.Red * multiplier);
        int green = ClampColor(colour.Green * multiplier);
        int blue = ClampColor(colour.Blue * multiplier);
        return new Colour(red, green, blue);
    }
    public static Colour operator *(int multiplier, Colour colour)
    {
        return (colour * multiplier);
    }

    private static int ClampColor(int value)
    {
        // Math.Clamp() docs: https://learn.microsoft.com/en-us/dotnet/api/system.math.clamp?view=net-8.0
        return Math.Clamp(value, MIN_VALUE, MAX_VALUE);
    }

    public static bool operator ==(Colour colour1, Colour colour2)
    {
        bool isSameRed = colour1.Red == colour2.Red;
        bool isSameGreen = colour1.Green == colour2.Green;
        bool isSameBlue = colour1.Blue == colour2.Blue;

        return isSameBlue && isSameRed && isSameGreen;
    }

    public static bool operator !=(Colour colour1, Colour colour2)
    {
        return !(colour1 == colour2);
    }

    public override string ToString()
    {
        return $"(Red: {Red}, Green: {Green}, Blue: {Blue})";
    }

}
