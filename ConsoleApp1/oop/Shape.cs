public interface IShape
{
    public const string Name = "Shape";
    public double GetArea();
    public double GetPerimeter();
    public void DisplayInfo()
    {
        Console.WriteLine("This is a shape.");
    }
}

class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public void DisplayInfo(string info)
    {
        Console.WriteLine($"Circle with radius {Radius}, Area: {GetArea()}, Perimeter: {GetPerimeter()}");
    }
}