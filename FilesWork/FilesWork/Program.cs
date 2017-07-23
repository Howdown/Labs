namespace FilesWork
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static int CoutUniqueWords(string workString)
        {
            var count = 0;
            var arrayWords = workString.Split(
                new char[] { ' ', ',', '.', '-', '_', '/', ':', ';', '<', '>', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);
            IEnumerable<string> uniqueWords = arrayWords.Distinct();
            Console.Write("\n Уникальные слова : ");
            foreach (var outputWords in uniqueWords)
            {
                Console.Write(outputWords + "  ");
                count++;
            }

            Console.WriteLine();
            return count;
        }

        public static void Main()
        {
            var inputFile1 = File.ReadAllText("fileString1.txt");
            var inputFile2 = File.ReadAllText("fileString2.txt");
            var inputFile3 = File.ReadAllText("fileString3.txt");
            string commonString = (inputFile1 + inputFile2 + inputFile3).ToLower();
            Console.WriteLine(commonString);
            Console.WriteLine("Количество уникальных слов в файлах = " + CoutUniqueWords(commonString));
        }
    }
}