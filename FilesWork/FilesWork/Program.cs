namespace FilesWork
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        public static string ReadTextFromFile(StreamReader readFile)
        {
            var functionString = string.Empty;
            while (!readFile.EndOfStream)
            {
                functionString += readFile.ReadLine() + " ";
            }

            return functionString;
        }

        public static int StringCheck(string workString)
        {
            var arrayWords = workString.Split(
                new char[] { ' ', ',', '.', '-', '_', '/', ':', ';', '<', '>' },
                StringSplitOptions.RemoveEmptyEntries);
            var listWords = new List<string>();
            for (var i = 0; i < arrayWords.Length; i++)
            {
                var wordCheck = arrayWords[i];
                for (var j = i + 1; j < arrayWords.Length; j++)
                {
                    if (wordCheck.ToLower() == arrayWords[j].ToLower())
                    {
                        arrayWords[j] = " "; 
                    }
                }
            }

            foreach (var resultWord in arrayWords)
            {
                if (resultWord != " ")
                {
                    listWords.Add(resultWord);
                }
            }

            Console.Write("\n Уникальные слова : ");
            foreach (var outputWords in listWords)
            {
                Console.Write(outputWords + "  ");
            }

            Console.WriteLine();
            return listWords.Count;
        }

        public static void Main()
        {
            var inputFile1 = new StreamReader("fileString1.txt");
            var commonString = ReadTextFromFile(inputFile1);
            var inputFile2 = new StreamReader("fileString2.txt");
            commonString += ReadTextFromFile(inputFile2);
            var inputFile3 = new StreamReader("fileString3.txt");
            commonString += ReadTextFromFile(inputFile3);
            Console.WriteLine(commonString);
            Console.WriteLine("Количество уникальных слов в файлах = " + StringCheck(commonString));
        }
    }
}