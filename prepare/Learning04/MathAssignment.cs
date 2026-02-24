public class MathAssignment : Assignment
{
    string _textbookSection = "";
    string _problems = "";

    public MathAssignment(string name, string top, string sect, string probs) : base(name, top)
    {
        _textbookSection = sect;
        _problems = probs;
    }

    public string GetHomeworkList()
    {
        string homework = $"Section {_textbookSection} Problems {_problems}";
        return homework;
    }
}