using System;

using System.IO;
using System.Security.Cryptography.X509Certificates;

public class Journal
{   
    public List<string> _prompts = new List<string>();
    public List<Entry> _entries = new List<Entry>();
    public string DisplayPrompt()
    {
        Random chooseprompt = new Random();

        string prompt = _prompts[chooseprompt.Next(0, _prompts.Count())];

        Console.WriteLine(prompt);
    
        return prompt;
    }
    public void DisplayJournal()
    {
        int num = 0;
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(num+=1);
            Console.WriteLine(entry._entry);
        }
    }

    public void WriteJournal()
    {
        string filename = "journal.txt";
        using (StreamWriter outputFile =  new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                
                outputFile.WriteLine($"{entry._date}~{entry._prompt}~{entry._response}~");
            }
        }

    }
    public void DownloadJournal()
    {
        string filename = "journal.txt";
        string[] all_entries = System.IO.File.ReadAllLines(filename);
        foreach (string parts in all_entries)
        {
            string [] myparts = parts.Split("~");
            Entry entry = new Entry();
            
            entry._date = DateTime.Parse(myparts[0]);
            entry._prompt = myparts[1];
            entry._response = myparts[2];
            entry._entry = entry.GetEntryPrompt();
            _entries.Add(entry);
        }
        
    }
    public void DeleteEntry(int deletion_marked)
    {
        _entries.RemoveAt(deletion_marked);
    }
    
}