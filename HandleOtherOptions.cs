using System;

namespace FileOrganizer
{
    public class HandleOtherOptions
    {
        public static void Handle(string targetFolder)
        {
            string[] options = {
                "Edit the Extension Json list",
                "Create New Json list",
                "Exit"
            };

             int choice = MenuHelper.ShowMenu("Other Options:", options, 3);

            switch (choice)
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