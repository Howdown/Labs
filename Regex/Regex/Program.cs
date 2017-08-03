namespace Regex
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var inputFileSource = File.ReadAllText("data/source.txt");
            var inputColors = File.ReadAllLines("data/colors.txt");
            var allUsedColors = FindColors(inputFileSource, inputColors).Distinct();
            SaveUsedColors(allUsedColors.ToList());
        }

        public static void SaveUsedColors(List<string> colorsUsed)
        {
            var path = @"D:\labs\Regex\Regex\data\AllUsedColors.txt";
            File.WriteAllLines(path, colorsUsed);
        }

        public static List<string> FindColors(string findSource, string[] textColors)
        {
            var usedColors = new List<string>();
            var regexAllColors = @"(rgb[(]\d{1,3},\s*\d{1,3},\s*\d{1,3}[)])|(#\w{3}\b)|(#\w{6}\b)";
            var resultText = Regex.Replace(
                findSource,
                regexAllColors,
                match =>
                    {
                        var colorFromSource = match.ToString();
                        var provenColor = string.Empty;
                        var nameColor = string.Empty;
                        if (colorFromSource.Length > 8)
                        {
                            var regexNamber = new Regex(@"\d{1,3}");
                            foreach (var number in regexNamber.Matches(colorFromSource))
                            {
                                var numberInt = 0;
                                numberInt = Convert.ToInt32(number.ToString());
                                nameColor += numberInt.ToString("X2");
                            }
                        }
                        else if (colorFromSource.Length == 4)
                        {
                            nameColor = colorFromSource;
                            for (var i = colorFromSource.Length; i > 1; i -= 1)
                            {
                                var elementDouble = colorFromSource[i - 1];
                                nameColor = nameColor.Insert(i, elementDouble.ToString());
                            }
                        }
                        else
                        {
                            nameColor = colorFromSource;
                        }

                        var regexAlphabetic = new Regex(@"^\S*");
                        foreach (var color in textColors)
                        {
                            if (color.Contains(nameColor))
                            {
                                var colorName = regexAlphabetic.Match(color).ToString();
                                colorFromSource = colorName;
                                usedColors.Add(colorFromSource);
                            }
                        }

                        return colorFromSource;
                    });
            var path = @"D:\labs\Regex\Regex\data\source.txt";
            File.WriteAllText(path, resultText);
            return usedColors;
        }
    }
}
