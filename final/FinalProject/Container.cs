using System.Security.Cryptography.X509Certificates;

public abstract class Container
{
    protected bool _occupied = false;
    protected string _location = "";
    protected List<Device> _devices = new List<Device>();
    protected float _shade = 0;

    protected int _number;


    public abstract double CalculateArea();
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
            "lights" => new Lights(low, high),
            _ => throw new Exception("Device type was not recognized")


        };
        _devices.Add(device);

    }
    public abstract void AddPlant(string name);
    public Container(string location, float shade, int number)
    {
        _location = location;
        _shade = shade;
        _number = number;
    }
    


    public abstract void NextDay();

    public abstract void Display();

    public abstract string Save();

    public void LoadDevice(string first, string second, string third, string fourth, string fifth, string sixth)
    {
        float low = float.Parse(second);
        float high = float.Parse(third);
        float current = 0;
        float stored = 0;
        string flowType = "";
        int moist = 0;
        string nutrient = "";
        if (first == "ph")
        {
            current = float.Parse(fourth);
        }
        else if (first == "humid")
        {
            current = float.Parse(fourth);
            stored = float.Parse(fifth);
        }
        else if (first == "water")
        {
            flowType = fourth;
            moist = int.Parse(fifth);    
        }

        else if (first == "temp")
        {
            current = float.Parse(fourth);
        }  

        else if (first == "nutrient")
        {
            current = float.Parse(fourth);
            stored = float.Parse(fifth);
            nutrient = sixth;

        }

        else if (first == "temp")
        {
            current = float.Parse(fourth);
        }
        
        Device device = first switch
        {
            "ph" => new PhTester(low, high, current),
            "humid" => new Humidifier(low, high, current, stored),
            "water" => new Hose(low, high, flowType, moist),
            "temp" => new Thermostat(low,high, current),
            "nutrient" => new NutrientDispenser(low, high, current, stored, nutrient),
            "lights" => new Lights(low, high),
            _ => throw new Exception("Device type was not recognized")


        };
        _devices.Add(device);
    }

    public abstract void LoadPlant(string first, string second, string third, string fourth);
    
}