using System.Net.NetworkInformation;
using System.Transactions;

public class NutrientDispenser : Device
{
    string _nutrient;
    double _currentNutrientLevel;
    double _nutrientStore;
    
    public void AddNutrient()
    {
        if (_nutrientStore > .2 && _currentNutrientLevel < (_lowThreshold + _highThreshold)/2)
        {
            _nutrientStore -= .2;
            _currentNutrientLevel +=.2;
        Console.WriteLine($".2 grams of {_nutrient} added to soil");
        }
        else if (_nutrientStore > 0)
        {
            _nutrientStore -= _nutrientStore;
            Console.WriteLine($"{_nutrientStore} grams of {_nutrient} added to soil, dispenser is now empty");
            Console.WriteLine($"Would you like to fill the dispenser? (y/n)");
            string yn = Console.ReadLine();
            if (yn == "y")
            {
                _nutrientStore = 1.0;
            }
        }
        else
        {
            Console.WriteLine($"Not enough {_nutrient} in dispenser, unable to add {_nutrient} to soil");
        }
    }
    public override void CheckLevel()
    {
        Console.WriteLine($"Current {_nutrient} level: {_currentNutrientLevel}");
        if (_lowThreshold >= _currentNutrientLevel)
        {
            AddNutrient();
        }

        else if (_highThreshold <= _currentNutrientLevel)
        {
            Alert();
        }
        
    }
    public override void Alert()
    {
        Console.WriteLine($"Error! {_nutrient} levels are too high!");
    }

    public override void Display()
    {
        Console.WriteLine($"Current {_nutrient} levels in soil = {_currentNutrientLevel}");
        Console.WriteLine($"Current stores of {_nutrient} in dispenser = {_nutrientStore}");
        if (_nutrientStore < .2)
        {
            
            Console.WriteLine($"{_nutrient} levels are low. Would you like to fill the dispenser? (y/n)");
            string yn = Console.ReadLine();
            if (yn == "y")
            {
                _nutrientStore = 1.0;
            }

        }
    }

    public NutrientDispenser(float low, float high) : base(low, high)
    {
        _nutrient = "null";
        do
        {
            
    
            Console.WriteLine("Which nutrient would you like this device to use? ");
            Console.WriteLine("Nitrogen, Potassium, Phosphorous, or Calcium");
            _nutrient = Console.ReadLine();
        } while (_nutrient != "Nitrogen" && _nutrient != "Phosphorous" && _nutrient != "Potassium" && _nutrient != "Calcium");
    }

    public NutrientDispenser(float low, float high, float current, float store, string nutrient) : base(low, high)
    {
        _currentNutrientLevel = current;
        _nutrientStore = store;
        _nutrient = nutrient;
    }

    public override void NextDay()
    {
        _currentNutrientLevel -=.05;
        AddNutrient();

    }
    public override string Save()
    {
        return $"Device~nutrient~{_lowThreshold}~{_highThreshold}~{_currentNutrientLevel}~{_nutrientStore}~{_nutrient}~";
    }

}