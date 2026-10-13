
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        int choice = 0;
        int completedActivities = 0;

        while (choice != 4)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            Activity activity = null;

            if (choice == 1)
            {
                activity = new BreathingActivity();
            }
            else if (choice == 2)
            {
                activity = new ReflectingActivity();
            }
            else if (choice == 3)
            {
                activity = new ListingActivity();
            }
            else if (choice == 4)
            {
                Console.WriteLine();
                Console.WriteLine($"You completed {completedActivities} activity session(s).");
                Console.WriteLine("Thank you for using the Mindfulness Program!");
            }
            else
            {
                Console.WriteLine("Please choose a number from 1 to 4.");
            }

            if (activity != null)
            {
                activity.Run();
                completedActivities++;
            }
        }

        // Creativity feature: I added a counter that tracks completed activity
        // sessions and displays the total when the user exits the program.
    }
}
