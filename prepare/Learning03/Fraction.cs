using System;
using System.Diagnostics;

public class Fraction
{
    private int _top = 1;
    private int _bottom = 1;

    public Fraction()
    {
        _top = 2;
        _bottom = 3;
    }
    public Fraction(int WholeNumber)
    {
        _top = WholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _bottom = bottom;
        _top = top;
    }

    public int GetTop()
    {
        Console.Write("Please enter the top number of your fraction: ");
        string entry = Console.ReadLine();
        _top = int.Parse(entry);
        return _top;
    }
    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        Console.Write("Please enter the bottom number of your fraction: ");
        string entry = Console.ReadLine();
        _bottom = int.Parse(entry);
        return _bottom;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        string top = _top.ToString();
        string bottom = _bottom.ToString();
        string frac = $"{top}/{bottom}";
        return frac;
    }
    public double GetDecimalValue()
    {
        double top = _top;
        double bottom = _bottom;
        double deci = top/bottom;
        return deci;
    }
}