using System.ComponentModel;

public class GreenHouse
{
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

    public void AddDevice()
    {
        Device device = new Device();
        _devices.Add(device);
    }

    public void AddContainer()
    {
        Container container = new Container();
        _containers.Add(container);
    }

    public void LoadGreenhouse()
    {
        
    }

    public void SaveGreenhouse()
    {
        
    }

    public GreenHouse(float length, float width, float height)
    {
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
}