
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static int _score = 0;

    // Extra features:
    // I added negative goals to help track habits a person wants to stop.
    // I also added levels, achievement badges, and level-up messages.
    // These features make the quest more interesting and encourage progress.

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
        Console.WriteLine("Welcome to Eternal Quest!");

        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nYou have {_score} points.");
            DisplayLevel();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Display Score and Achievements");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    RecordGoalEvent();
                    break;
                case "4":
                    DisplayScoreAndAchievements();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Thanks for playing Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Please enter a number from 1 to 7.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.Write("Choose a goal type: ");

        string type = Console.ReadLine();

        if (type != "1" && type != "2" &&
            type != "3" && type != "4")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        string name = ReadGoalText("Enter the goal name: ");
        string description = ReadGoalText("Enter a short description: ");
        int points = ReadPositiveNumber("Enter the points for this goal: ");

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                int target = ReadPositiveNumber(
                    "How many times must you complete this goal? ");

                int bonus = ReadPositiveNumber(
                    "How many bonus points will you receive? ");

                _goals.Add(new ChecklistGoal(
                    name, description, points, target, bonus));
                break;

            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
        }

        Console.WriteLine("Your goal has been created!");
    }

    static string ReadGoalText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value) &&
                !value.Contains("|"))
            {
                return value.Trim();
            }

            Console.WriteLine(
                "Please enter text without the | character.");
        }
    }

    static int ReadPositiveNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int number) &&
                number > 0)
            {
                return number;
            }

            Console.WriteLine("Enter a whole number greater than zero.");
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have not created any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    static void RecordGoalEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        ListGoals();
        Console.Write("Enter the number of the goal you worked on: ");

        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("That is not a valid goal number.");
            return;
        }

        Goal selectedGoal = _goals[choice - 1];

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine("You have already completed this goal.");
            return;
        }

        int oldScore = _score;
        int earnedPoints = selectedGoal.RecordEvent();

        if (earnedPoints < 0)
        {
            int deduction = Math.Min(_score, -earnedPoints);
            _score -= deduction;

            Console.WriteLine($"You lost {deduction} points.");
        }
        else
        {
            _score += earnedPoints;

            Console.WriteLine($"You earned {earnedPoints} points!");

            if (selectedGoal.IsComplete())
            {
                Console.WriteLine("Goal completed! Well done!");
            }
        }

        CheckForLevelUp(oldScore);
    }

    static void DisplayScoreAndAchievements()
    {
        Console.WriteLine("\nYour Eternal Quest Progress");
        Console.WriteLine($"Total Score: {_score}");
        DisplayLevel();

        Console.WriteLine("\nAchievement Badges:");

        if (_score >= 1000)
        {
            Console.WriteLine("Gold Champion - 1,000 points reached!");
        }
        else if (_score >= 500)
        {
            Console.WriteLine("Silver Champion - 500 points reached!");
        }
        else if (_score >= 100)
        {
            Console.WriteLine("Rising Star - 100 points reached!");
        }
        else
        {
            Console.WriteLine("Quest Beginner - Keep earning points!");
        }

        int completedGoals = 0;

        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                completedGoals++;
            }
        }

        Console.WriteLine(
            $"Completed goals: {completedGoals} out of {_goals.Count}");
    }

    static void DisplayLevel()
    {
        int level = (_score / 1000) + 1;
        Console.WriteLine($"Current Level: {level}");

        if (level >= 5)
        {
            Console.WriteLine("Title: Eternal Quest Master!");
        }
        else if (level >= 3)
        {
            Console.WriteLine("Title: Dedicated Quest Adventurer!");
        }
        else
        {
            Console.WriteLine("Title: Quest Beginner!");
        }
    }

    static void CheckForLevelUp(int oldScore)
    {
        int oldLevel = (oldScore / 1000) + 1;
        int newLevel = (_score / 1000) + 1;

        if (newLevel > oldLevel)
        {
            Console.WriteLine($"Level up! You reached level {newLevel}!");
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter a filename to save to (example: goals.txt): ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine($"Score|{_score}");

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetSaveString());
                }
            }

            Console.WriteLine("Goals and score saved successfully.");
        }
        catch (IOException)
        {
            Console.WriteLine("There was a problem saving the file.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to save there.");
        }
    }

    static void LoadGoals()
    {
        Console.Write("Enter the filename to load (example: goals.txt): ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            List<Goal> loadedGoals = new List<Goal>();
            int loadedScore = -1;

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts.Length == 2 && parts[0] == "Score")
                {
                    if (loadedScore != -1 ||
                        !int.TryParse(parts[1], out loadedScore) ||
                        loadedScore < 0)
                    {
                        Console.WriteLine("The saved score is invalid.");
                        return;
                    }

                    continue;
                }

                Goal loadedGoal = CreateGoalFromSaveString(parts);

                if (loadedGoal == null)
                {
                    Console.WriteLine(
                        "The save file contains invalid goal information.");
                    return;
                }

                loadedGoals.Add(loadedGoal);
            }

            if (loadedScore == -1)
            {
                Console.WriteLine("The save file does not contain a score.");
                return;
            }

            _goals = loadedGoals;
            _score = loadedScore;

            Console.WriteLine("Goals and score loaded successfully.");
            DisplayScoreAndAchievements();
        }
        catch (IOException)
        {
            Console.WriteLine("There was a problem reading the file.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to read that file.");
        }
    }

    static Goal CreateGoalFromSaveString(string[] parts)
    {
        try
        {
            if (parts.Length < 4)
            {
                return null;
            }

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(description))
            {
                return null;
            }

            int points = int.Parse(parts[3]);

            if (points <= 0)
            {
                return null;
            }

            switch (type)
            {
                case "Simple":
                    if (parts.Length != 5)
                        return null;

                    return new SimpleGoal(
                        name, description, points,
                        bool.Parse(parts[4]));

                case "Eternal":
                    if (parts.Length != 4)
                        return null;

                    return new EternalGoal(name, description, points);

                case "Checklist":
                    if (parts.Length != 7)
                        return null;

                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int completed = int.Parse(parts[6]);

                    if (target <= 0 || bonus <= 0 ||
                        completed < 0 || completed > target)
                    {
                        return null;
                    }

                    return new ChecklistGoal(
                        name, description, points,
                        target, bonus, completed);

                case "Negative":
                    if (parts.Length != 4)
                        return null;

                    return new NegativeGoal(name, description, points);

                default:
                    return null;
            }
        }
        catch (FormatException)
        {
            return null;
        }
        catch (OverflowException)
        {
            return null;
        }
    }
}
