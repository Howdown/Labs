namespace FilesWork
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static List<string> CoutUniqueWords(string workString)
        {
            var arrayWords = workString.Split(
                new string[] { " - ", " ", ",", ".", "_", "/", ":", ";", "<", ">", "\n", "\r" },
                StringSplitOptions.RemoveEmptyEntries);
            var uniqueWords = arrayWords.Distinct().ToList();
            return uniqueWords;
        }

        public static void Main()
        {
            var inputFile1 = File.ReadAllText("data/fileString1.txt");
            var inputFile2 = File.ReadAllText("data/fileString2.txt");
            var inputFile3 = File.ReadAllText("data/fileString3.txt");
            var commonString = (inputFile1 + inputFile2 + inputFile3).ToLower();
            Console.WriteLine(commonString);
            Console.Write("\n Уникальные слова : ");
            var sortingWords = CoutUniqueWords(commonString);
            foreach (var outputWords in sortingWords)
            {
                Console.Write(outputWords + "  ");
            }

            Console.WriteLine();
            Console.WriteLine("Количество уникальных слов в файлах = " + sortingWords.Count);
        }
    }
}