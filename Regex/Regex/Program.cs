namespace Regex
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var inputFileSource = File.ReadAllText("data/source.txt");
            var inputColors = File.ReadAllLines("data/colors.txt");
            var pathForUsedColors = ConfigurationManager.AppSettings["pathToAllUsedColors"];
            var pathSource = ConfigurationManager.AppSettings["pathToSource"];
            var allUsedColors = FindColors(inputFileSource, inputColors, pathSource).Distinct();
            SaveUsedColors(allUsedColors.ToList(), pathForUsedColors);
        }

        public static void SaveUsedColors(List<string> colorsUsed, string path)
        {
            File.WriteAllLines(path, colorsUsed);
        }

        public static List<string> FindColors(string findSource, string[] textColors, string path)
        {
            var usedColors = new List<string>();
            var colorsName = DecomposeColors(textColors);
            var regexAllColors = @"(rgb[(]\d{1,3},\s*\d{1,3},\s*\d{1,3}[)])|(#\w{3}\b)|(#\w{6}\b)";
            var resultText = Regex.Replace(
                findSource,
                regexAllColors,
                match =>
                    {
                        var colorFromSource = match.ToString();
                        string colorName;
                        if (colorFromSource.Length > 8)
                        {
                            colorName = ConvertRgb(colorFromSource);
                        }
                        else if (colorFromSource.Length == 4)
                        {
                            colorName = ConvertHexShort(colorFromSource);
                        }
                        else
                        {
                            colorName = colorFromSource;
                        }

                        if (colorsName.ContainsKey(colorName))
                        {
                            var name = colorsName[colorName];
                            colorFromSource = name;
                            usedColors.Add(colorFromSource);
                        }

                        return colorFromSource;
                    });
            File.WriteAllText(path, resultText);
            return usedColors;
        }

        public static Dictionary<string, string> DecomposeColors(string[] textFromColors)
        {
            var colors = new Dictionary<string, string>();
            foreach (var color in textFromColors)
            {
                var colorName = color.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                colors.Add(colorName[1], colorName[0]);
            }

            return colors;
        }

        public static string ConvertRgb(string rgbColors)
        {
            var name = "#";
            var regexNamber = new Regex(@"\d{1,3}");
            foreach (var number in regexNamber.Matches(rgbColors))
            {
                var numberInt = Convert.ToInt32(number.ToString());
                name += numberInt.ToString("X2");
            }

            return name;
        }

        public static string ConvertHexShort(string hexShortColors)
        {
            for (var i = hexShortColors.Length; i > 1; i -= 1)
            {
                var elementDouble = hexShortColors[i - 1];
                hexShortColors = hexShortColors.Insert(i, elementDouble.ToString());
            }
            return hexShortColors;
        }
    }
}
