public class Plant
{
    private int _age = 0;
    private bool _canHarvest = false;
    private bool _flowering = false;
    private int _floweringAge = 0;
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
        if (_floweringAge + 21 < _age)
        {
            _flowering = false;
        }
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
        {
        string filename = $"Plant.txt";
        string[] all = System.IO.File.ReadAllLines(filename);
        int spot = 0;
        string [] myparts;
        
        foreach (string parts in all)
        {
            
            myparts = parts.Split("~");
                
                    
            if (myparts[spot] == _name)
                {
                    _canHarvest = bool.Parse(myparts[spot + 1]);
                    _flowering = false;
                    _floweringAge = int.Parse(myparts[spot + 3]);
                    _harvestStart = int.Parse(myparts[spot + 4]);
                    _harvestEnd = int.Parse(myparts[spot + 5]);
                    _nutrients[myparts[spot + 6]] = int.Parse(myparts[spot + 7]);
                    _nutrients[myparts[spot + 8]] = int.Parse(myparts[spot + 9]);
                    _nutrients[myparts[spot + 10]] = int.Parse(myparts[spot + 11]);
                    _nutrients[myparts[spot + 12]] = int.Parse(myparts[spot + 13]);
                    _idealPh = int.Parse(myparts[spot + 14]);
                    _phRange = int.Parse(myparts[spot + 15]);
                    _lightIntensity = int.Parse(myparts[spot + 16]);
                    _lightHrs = int.Parse(myparts[spot + 17]);
                    _waterNeeds[myparts[spot + 18]] = float.Parse(myparts[spot + 19]);
                    
                    break;
                    
                }
                else
                    {
                        
                    }
        }
                


        }
        

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
            Console.WriteLine($"The {_name} can be harvested!");
            Console.WriteLine($"Would you like to harvest the {_name}? (y/n)");
            string yn= Console.ReadLine();
            if (yn == "y")
            {
                _canHarvest = false;
                Console.WriteLine($"The {_name} has been harvested");
                Console.WriteLine("Awesome!");
                Thread.Sleep(500);
            }
        }
        if (_harvestEnd == _age)
        {
            _canHarvest = false;
        }
        if (_flowering == true || _age == _floweringAge)
        {
            Flowering();
            Console.WriteLine($"{_name} is flowering");
        }
    }

    public void Display()
    {
        Console.WriteLine($"Plant name: {_name}");
        Console.WriteLine($"Age: {_age} days old");
        if (_canHarvest)
        {
            Console.WriteLine($"Can be harvested in approximately {_harvestStart-_age} days");
        }
        
    }

    public Plant(string name, int age, bool harvest, bool flowering)
    {
        _name = name;
        LoadPlant();
        _age = age;
        _canHarvest = harvest;
        _flowering = flowering;
    }

    public string Save()
    {
        return $"Plant~{_name}~{_age}~{_canHarvest}~{_flowering}~";
    }
}