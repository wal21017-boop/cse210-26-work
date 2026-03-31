public class Plant
{
    private int _age = 0;
    private int _expectedLife = 0;
    private bool _canHarvest = false;
    private bool _flowering = false;
    private int _harvestStart = 0;
    private int _harvestEnd = 0;
    private string _name = "";
    private Dictionary<string, float> _nutrients = new Dictionary<string, float>();
    private float _idealPh = 0;
    private float _phRange = 0;
    private Dictionary<string, float> _waterNeeds = new Dictionary<string, float>();
    private float _lightIntensity = 0;
    private int _lightHrs = 0;
    
    // Functions 

    public void HarvestReady()
    {
        if (_harvestStart >= _age & _age <= _harvestEnd)
        {
            Console.WriteLine($"You can begin harvesting this {_name}");
        }
        else if (_canHarvest == false)
        {
            Console.WriteLine($"{_name} cannot be harvested");
        }
        else if (_harvestEnd > _age)
        {
            Console.WriteLine($"The ideal time to harvest this {_name} has passed");
        }
        else
        {
            Console.WriteLine($"Now is not the time to harvest this {_name}");
        }
    }

    public void Flowering()
    {
        _flowering = true;
    }

    public Plant(string name)
    {
        _name = name;
        // Additional loading code here
    }

    public void Harvested()
    {
        _canHarvest = false;
    }

    public void LoadPlant()
    {
        
    }

    public void DisplayNeeds()
    {
        Console.WriteLine();
    }

}