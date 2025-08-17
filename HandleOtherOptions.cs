using System;

namespace FileOrganizer
{
    public class HandleOtherOptions
    {
        public static void Handle(string targetFolder)
        {
            Console.WriteLine("1. Edit the Extension Json list");
            Console.WriteLine("2. Create New json list");
            Console.WriteLine("3. Exit");

            int chosenOption = int.TryParse(Console.ReadLine(), out int method) ? method : 3;

            switch (chosenOption)
            {
                case 1:
                    Console.WriteLine("Edit .json list");
                    break;
                case 2:
                    Console.WriteLine("Creating New Json list");
                    break;
                case 3:
                    Console.WriteLine("Exiting..");
                    break;
                default:
                    Console.WriteLine("Invalid choice, using default (3).");
                    Console.WriteLine("Exiting..");
                    break;


            }
        }
    }
}