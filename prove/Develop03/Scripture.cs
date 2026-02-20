using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

public class Scripture
{
    
    private Reference _reference = new Reference();
    private List<Word> _words = new List<Word>();
    private string _text = "";

    public Scripture(string refer, string text)
    {
        _reference = new Reference(refer);
        _text = text;
        TextToWords();
    }
    public Scripture(string fullText)
    {
        string[] parts = fullText.Split(" ");
        _reference = new Reference(parts[0], parts[1]);
        int i = 0;
        foreach (string part in parts)
        {
            if (i >= 2)
            {
                _words.Add(new Word(part));
            }
            i +=1;
        }
    }
    public Scripture()
    {
        _text = "";
        _words = new List<Word>();
        _reference = new Reference();
    }
    public void Display()
    {
        _reference.Display();
        foreach (Word word in _words)
        {
            word.Display();
        }
    }

    public void TextToWords()
    {
        string [] words = _text.Split(" ");
        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
        Console.WriteLine();
    }

    public void GetScripture()
    {
        _reference.SetReference();
        Console.WriteLine("Please enter the full scripture (not including the reference): ");
        _text = Console.ReadLine();
        TextToWords();
    }

    public void Memorization()
    {
        string entry = "";
        int choice = -1;
        int choice2 = -1;
        List<Word> revealed = new List<Word>();
        do {
            Display();
            Console.WriteLine();
            Console.WriteLine("If you would like to continue press enter. Otherwise, enter quit. ");
            entry = Console.ReadLine().Trim();
            Console.Clear();
            Random random = new Random();
            int i = 0;
            revealed = new List<Word>();
            foreach (Word word in _words)
                {
                    Boolean hidden = word.HiddenStatus();
                    if (hidden == false)
                    {
                        revealed.Add(word);
                    }
                }
            if (revealed.Count >= 1){
                choice = random.Next(0,revealed.Count);
            }
            if (revealed.Count >= 2)
                {
                choice2 = random.Next(0,revealed.Count);  
                }
            while (choice == choice2)
            {
                choice2 = random.Next(0,revealed.Count);;
            }
            
            foreach (Word rev in revealed)
                {
                    if (i == choice && i < revealed.Count)
                    {
                        rev.HideWord();
                    }
                    else if (i == choice2 && i < revealed.Count)
                    {
                        rev.HideWord();
                    }
                    i+=1;
                }
            if (revealed.Count <= 0)
            {
                break;
            }

        } while (entry != "quit");

    
    }
}