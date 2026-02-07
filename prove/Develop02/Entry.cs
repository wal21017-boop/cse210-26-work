using System;

public class Entry
{
    public DateTime _date = DateTime.Now;
    public string _entry = "";
    public string _prompt = "";
    public string _response = "";


    public string RecordEntryPrompt()
    {
        _response = Console.ReadLine();

        _entry = "Date: " + _date + ", Prompt: " + _prompt + "\n" + _response;

        return _entry;
    }

    public string GetEntryPrompt()
    {
        _entry = "Date: " + _date + ", Prompt: " + _prompt + "\n" + _response;
        return _entry;
    }




}