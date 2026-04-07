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
    public Pot(string location, float shade, float depth, float radius, int number) : base(location, shade, number)
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
        Console.WriteLine($"Pot {_number}");
        foreach(Device device in _devices)
        {
            device.Display();
        }

        _plant.Display();
    }

    public override string Save()
    {
        string myDevices = "";
        foreach(Device device in _devices)
        {
            myDevices += device.Save();
        }
        return $"Pot~{_number}{_location}~{_shade}~{_depth}~{_radius}~{_occupied}~{_plant.Save()}~{myDevices}~";
    }

    public override void LoadPlant(string first, string second, string third, string fourth)
    {
       Plant plant = new Plant(first, int.Parse(second), bool.Parse(third), bool.Parse(fourth));
       _plant = plant;
        
    }
}