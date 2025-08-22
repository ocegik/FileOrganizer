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

            Func<string, string>[] pipeline = choice switch
            {
                1 => new Func<string, string>[] { file => GetTypeCategory(file, categories), GetSizeCategory },
                2 => new Func<string, string>[] { file => GetTypeCategory(file, categories), GetTimeCategory },
                3 => new Func<string, string>[] { GetSizeCategory, file => GetTypeCategory(file, categories) },
                4 => new Func<string, string>[] { GetSizeCategory, GetTimeCategory },
                5 => new Func<string, string>[] { GetTimeCategory, GetSizeCategory },
                6 => new Func<string, string>[] { GetTimeCategory, file => GetTypeCategory(file, categories) },
                _ => Array.Empty<Func<string, string>>() // exit case
            };

            if (pipeline.Length == 0)
            {
                Console.WriteLine("Exiting...");
                return;
            }

            Console.WriteLine("Organizing Extensively...");

            FileMover.Organize(targetFolder, file =>
            {
                // build nested path: e.g. "Images/Large/2025"
                string path = "";
                foreach (var selector in pipeline)
                {
                    string part = selector(file);
                    path = Path.Combine(path, part);
                }
                return path;
            });
        }
        private static string GetTypeCategory(string file, Dictionary<string, string[]> categories)
        {
            string extension = Path.GetExtension(file).ToLower();
            foreach (var category in categories)
                if (Array.Exists(category.Value, ext => ext == extension))
                    return category.Key;

            return "Others";
        }
        private static string GetSizeCategory(string file)
        {
            long size = new FileInfo(file).Length;
            if (size < 1_000_000) return "Small (<1MB)";
            else if (size < 100_000_000) return "Medium (1MB-100MB)";
            else return "Large (>100MB)";
        }
        private static string GetTimeCategory(string file)
        {
            DateTime created = File.GetCreationTime(file);
            return Path.Combine(created.Year.ToString(), created.ToString("MMMM"));
        }
    }
}