using System;

class Program
{
    static void Main(string[] args)
    {
        Square s1 = new Square("red", 4);
        Rectangle s2 = new Rectangle("blue", 3, 5);
        Circle s3 = new Circle("yellow", 4);
        List<Shape> shapes = new List<Shape>{s1,s2,s3};
        foreach (Shape shape in shapes)
        {
            
            Console.Write($"The {shape.GetColor()} shape has an area of (drumroll please...)");
            Thread.Sleep(1000);
            Console.Write("  " + shape.GetArea());
            Console.WriteLine();
        }
    }
}