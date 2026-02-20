using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Runtime.CompilerServices;

public class Reference
{
    private string _book = "";
    private string _chapter = "";
    private List<int> _verses = new List<int>();

    public Reference(string book, string chapter, string verses)
    {
        _book = book;
        _chapter = chapter;

        SplitVerses(verses);

    }
    public Reference(string book, string chapVerse)
    {
        _book = book;
        string [] parts = chapVerse.Split(":");
        _chapter = parts[0];
        SplitVerses(parts[1]);
    }
    public Reference(string reference)
    {
        FormatReference(reference);

    }
    public Reference()
    {
        _book = "";
        _chapter = "";
    }
    public void SplitVerses(string verses)
    {
        string[] eachVerse = verses.Split("-");
        int start = int.Parse(eachVerse[0]);
        int end = start;
        if (eachVerse.Length > 1)
        {
            end = int.Parse(eachVerse[1]);
        }

        int i = 0;
        do
        {
            if (i <= end && i >= start)
            {
                _verses.Add(i);
            }
            i+=1;
        } while (i <= end);
    }
    public string GetReference()
    {
        string reference = ($"{_book} {_chapter}:{_verses[0]}");
        return reference;
    }
    public void FormatReference(string reference)
    {
        string[] bits = reference.Split(" ");
        if (bits.Length == 2)
        {
            _book = bits[0];
        }
        else
        {
            int num = bits.Length;
            for(int i = 0; i == num-2; i++)
                {
                    _book += bits[i];
                }
        }
        string secondBits = bits[bits.Length-1];
        string [] splitBits = secondBits.Split(":");
        _chapter = splitBits[0];
        SplitVerses(splitBits[1]);
    }
    public void Display()
    {
        if (_verses.Count == 1)
        {
            _book = _book.Trim();
            _chapter = _chapter.Trim();
            Console.WriteLine($"{_book} {_chapter}:{_verses[0]}");
        }
        else
        {
            Console.WriteLine($"{_book} {_chapter}:{_verses[0]}-{_verses[_verses.Count-1]}");
        }
    }
    public void SetReference()
    {
        Console.WriteLine("Please write the reference in this form Book Chapter:FirstVerse-LastVerse ");
        string reference = Console.ReadLine();
        FormatReference(reference);  
        
    }
}