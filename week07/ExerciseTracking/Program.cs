
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");

        List<Activity> activities = new List<Activity>();

        Running running = new Running(
            new DateTime(2026, 10, 10), 30, 3.0);

        Cycling cycling = new Cycling(
            new DateTime(2026, 10, 11), 45, 15.0);

        Swimming swimming = new Swimming(
            new DateTime(2026, 10, 12), 30, 40);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
