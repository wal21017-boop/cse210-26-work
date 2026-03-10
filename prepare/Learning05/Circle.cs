public class Circle : Shape
{
    double _radius = 0;
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        double area = _radius* _radius * Math.PI;
        return area;
    }
}