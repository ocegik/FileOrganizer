using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace FileOrganizer
{
    public class ConfigHelper
    {
        private const string ConfigDir = "Data/Configs";
        private const string ActiveFile = "Data/active_config.txt";

        public static string GetActiveConfigName()
        {
            if (!File.Exists(ActiveFile))
            {
                File.WriteAllText(ActiveFile, "default.json");
            }
            return File.ReadAllText(ActiveFile).Trim();
        }

        public static Dictionary<string, string[]> LoadActiveConfig()
        {
            string activeConfig = GetActiveConfigName();
            string path = Path.Combine(ConfigDir, activeConfig);

            if (!File.Exists(path))
                throw new FileNotFoundException($"Config not found: {path}");

            var json = File.ReadAllText(path);
            var result = JsonSerializer.Deserialize<Dictionary<string, string[]>>(json);
            if (result == null)
                throw new InvalidOperationException("Failed to parse config file.");
            return result;
        }

        public static void SaveConfig(string name, Dictionary<string, string[]> data)
        {
            string path = Path.Combine(ConfigDir, name);
            File.WriteAllText(path,
                JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
        }

        public static void SwitchConfig(string newConfig)
        {
            File.WriteAllText(ActiveFile, newConfig);
        }

        public static string[] ListConfigs()
        {
            return Directory.GetFiles(ConfigDir, "*.json")
                            .Select(Path.GetFileName)
                            .Where(name => name != null)
                            .Select(name => name!)
                            .ToArray();
        }

    }
}