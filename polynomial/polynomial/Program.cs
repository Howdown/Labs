namespace Polynomial
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("введите степень первого многочлена");
            var order = Convert.ToInt32(Console.ReadLine());
            var coefficentsFirstPolinom = InputCoefficients(order);
            Console.WriteLine("введите степень второго многочлена");
            order = Convert.ToInt32(Console.ReadLine());
            var coefficentsSecondPolinom = InputCoefficients(order);
            var polynomialNamberOne = new Polynomial(coefficentsFirstPolinom);
            var polynomialNamberTwo = new Polynomial(coefficentsSecondPolinom);
            polynomialNamberOne.Show();
            polynomialNamberTwo.Show();
            var polinomSumm = polynomialNamberOne + polynomialNamberTwo;
            Console.Write("сумма многочленов :");
            polinomSumm.Show();
            var polinomDiference = polynomialNamberOne - polynomialNamberTwo;
            Console.Write("разность многочленов :");
            polinomDiference.Show();
            var polinomMultiply = polynomialNamberOne * polynomialNamberTwo;
            Console.Write("перемножение многочленов :");
            polinomMultiply.Show();
            polynomialNamberOne.ComparisonPolynomials(polynomialNamberTwo);
            Console.WriteLine("введите значение переменной х для обоих многочленов");
            var variableX = Convert.ToInt32(Console.ReadLine());
            var valuePolynomial = polynomialNamberOne.CalculationPolynomials(variableX);
            Console.WriteLine("значение первого многочлена при х = {0} равно {1}", variableX, valuePolynomial);
            valuePolynomial = polynomialNamberTwo.CalculationPolynomials(variableX);
            Console.WriteLine("значение второго многочлена при х = {0} равно {1}", variableX, valuePolynomial);
            Console.WriteLine("вычисление значений многочлена могих переменных");
            Console.WriteLine("введите количество переменных");
            var numberVariables = Convert.ToInt32(Console.ReadLine());
            var values = InputValues(numberVariables);
            var valuesPolynomial = polynomialNamberOne.CalculationPolynomialOfSeveralVariables(values);
            var iteration = 0;
            OutputSetValuesPolynomial(values, valuesPolynomial, ref iteration);
            valuesPolynomial = polynomialNamberTwo.CalculationPolynomialOfSeveralVariables(values);
            OutputSetValuesPolynomial(values, valuesPolynomial, ref iteration);
            Console.WriteLine("Нахождение корней на интервале");
            Console.WriteLine("введите левую границу интервала");
            var leftBorder = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("введите правую границу интервала");
            var rightBorder = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("введите точность");
            var epsilon = Convert.ToDouble(Console.ReadLine());
            if (polynomialNamberOne.FindingRoots(leftBorder, rightBorder, epsilon, out double rootsPolynomial))
            {
                Console.WriteLine("корень первого многочлена равен {0}", rootsPolynomial);
            }
            else
            {
                Console.WriteLine("у первого многочлена нет корней на данном интервале");
            }
            if (polynomialNamberTwo.FindingRoots(leftBorder, rightBorder, epsilon, out rootsPolynomial))
            {
                Console.WriteLine("корень второго многочлена равен {0}", rootsPolynomial);
            }
            else
            {
                Console.WriteLine("у второго многочлена нет корней на данном интервале");
            }
        }

        public static List<double> InputCoefficients(int number)
        {
            var ratio = new List<double>();
            for (var i = 0; i <= number; i++)
            {
                Console.WriteLine("Введите коэффицент при" + i + "-й степени");
                var coefficient = Convert.ToDouble(Console.ReadLine());
                ratio.Add(coefficient);
            }

            return ratio;
        }

        public static List<double> InputValues(int count)
        {
            var valueVariable = new List<double>();
            for (var i = 0; i < count; i++)
            {
                Console.WriteLine("введите {0}-е значение переменной", i);
                var importance = Convert.ToDouble(Console.ReadLine());
                valueVariable.Add(importance);
            }

            return valueVariable;
        }

        public static void OutputSetValuesPolynomial(List<double> inputValues, List<double> resultValues, ref int iterationMetod)
        {
            iterationMetod++;
            for (var i = 0; i < resultValues.Count; i++)
            {
                Console.WriteLine("значение{0}-го многочлена при х = {1} равно {2}", iterationMetod, inputValues[i], resultValues[i]);
            }
        }
    }
}