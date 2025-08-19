using System.Text.Json;

namespace FileOrganizer
{
    public class LoadJsonFile
    {
        public static Dictionary<string, string[]> LoadJson(string extensionListPath = "Data/FileExtensionsList.json")
        {
            if (!File.Exists(extensionListPath))
            {
                throw new FileNotFoundException($"Json File not found: {extensionListPath}");
            }
            string jsonString = File.ReadAllText(extensionListPath);

             return JsonSerializer.Deserialize<Dictionary<string, string[]>>(jsonString)
               ?? throw new InvalidOperationException("Failed to deserialize JSON file");
        }
    }
}