namespace Regex
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    using Microsoft.SqlServer.Server;

    public class Program
    {
        public static List<string> FindColors(string findSource)
        {
            var regexForRgb = new Regex(@"rgb[(]\d{1,3},\s*\d{1,3},\s*\d{1,3}[)]");
            var regexForHexShort = new Regex(@"#\w{3}\b");
            var regexForHexLong = new Regex(@"#\w{6}\b");
            var foundColors = new List<string>();
            foreach (var match in regexForRgb.Matches(findSource))
            {
                Console.WriteLine(match);
                foundColors.Add(match.ToString());
            }

            foreach (var match in regexForHexShort.Matches(findSource))
            {
                Console.WriteLine(match);
                foundColors.Add(match.ToString());
            }

            foreach (var match in regexForHexLong.Matches(findSource))
            {
                Console.WriteLine(match);
                foundColors.Add(match.ToString());
            }

            return foundColors;
        }

        public static List<string> AdjustmentFormats(List<string> foundColors)
        {
            var adjustmentColors = new List<string>();
            var regexRgb = new Regex(@"rgb[(]\d{1,3},\s*\d{1,3},\s*\d{1,3}[)]");
            var regexHexShort = new Regex(@"#\w{3}\b");
            foreach (var color in foundColors)
            {
                if (regexRgb.IsMatch(color))
                {
                    var regexNamber = new Regex(@"\d{1,3}");
                    var convertNumber = string.Empty;
                    foreach (var number in regexNamber.Matches(color))
                    {
                        var numberInt = 0;
                        numberInt = Convert.ToInt32(number.ToString());
                        convertNumber += numberInt.ToString("X2");
                    }

                    adjustmentColors.Add(convertNumber);
                }
                else if (regexHexShort.IsMatch(color))
                {
                    var convertHex = color.ToString();
                    for (var i = color.Length; i > 1; i -= 1)
                    {
                        var elementDouble = color.ToString()[i - 1];
                        convertHex = convertHex.Insert(i, elementDouble.ToString());
                    }

                    adjustmentColors.Add(convertHex);
                }
                else
                {
                    adjustmentColors.Add(color.ToString());
                }
            }

            return adjustmentColors;
        }

        public static List<string> Replacement(List<string> sourseView, List<string> convertedView, string[] colors, string sourceContent)
        {
            var usedColors = new List<string>();
            var regexAlphabetic = new Regex(@"^\S*");
            for (var i = 0; i < convertedView.Count; i++)
            {
                foreach (var colorFromColors in colors)
                {
                    if (colorFromColors.Contains(convertedView[i]))
                    {
                        var alphabeticForm = regexAlphabetic.Match(colorFromColors).ToString();
                        usedColors.Add(alphabeticForm);
                        var regexColor = new Regex(sourseView[i]);
                        sourceContent = regexColor.Replace(sourceContent, alphabeticForm.ToString());
                    }
                }
            }

            return usedColors;
        }

        public static void UsedColorsInNewFiles(List<string> colorsUsed)
        {
            var path = @"D:\labs\Regex\Regex\data\allUsedColors.txt";
                File.WriteAllLines(path, colorsUsed);
        }

        public static void Main()
        {
            var inputFileSource = File.ReadAllText("data/source.txt");
            var inputColors = File.ReadAllLines("data/colors.txt");
            var listColours = FindColors(inputFileSource);
            var reducedForm = AdjustmentFormats(listColours);
            var colorsPreOwned = Replacement(listColours, reducedForm, inputColors, inputFileSource).Distinct();
            UsedColorsInNewFiles(colorsPreOwned.ToList());


            //var usedColors = CompletedReplacements(listColours, inputColors, inputFileSource);
        }
        /*
        public static List<string> FindColorsHexLong(string findColorsLong)
        {
            var regexForHex = new Regex(@"#\w{6}");
            var dinosaurs = new List<string>();
            foreach (var match in regexForHex.Matches(findColorsLong))
            {
                Console.WriteLine(match);
                dinosaurs.Add(match.ToString());
            }

            return dinosaurs;
        }

        public static List<string> CompletedReplacements(List<string> sourceColorsHexLong, string[] colors, string sourceText)
        {
            var regexAlphabetic = new Regex(@"^\S*");
            var completed = new List<string>();
            var replacedString = string.Empty;
            foreach (var color in sourceColorsHexLong)
            {
                foreach (var colorFromColors in colors)
                {
                    if (colorFromColors.Contains(color))
                    {
                        var alphabeticForm = regexAlphabetic.Match(colorFromColors);
                        completed.Add(alphabeticForm.ToString());
                        var regexColor = new Regex(color);
                        replacedString = regexColor.Replace(sourceText, alphabeticForm.ToString());
                        sourceText = replacedString;
                    }
                }
            }

            var path = @"D:\labs\Regex\Regex\data\source.txt";
            Console.WriteLine(path);
            File.WriteAllText(path, replacedString);
            return completed;
        }*/
    }
}
