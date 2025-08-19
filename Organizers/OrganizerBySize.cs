using System;
using System.Collections.Generic;

namespace FileOrganizer
{
    public class OrganizerBySize
    {
        public static void Organize(string targetFolder)
        {

            Console.WriteLine("Organizing by size...");
            
            FileMover.Organize(targetFolder, file =>
            {
                long size = new FileInfo(file).Length;

                if (size < 1_000_000) return "Small (<1MB)";
                else if (size < 100_000_000) return "Medium (1MB-100MB)";
                else return "Large (>100MB)";
            });
        }
    }
}