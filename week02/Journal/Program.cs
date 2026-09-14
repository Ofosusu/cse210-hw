using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        Journal journal = new Journal();
        PromptGenerator prompts = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.Write("What would you like to do? ");

            string answer = Console.ReadLine();
            choice = int.Parse(answer);

            if (choice == 1)
            {
                string prompt = prompts.GetRandomPrompt();

                Console.WriteLine();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                DateTime currentDate = DateTime.Now;
                string date = currentDate.ToShortDateString();

                Entry entry = new Entry();

                entry._date = date;
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);

                Console.WriteLine("Your entry has been added.");
                Console.WriteLine();
            }
            else if (choice == 2)
            {
                Console.WriteLine();
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Enter the filename to load: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);

                Console.WriteLine("Journal loaded successfully.");
                Console.WriteLine();
            }
            else if (choice == 4)
            {
                Console.Write("Enter the filename to save: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);

                Console.WriteLine("Journal saved successfully.");
                Console.WriteLine();
            }
            else if (choice == 5)
            {
                Console.WriteLine("Thank you for using the Journal Program.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                Console.WriteLine();
            }
        }
    }
}