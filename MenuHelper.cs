namespace FileOrganizer
{
    public class MenuHelper
    {
        public static int ShowMenu(string title, string[] options, int defaultOption = 1)
        {
            Console.WriteLine(title);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}, {options[i]}");
            }
            return int.TryParse(Console.ReadLine(), out int choice) ? choice : defaultOption;
        }
    }
}