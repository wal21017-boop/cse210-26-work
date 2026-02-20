using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.CompilerServices;

public class Word
{
    private string _word = "";
    private Boolean _hidden = false;

    public Word(string word)
    {
        _word = word;
    }
    public void HideWord()
    {
        _hidden = true;
    }
    public void Display()
    {
        if (_hidden is false)
        {
            Console.Write($"{_word} ");
            
        }
        else
        {
            string blank = "";
            foreach (char s in _word)
            {
                blank += '-';

            }
            
            Console.Write($"{blank} ");
        }
    }
    public void RevealWord()
    {
        _hidden = false;
    }

    public Boolean HiddenStatus()
    {
        Boolean hidden = _hidden;
        return hidden;
    }
}

