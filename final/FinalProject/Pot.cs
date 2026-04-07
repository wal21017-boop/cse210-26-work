using System.Security.Cryptography.X509Certificates;

public class Pot : Container
{
    public float _depth;
    public float _radius;
    public Plant _plant;

    public override double CalculateArea()
    {
        return _radius*_radius * Math.PI * _depth;
    }
    public Pot(string location, float shade, float depth, float radius) : base(location, shade)
    {
        _depth = depth;
        _radius = radius;
    }

    public override void AddPlant(string name)
    {
        
        if (_occupied == true)
        {
            Console.WriteLine($"This pot already has a plant, please plant this{name} in a different container");
            return;
        }
        
        try
        {
            
            _plant = new Plant(name);
            _occupied = true;
        }
        catch
        {
            Console.WriteLine($"{name} does not match any of our recorded plants, please enter a different plant name");
        }
    }

    public override void NextDay()
    {
        _plant.NextDay();
        foreach (Device device in _devices)
        {
            device.NextDay();
        }
    }
    public override void Display()
    {
        foreach(Device device in _devices)
        {
            device.Display();
        }

        _plant.Display();
    }
}