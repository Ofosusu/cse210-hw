using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");
        
        // Create the scripture reference.
        Reference reference = new Reference("John", 3, 16);

        // Create the scripture.//
        Scripture scripture = new Scripture(
            reference,
            "For God so loved the world that he gave his only begotten Son"
        );

        // Continue until the scripture is completely hidden.
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.Write("Press Enter to continue or type 'quit' to finish: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        // Display the final scripture if all words are hidden.
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}