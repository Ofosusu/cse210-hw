
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random;

    public ReflectingActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different from other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    protected override void PerformActivity()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("Take a moment to think about this experience.");
        Console.WriteLine("Press Enter when you are ready to begin reflecting.");

        Console.ReadLine();

        Stopwatch timer = Stopwatch.StartNew();

        while (timer.Elapsed.TotalSeconds < GetDuration())
        {
            string question = _questions[_random.Next(_questions.Count)];

            Console.WriteLine();
            Console.WriteLine(question);

            double remaining = GetDuration() - timer.Elapsed.TotalSeconds;

            if (remaining <= 0)
            {
                break;
            }

            PauseForDuration(Math.Min(5, remaining));
        }

        timer.Stop();
        Console.WriteLine();
    }
}
