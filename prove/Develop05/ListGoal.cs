public class ListGoal : Goal
{
    private int _numTimesCompleted = 0;
    private int _checkpoint = 0;
    public ListGoal(string name, string description, 
    int numPoints, bool isComplete, 
    int numTimesCompleted, int checkpoint) : base(name, description, numPoints, isComplete)
    {
        _numTimesCompleted = numTimesCompleted;
        _checkpoint = checkpoint;
    }
    public override int AddPoints()
    {
        if (_numTimesCompleted == _checkpoint && _isComplete == false)
        {
            _isComplete = true;
            return _numPoints * _checkpoint;
        }
        else if (_isComplete == false)
        {
            _numTimesCompleted +=1;
            return _numPoints;
        }
        else
        {
            return 0;
        }
    }
    public override void DisplayGoal()
    {
        Console.WriteLine($"{_name} : {_description}");
    
        Console.WriteLine($"Worth {_numPoints} points for each step, and {_numPoints * _checkpoint} upon final completion");
        Console.WriteLine($"Completed [{_numTimesCompleted}/{_checkpoint}] times, {_checkpoint - _numTimesCompleted} times to go!");
        if (_isComplete != true)
        {
        Console.WriteLine($"There are {(_checkpoint - _numTimesCompleted) * _numPoints + _checkpoint *_numPoints} points still available for this goal");
        }
        if (_checkpoint == _numTimesCompleted)
        {
            Console.WriteLine("Goal Completed!");
        }
    }
    public override string SaveGoal()
    {
        return $"{nameof(ListGoal)}~{_name}~{_description}~{_numPoints}~{_isComplete}~{_numTimesCompleted}~{_checkpoint}~";
    }

    public override void CreateGoal()
    {
        base.CreateGoal();
        Console.WriteLine("How many times until this goal is fully completed? ");
        _checkpoint = int.Parse(Console.ReadLine());
    }

    public ListGoal() : base(){}
}