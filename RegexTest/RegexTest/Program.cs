namespace RegexTest
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("ВВедите численное выражение типа a + b = c");
            var inputExpression = Console.ReadLine();
            var regex = @"([-]{0,1})\d(\s{0,5})[*,-,+,/](\s{0,5})\d(\s{0,5})[=](\s{0,5}([-]{0,1}))\d";
            if (inputExpression != null && Regex.IsMatch(inputExpression, regex))
            {
                Console.WriteLine("Выражение введено верно");
            }
            else
            {
                Console.WriteLine("Выражение введено неверно");
            }
        }
    }
}
