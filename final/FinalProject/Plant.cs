public class Plant
{
    private int _age = 0;
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
        LoadPlant();
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
        Console.WriteLine($"{_name} needs soil ph greater than {_idealPh - _phRange} and less than {_idealPh + _phRange}");
        Console.WriteLine($"{_name} needs {_lightHrs} hours of light at {_lightIntensity * 100}% intensity");
        foreach (var (nutrient, num) in _nutrients)
        {
            Console.WriteLine($"{_name} needs {num} grams of {nutrient} weekly");
        }
        foreach (var (type, amount) in _waterNeeds)
        {
            Console.WriteLine($"{_name} needs {amount} hrs of water delivered by {type} weekly");
        }
    }

    public void NextDay()
    {
        _age +=1;
        if (_harvestStart == _age)
        {
            _canHarvest = true;
        }
        if (_harvestEnd == _age)
        {
            _canHarvest = false;
        }
        if (_flowering == true)
        {
            Console.WriteLine($"{_name} is flowering");
        }
    }

}