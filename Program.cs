using ConsoleApp12;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введiть шлях до папки:"); //C:\Users\Admin\Desktop\Test
        string folderPath = Console.ReadLine();
        //string folderPath = (@"C:\Users\Admin\Desktop\Test"); 
        Console.WriteLine("Введiть маску для пошуку:");
        string searchPattern = Console.ReadLine(); //*.txt
        //string searchPattern = "*.txt";
        FileSearcher fileSearcher = new FileSearcher(folderPath, searchPattern);
        string[] files = fileSearcher.SearchFilesMax();
        if (files.Length > 0)
        {
            Console.WriteLine("Знайденi файли:");

            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        else
        {
            Console.WriteLine("Файли з такою маскою не знайдено.");
        }
        fileSearcher.DisplayFolderStructure();
        //fileSearcher.DeleteFilesInFolder(folderPath);



    }
}