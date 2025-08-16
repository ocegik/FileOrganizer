using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.VisualBasic;
using FileOrganizer;


public class Extension
{
    public string[] Images { get; set; } = Array.Empty<string>();
    public string[] Videos { get; set; } = Array.Empty<string>();
    public string[] Documents { get; set; } = Array.Empty<string>();
    public string[] Audio { get; set; } = Array.Empty<string>();
}

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

        Console.WriteLine("Choose the type of file organization you are looking for: ");
        Console.WriteLine("1. Alike File Types in same folder");
        Console.WriteLine("2. By Date");
        Console.WriteLine("3. By Size");
        Console.WriteLine("4. Extenisve organization making subfolders in file type folders");
        Console.WriteLine("5. Other Options");

        int chosenMethod = int.TryParse(Console.ReadLine(), out int method) ?method : 1;

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
                HandleOtherOptions(targetFolder);
                break;
            default:
                Console.WriteLine("Invalid choice, using default (1).");
                OrganizerByFileType.Organize(targetFolder, categories);
                break;
        }

        static void HandleOtherOptions(string targetFolder)
        {
            Console.WriteLine("1. Edit the Extension .json list");
            Console.WriteLine("2. Create New json list");
            Console.WriteLine("3. Exit");
        }


        string logFilePath = Path.Combine(targetFolder, "organizer_log.txt");
        using StreamWriter LogWriter = new StreamWriter(logFilePath, append: true);

        int movedCount = 0;

        foreach (string file in Directory.GetFiles(targetFolder))
        {
            string extension = Path.GetExtension(file).ToLower();
            string fileName = Path.GetFileName(file);

            string categoryFolder = "Others";

            foreach (var category in categories)
            {
                if (Array.Exists(category.Value, ext => ext == extension))
                {
                    categoryFolder = category.Key;
                    break;
                }
            }
            string destinationFolder = Path.Combine(targetFolder, categoryFolder);

            if (!Directory.Exists(destinationFolder))
                Directory.CreateDirectory(destinationFolder);

            string destinationPath = Path.Combine(destinationFolder, fileName);

            try
            {
                File.Move(file, destinationPath);
                LogWriter.WriteLine($"{DateTime.Now}: Moved {fileName} → {categoryFolder}");
                movedCount++;
            }
            catch (Exception ex)
            {
                LogWriter.WriteLine($"{DateTime.Now}: Failed to move {fileName} → {ex.Message}");
            }

        }
        Console.WriteLine($"✅ Done! Moved {movedCount} files. Log saved to organizer_log.txt");

    }
    static Dictionary<string, string[]> LoadCategoriesFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Json File not found: {filePath}");
        }

        string jsonString = File.ReadAllText(filePath);
        var fileExtensions = JsonSerializer.Deserialize<Extension>(jsonString);

        if (fileExtensions == null)
        {
            throw new InvalidOperationException("Failed to deserialize JSON file");
        }
        return new Dictionary<string, string[]>
        {
            { "Images", fileExtensions.Images },
            { "Videos", fileExtensions.Videos },
            { "Documents", fileExtensions.Documents },
            { "Audio", fileExtensions.Audio }
        };
    }
}