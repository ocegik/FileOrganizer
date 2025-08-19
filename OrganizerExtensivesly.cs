using System;
using System.Collections.Generic;

namespace FileOrganizer
{
    public class OrganizerExtensively
    {
        public static void Organize(string targetFolder, Dictionary<string, string[]> categories)
        {
            string[] options = {
                "By Type And Size",
                "By Type and Time",
                "By Size and Type",
                "By Size and Time",
                "By Time and Size",
                "By Time and Type",
                "Exit"
            };

            int choice = MenuHelper.ShowMenu("Options:", options, 1);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Organizing by Type and Size...");
                    break;

                case 2:
                    Console.WriteLine("Organizing by Type and Time...");
                    break;

                case 3:
                    Console.WriteLine("Organizing by Size and Type...");
                    break;

                case 4:
                    Console.WriteLine("Organizing by Size and Time...");
                    break;

                case 5:
                    Console.WriteLine("Organizing by Time and Size...");
                    break;

                case 6:
                    Console.WriteLine("Organizing by Time and Type...");
                    break;

                case 7:
                    Console.WriteLine("Exiting...");
                    break;
                    
                default:
                    Console.WriteLine("Invalid choice, using default (1).");
                    Console.WriteLine("Organizing by Type and Size...");
                    break;
            }
            Console.WriteLine("Organizing Extensively...");
        }
    }
}