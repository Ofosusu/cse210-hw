
using System;
using System.Diagnostics;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Stopwatch timer = Stopwatch.StartNew();
        bool breatheIn = true;

        while (timer.Elapsed.TotalSeconds < GetDuration())
        {
            double remaining = GetDuration() - timer.Elapsed.TotalSeconds;

            if (remaining <= 0)
            {
                break;
            }

            if (breatheIn)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
            }
            else
            {
                Console.WriteLine();
                Console.Write("Breathe out... ");
            }

            int seconds = (int)Math.Min(4, Math.Ceiling(remaining));
            ShowCountDown(seconds);

            breatheIn = !breatheIn;
        }

        timer.Stop();
        Console.WriteLine();
    }
}
