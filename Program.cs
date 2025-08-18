using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using FileOrganizer;


class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("=== File Organizer ===");

        Console.Write("Enter the full path of folder to organize: ");
        string targetFolder = Console.ReadLine() ?? "";

        if (!Directory.Exists(targetFolder))
        {
            Console.WriteLine("The folder doesn't exist at given path.");
            return;
        }

        string extensionListPath = "FileExtensionsList.json";
        Dictionary<string, string[]> categories;

        try
        {
            categories = LoadCategoriesFromJson(extensionListPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to load Json file: {ex.Message}");
            return;
        }

        int chosenMethod = OrganizingOptions.Options();


        switch (chosenMethod)
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

        static Dictionary<string, string[]> LoadCategoriesFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Json File not found: {filePath}");
            }

            string jsonString = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<Dictionary<string, string[]>>(jsonString)
               ?? throw new InvalidOperationException("Failed to deserialize JSON file");
        }
    }
}