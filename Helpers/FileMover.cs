using System;

namespace FileOrganizer
{
    public class FileMover
    {
        public static void Organize(string targetFolder, Func<string, string> categorizeFile)
        {
            int movedCount = 0;
            using StreamWriter logWriter = Logger.GetLogWriter(targetFolder);

            foreach (string file in Directory.GetFiles(targetFolder))
            {
                string fileName = Path.GetFileName(file);
                string categoryFolder = Sanitize(categorizeFile(file));

                string destinationFolder = Path.Combine(targetFolder, categoryFolder);
                Directory.CreateDirectory(destinationFolder);

                string destinationPath = Path.Combine(destinationFolder, fileName);

                try
                {
                    File.Move(file, destinationPath, overwrite: true);
                    Logger.Log(logWriter, $"Moved {fileName} → {categoryFolder}");
                    movedCount++;
                }
                catch (Exception ex)
                {
                    Logger.Log(logWriter, $"Failed {fileName} → {ex.Message}");
                }
            }
            Console.WriteLine($"✅ Done! Moved {movedCount} files. Log saved to organizer_log.txt");
        }
        private static string Sanitize(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name;
        }
    }
}