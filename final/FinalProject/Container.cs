public abstract class Container
{
    protected bool _occupied = false;
    private string _location = "";
    private List<Device> _devices = new List<Device>();
    private float _shade = 0;

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
            _ => throw new Exception("Device type was not recognized")


        };
    }
    public abstract void AddPlant();
    public Container(string location, float shade)
    {
        _location = location;
        _shade = shade;
    }
}