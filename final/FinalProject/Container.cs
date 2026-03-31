public abstract class Container
{
    protected bool _occupied = false;
    private string _location = "";
    private List<Device> _devices = new List<Device>();
    private float _shade = 0;

    public abstract double CalculateArea();
    public void AddDevice()
    {
        Device device = new Device();
    }
    public abstract void AddPlant();
    public Container(string location, float shade)
    {
        _location = location;
        _shade = shade;
    }
}