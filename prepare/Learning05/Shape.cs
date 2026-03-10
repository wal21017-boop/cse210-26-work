using System.Drawing;

public abstract class Shape
{
    private string _color = "";

    public string GetColor()
    {
        return _color;
    }
    public void SetColor(string color)
    {
        _color = color;
    }
    public virtual double GetArea()
    {
        double nope = 0;
        return nope;
    }
    public Shape(string color)
    {
        _color = color;
    }
}