using System;
using System.IO;

namespace FileOrganizer{
    public static class Logger
    {
        public static StreamWriter GetLogWriter(string targetFolder)
        {
            string logFilePath = Path.Combine(targetFolder, "organizer_log.txt");
            return new StreamWriter(logFilePath, append: true);
        }
        public static void Log(StreamWriter writer, string message)
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}