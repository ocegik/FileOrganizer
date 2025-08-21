using System;

namespace FileOrganizer
{
    public class UserInterface
    {
        public static void WelcomeUser()
        {
            var hour = DateTime.Now.Hour;
            string greeting = hour switch
            {
                >= 5 and < 12 => "Good Morning",
                >= 12 and < 17 => "Good Afternoon",
                >= 17 and < 22 => "Good Evening",
                _ => "Hello Night Owl"
            };
            Console.WriteLine("==== File Organizer ====");

            Console.WriteLine($"{greeting}! 👋\nWelcome to File Organizer\n");
            Console.WriteLine("This tool organizes files in a target folder based on extensions.");
            Console.WriteLine("You can switch between configs, list configs, or create new ones.\n");
        }
        public static void ShowMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Organize a folder");
            Console.WriteLine("2. Switch active config");
            Console.WriteLine("3. List available configs");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");
        }
        public static string? AskForTargetFolder()
    {
        while (true)
        {
            Console.Write("\nEnter full path of folder to organize (or type 'exit'): ");
            string input = Console.ReadLine() ?? "";

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                return null;

            if (Directory.Exists(input))
                return input;

            Console.WriteLine("That folder doesn't exist. Try again.");
        }
    }
    }
}