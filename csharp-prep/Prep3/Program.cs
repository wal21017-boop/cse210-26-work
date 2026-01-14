using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int m_n = randomGenerator.Next(1,101);
        int g_n;
        do
        {
            Console.Write("What is your guess? ");
            string guess = Console.ReadLine();
            g_n = int.Parse(guess);
            if (g_n == m_n)
            {
                Console.WriteLine("You guessed it!");
            }
            else if (g_n > m_n)
            {
                Console.WriteLine("Lower");
            }
            else if (g_n < m_n)
            {
                Console.WriteLine("Higher");
            }
        } while (g_n != m_n);


    }
}