using System;
using System.Xml.Serialization;
using Microsoft.VisualBasic.FileIO;

class Program
{
    static void Main(string[] args)
    {
        Journal my_journal = new Journal();
        Entry entry = new Entry();
        my_journal._prompts.Add("What was the best moment of your day?");
        my_journal._prompts.Add("If you could make any changes today, what would you have done differently?");
        my_journal._prompts.Add("How did God bless you today?");
        my_journal._prompts.Add("How did you move closer to one of your goals today?");
        my_journal._prompts.Add("What could you do tomorrow that you wish you would have done today");
        int choice = 0;
        do{
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1: Write");
            Console.WriteLine("2: Display");
            Console.WriteLine("3: Load");
            Console.WriteLine("4: Save");
            Console.WriteLine("5: Delete Entry");
            Console.WriteLine("6: Quit");
            string choicestring = Console.ReadLine();
            choice = int.Parse(choicestring);
        
            if (choice == 1)
            {
                Add(my_journal);
            // my_journal._entries.Add(entry);
            }
            if (choice == 2)
            {
                my_journal.DisplayJournal();
            }
            if (choice == 3)
            {
                my_journal.DownloadJournal();
            }
            if (choice == 4)
            {
                my_journal.WriteJournal();
            }
            if (choice == 5)
            {
                my_journal.DisplayJournal();
                Console.WriteLine("Which mumber entry would you like to delete?");
                string delete = Console.ReadLine();
                int delete_mark = int.Parse(delete);
                my_journal.DeleteEntry(delete_mark -1);
            }
        } while (choice != 6);
        
        
    }
    static string Add(Journal my_journal)
    {
        Entry entry = new Entry();
        entry._prompt = my_journal.DisplayPrompt();
        string full = entry.RecordEntryPrompt();
        my_journal._entries.Add(entry);
        return full;
    }
}