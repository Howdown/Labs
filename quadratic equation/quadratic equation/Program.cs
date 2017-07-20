namespace Quadratic_equation
{
    using System;

    public class Program
    {
        public static double Create(int namberLetter)
        {
            var letter = new char[] { 'a', 'b', 'c' };
            var nambers = 0.0;
            var rations = Console.ReadLine();
            while (double.TryParse(rations, out nambers) == false)
            {
                Console.WriteLine("все аргументы должны быть числами, введите число");
                Console.Write(letter[namberLetter] + " = ");
                rations = Console.ReadLine();
            }

            return nambers;
        }

        public static void Main()
        {
            Console.WriteLine("введите коэфиценты квадратного уравнения:");
            Console.Write("a = ");
            var a = Create(0);
            Console.WriteLine();
            Console.Write("b = ");
            var b = Create(1);
            Console.WriteLine();
            Console.Write("с = ");
            var c = Create(2);
            Console.WriteLine();

            Console.WriteLine("{0}x^2 + ({1}x) + ({2}) = 0", a, b, c);
            var d = Math.Pow(b, 2) - (4 * (a * c));
            if (d < 0)
            {
                Console.WriteLine("Нет корней");
            }
            else if (Math.Abs(d) < 0.0000001)
            {
                var x1 = (b * (-1)) / (2 * a);
                Console.WriteLine("квадратное уравнение имеет один корень = {0:#.###}", x1);
            }
            else
            {
                Console.WriteLine("квадратное уравнение имеет два корня :");
                var x1 = ((b * (-1.0)) + Math.Pow(d, 1.0 / 2.0)) / (2.0 * a);
                Console.WriteLine("первый корень = {0:0.###}", x1);
                var x2 = ((b * (-1.0)) - Math.Pow(d, 1.0 / 2.0)) / (2.0 * a);
                Console.WriteLine("второй корень = {0:0.###}", x2);
            }
        }
    }
}
