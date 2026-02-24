
public class Assignment
{
    protected string _studentName = "";
    private string _topic = "";

    public string GetSummary()
    {
        string summary = $"{_studentName} - {_topic} ";
        return (summary);
    }

    public Assignment(string name, string top)
    {
        _studentName = name;
        _topic = top;
    }

}


