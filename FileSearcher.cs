using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class FileSearcher
    {
        private string folderPath;
        private string searchPattern;

        public FileSearcher(string _folderPath, string _searchPattern)
        {
            this.folderPath = _folderPath;
            this.searchPattern = _searchPattern;
        }

        public string[] SearchFiles()//Метод для завдання 1 
        {
            return Directory.GetFiles(folderPath, searchPattern);
        }
        public string[] SearchFilesMax()//Метод для завдання 2
        {
            return Directory.GetFiles(folderPath, searchPattern, SearchOption.AllDirectories);
        }
        public void DeleteFiles()//Метод для завдання 3 
        {
            string[] files = SearchFiles();

            if (files.Length > 0)
            {
                Console.WriteLine("Видаленi файли:");

                foreach (string file in files)
                {
                    File.Delete(file);
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Файли з такою маскою не знайдено.");
            }
        }
        public void DeleteFilesInFolder(string folder)// Для завдання 4
        {
            string[] files = Directory.GetFiles(folder, searchPattern);
            string[] subdirectories = Directory.GetDirectories(folder);

            if (files.Length > 0)
            {
                Console.WriteLine("Видаленi файли з папки {0}:", folder);

                foreach (string file in files)
                {
                    File.Delete(file);
                    Console.WriteLine(file);
                }
            }

            foreach (string subdirectory in subdirectories)
            {
                DeleteFilesInFolder(subdirectory);
            }
            DeleteEmptySubfolders(folder);
        }
        private void DeleteEmptySubfolders(string folder)//Метод для завдання 5 
        {
            string[] subdirectories = Directory.GetDirectories(folder);

            foreach (string subdirectory in subdirectories)
            {
                DeleteEmptySubfolders(subdirectory);

                if (Directory.GetFiles(subdirectory).Length == 0 && Directory.GetDirectories(subdirectory).Length == 0)
                {
                    Directory.Delete(subdirectory);
                    Console.WriteLine("Видалена пiдпапка: {0}", subdirectory);
                }
            }
        }
        public void DisplayFolderStructure()//Для завдання 5
        {
            DisplayStructure(folderPath, "");
        }
        private void DisplayStructure(string folder, string indent)//Для завдання 5
        {
            Console.WriteLine(indent + folder);

            string[] files = Directory.GetFiles(folder, searchPattern);
            foreach (string file in files)
            {
                Console.WriteLine(indent + "├─" + Path.GetFileName(file));
            }

            string[] subdirectories = Directory.GetDirectories(folder);
            foreach (string subdirectory in subdirectories)
            {
                Console.WriteLine(indent + "├─" + Path.GetFileName(subdirectory) + " [папка]");
                DisplayStructure(subdirectory, indent + "│  ");
            }
        }
    }
}
