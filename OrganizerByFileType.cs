using System;
using System.Collections.Generic;

namespace FileOrganizer
{
    public class OrganizerByFileType
    {
        public static void Organize(string targetFolder, Dictionary<string, string[]> categories)
        {
            FileMover.Organize(targetFolder, file =>
            {
                string extension = Path.GetExtension(file).ToLower();
                foreach (var category in categories)
                    if (Array.Exists(category.Value, ext => ext == extension))
                        return category.Key;

                return "Others";
            });
        }
    }
}
