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

        string extensionListPath = "Data/FileExtensionsList.json";

        try
        {
            var categories = LoadJsonFile.LoadJson(extensionListPath);
            OrganizingOptions.Options(targetFolder, categories);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to load Json file: {ex.Message}");
            return;
        }
    }
}