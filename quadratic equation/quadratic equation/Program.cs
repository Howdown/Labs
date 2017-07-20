namespace Quadratic_equation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var ration1 = 0.0;
            var ration2 = 0.0;
            var ration3 = 0.0;
            Console.WriteLine("введите коэфиценты квадратного уравнения:");
            Console.Write("a = ");
            var a = Console.ReadLine();
            Console.WriteLine();
                if (a != null && double.TryParse(a, out ration1))
                {
                }
                else
                {
                    Console.WriteLine("все аргументы должны быть числами, введите число");
                    Environment.Exit(0);
                }

            Console.Write("b = ");
            var b = Console.ReadLine();
            Console.WriteLine();
                if (b != null && double.TryParse(b, out ration2))
                {
                }
                else
                {
                    Console.WriteLine("все аргументы должны быть числами, введите число");
                    Environment.Exit(0);
                }

            Console.Write("с = ");
            var c = Console.ReadLine();
            Console.WriteLine();
                if (c != null && double.TryParse(c, out ration3))
                {
                }
                else
                {
                    Console.WriteLine("все аргументы должны быть числами, введите число");
                    Environment.Exit(0);
                }

            Console.WriteLine("{0}x^2 + ({1}x) + ({2}) = 0", ration1, ration2, ration3);
            var d = Math.Pow(ration2, 2) - (4 * (ration1 * ration3));
            if (d < 0)
            {
                Console.WriteLine("Нет корней");
            }
            else if (Math.Abs(d) < 0.0000001)
            {
               var x1 = (ration2 * (-1)) / (2 * ration1);
                Console.WriteLine("квадратное уравнение имеет один корень = {0:#.###}", x1);
            }
            else
            {
                Console.WriteLine("квадратное уравнение имеет два корня :");
                var x1 = ((ration2 * (-1.0)) + Math.Pow(d, 1.0 / 2.0)) / (2.0 * ration1);
                Console.WriteLine("первый корень = {0:0.###}", x1);
                var x2 = ((ration2 * (-1.0)) - Math.Pow(d, 1.0 / 2.0)) / (2.0 * ration1);
                Console.WriteLine("второй корень = {0:0.###}", x2);
            }
        }
    }
}
