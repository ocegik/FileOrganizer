using System;
namespace FileOrganizer
{
    public class OrganizingOptions
    {
        public static void Options(string targetFolder, Dictionary<string, string[]> categories)
        {

            string[] options = {
                "Alike File Types in same folder",
                "By Date",
                "By Size",
                "Extensive organization making subfolders in file type folders",
                "Other Options"
            };

            int choice = MenuHelper.ShowMenu("Options:", options, 1);
            
            switch (choice)
            {
                case 1:
                    OrganizerByFileType.Organize(targetFolder, categories);
                    break;

                case 2:
                    OrganizerByDate.Organize(targetFolder);
                    break;
                case 3:
                    OrganizerBySize.Organize(targetFolder);
                    break;
                case 4:
                    OrganizerExtensively.Organize(targetFolder, categories);
                    break;
                case 5:
                    HandleOtherOptions.Handle(targetFolder);
                    break;
                default:
                    Console.WriteLine("Invalid choice, using default (1).");
                    OrganizerByFileType.Organize(targetFolder, categories);
                    break;
            }
        }     
    }
}