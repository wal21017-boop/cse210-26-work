using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public class Greenhouse
{
    private string _name;
    private int _days = 0;
    private float _height = 0;
    private float _width = 0;
    private float _length = 0;
    private float _area = 0;
    private List<Container> _containers = new List<Container>();
    private List<Device> _devices = new List<Device>();

    private void CalculateFloorArea()
    {
        _area = _width * _length;
    }

    public void AddDevice(string hold)
    {
        float low = float.Parse(Console.ReadLine());
        float high = float.Parse(Console.ReadLine());
        string flowType = Console.ReadLine();
        Device device = hold switch
        {
            "ph" => new PhTester(low, high),
            "humid" => new Humidifier(low, high),
            "water" => new Hose(low, high, flowType),
            "temp" => new Thermostat(low,high),
            "nutrient" => new NutrientDispenser(low, high),
            _ => throw new Exception("Device type was not recognized")


        };

        _devices.Add(device);
    }

    public void AddContainer(string type)
    {
        Container container;
        if (type == "pot")
        {
            string location = Console.ReadLine();
            float shade = float.Parse(Console.ReadLine());
            float depth = float.Parse(Console.ReadLine());
            float radius = float.Parse(Console.ReadLine());
            container = new Pot(location, shade, depth, radius);
        }
        else
        {
            string location = Console.ReadLine();
            float shade = float.Parse(Console.ReadLine());
            float length = float.Parse(Console.ReadLine());
            float width = float.Parse(Console.ReadLine());
            container = new Plot(location,shade, length, width);
        }
        _containers.Add(container);
    }

    public void LoadGreenhouse()
    {
        
    }

    public void SaveGreenhouse()
    {
        
    }

    public Greenhouse(string name, float length, float width, float height)
    {
        _name = name;
        _height = height;
        _width = width;
        _length = length;
        CalculateFloorArea();
    }

    public void TakeCareOfPlants()
    {
        
    }

    public void Display()
    {
        
    }

    public Greenhouse(string name)
    {
        _name = name;
    }

    public void NextDay()
    {
        _days+=1;
    }
}