using System;
namespace FileOrganizer
{
    public class OrganizingOptions
    {
        public static int Options()
        {

            Console.WriteLine("Choose the type of file organization you are looking for: ");

            Console.WriteLine("1. Alike File Types in same folder");

            Console.WriteLine("2. By Date");

            Console.WriteLine("3. By Size");

            Console.WriteLine("4. Extenisve organization making subfolders in file type folders");

            Console.WriteLine("5. Other Options");

            return int.TryParse(Console.ReadLine(), out int method) ? method : 1; ;
        }
        
    }
}