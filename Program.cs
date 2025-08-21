using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using FileOrganizer;


class Program
{
    static void Main(String[] args)
    {
        UserInterface.WelcomeUser();

        while (true)
        {
            UserInterface.ShowMenu();
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1": RunOrganizer(); break;
                case "2": SwitchConfig(); break;
                case "3": ListConfigs(); break;
                case "0": Console.WriteLine("Goodbye 👋"); return;
                default: Console.WriteLine("Invalid choice, try again.\n"); break;
            }
        }
    }

    private static void RunOrganizer()
    {
        string? targetFolder = UserInterface.AskForTargetFolder();
        if (targetFolder == null)
            return;

        try
        {
            var categories = FileOrganizer.ConfigHelper.LoadActiveConfig();
            OrganizingOptions.Options(targetFolder, categories);
            Console.WriteLine("✅ Organizing complete!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}\n");
        }
    }

    private static void SwitchConfig()
    {
        Console.WriteLine("\nAvailable configs:");
        var configs = FileOrganizer.ConfigHelper.ListConfigs();

        foreach (var (config, i) in configs.Select((c, i) => (c, i)))
            Console.WriteLine($"{i + 1}. {config}");

        Console.Write("\nEnter config name to activate: ");
        string newConfig = Console.ReadLine() ?? "";

        if (configs.Contains(newConfig))
        {
            FileOrganizer.ConfigHelper.SwitchConfig(newConfig);
            Console.WriteLine($"Active config switched to {newConfig}\n");
        }
        else
        {
            Console.WriteLine("Config not found.\n");
        }
    }
    private static void ListConfigs()
    {
        Console.WriteLine("\nConfigs:");
        foreach (var config in FileOrganizer.ConfigHelper.ListConfigs())
            Console.WriteLine($"- {config}");

        Console.WriteLine($"(Active: {FileOrganizer.ConfigHelper.GetActiveConfigName()})\n");
    }
}