using System;

namespace FileOrganizer
{
    public class OrganizerByDate
    {
        public static void Organize(string targetFolder)
        {
            Console.WriteLine("Organizing by date...");

            FileMover.Organize(targetFolder, file =>
            {
                DateTime created = File.GetCreationTime(file);
                return Path.Combine(created.Year.ToString(), created.ToString("MMMM"));
            });
        }
    }
}