public class Plot : Container
{
    private float _length;
    private float _width;
    private List<Plant> _plants = new List<Plant>();

    public override double CalculateArea()
    {
        return _length * _width;
    }
    public override void AddPlant(string name)
    {
        
        Plant plant = new Plant(name);
        _plants.Add(plant);
    }
    public Plot(string location, float shade, float length, float width, int number) : base(location, shade, number)
    {
        _length = length;
        _width = width;
    }

    public override void NextDay()
    {
        foreach(Plant plant in _plants)
        {
            plant.NextDay();
        }
        foreach(Device device in _devices)
        {
            device.NextDay();
        }
    }

    public override void Display()
    {
        Console.WriteLine($"Plot {_number}");
        foreach(Device device in _devices)
        {
            device.Display();
        }
        foreach(Plant plant in _plants)
        {
            plant.Display();
        }
    }

    public override string Save()
    {   
        string myPlants = "";
        foreach(Plant plant in _plants)
        {
            myPlants += plant.Save();
        }
        string myDevices = "";
        foreach(Device device in _devices)
        {
            myDevices += device.Save();
        }
        return $"Plot~{_number}~{_location}~{_shade}~{_length}~{_width}~{_occupied}~{myPlants}~{myDevices}~";
    }

    public override void LoadPlant(string first, string second, string third, string fourth)
    {
       Plant plant = new Plant(first, int.Parse(second), bool.Parse(third), bool.Parse(fourth));
       _plants.Add(plant);
    }
}