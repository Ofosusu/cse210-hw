
using System;
using System.Diagnostics;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    private void DisplayStartingMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out _duration) && _duration > 0)
            {
                break;
            }

            Console.WriteLine("Please enter a positive number.");
        }

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        PauseWithSpinner(3);
    }

    protected abstract void PerformActivity();

    private void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        PauseWithSpinner(2);

        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name}.");
        Console.WriteLine($"You spent {_duration} seconds on this activity.");
        PauseWithSpinner(3);
        Console.WriteLine();
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected void PauseWithSpinner(int seconds)
    {
        string[] animation = { "|", "/", "-", "\\" };

        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(animation[i % animation.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void PauseForDuration(double seconds)
    {
        Stopwatch timer = Stopwatch.StartNew();
        string[] animation = { "|", "/", "-", "\\" };
        int index = 0;

        while (timer.Elapsed.TotalSeconds < seconds)
        {
            Console.Write(animation[index % animation.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            index++;
        }
    }
}
