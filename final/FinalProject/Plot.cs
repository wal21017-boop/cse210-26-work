public class Plot : Container
{
    private float _length;
    private float _width;
    private List<Plant> _plants = new List<Plant>();

    public override double CalculateArea()
    {
        return _length * _width;
    }
    public override void AddPlant()
    {
        string name = Console.ReadLine();
        Plant plant = new Plant(name);
        _plants.Add(plant);
    }
    Plot(string location, float shade, float length, float width) : base(location, shade)
    {
        _length = length;
        _width = width;
    }
}