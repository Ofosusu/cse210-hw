
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _responses;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();
        _responses = new List<string>();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    protected override void PerformActivity()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("Think about your answers.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Start listing items. Press Enter after each item.");
        Console.WriteLine("Keep going until the time is up!");
        Console.WriteLine();

        _responses.Clear();

        Stopwatch timer = Stopwatch.StartNew();
        string currentResponse = "";

        while (timer.Elapsed.TotalSeconds < GetDuration())
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (!string.IsNullOrWhiteSpace(currentResponse))
                    {
                        _responses.Add(currentResponse.Trim());
                        Console.WriteLine();
                    }

                    currentResponse = "";
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (currentResponse.Length > 0)
                    {
                        currentResponse = currentResponse.Substring(
                            0, currentResponse.Length - 1);

                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    currentResponse += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            else
            {
                Thread.Sleep(50);
            }
        }

        timer.Stop();

        if (!string.IsNullOrWhiteSpace(currentResponse))
        {
            _responses.Add(currentResponse.Trim());
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_responses.Count} item(s)!");
    }
}
