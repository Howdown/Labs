﻿namespace Polynomial
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
            var coefficentsFirstPolynomial = InputCoefficients(order);
            Console.WriteLine("введите степень второго многочлена");
            order = Convert.ToInt32(Console.ReadLine());
            var coefficentsSecondPolynomial = InputCoefficients(order);
            var polynomialNamberOne = new Polynomial(coefficentsFirstPolynomial);
            var polynomialNamberTwo = new Polynomial(coefficentsSecondPolynomial);

            Console.WriteLine(polynomialNamberOne.BuildPolynomial());
            Console.WriteLine($"степень первого многочлена = {polynomialNamberOne.ObtainDegreePolynomial()}");
            Console.WriteLine(polynomialNamberTwo.BuildPolynomial());
            Console.WriteLine($"степень второго многочлена = {polynomialNamberTwo.ObtainDegreePolynomial()}");

            Console.WriteLine("получение коеффицента при i-ой степени");
            Console.WriteLine("введите степень i");
            var degreeCoefficient = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(
                polynomialNamberOne.ObtainCoefficient(degreeCoefficient) != null
                    ? $"коэффицент при {degreeCoefficient}-й степени первого многочлена равен {polynomialNamberOne.ObtainCoefficient(degreeCoefficient)}"
                    : "такого коэффицента не существует у первого многочлена");
            Console.WriteLine(
                polynomialNamberTwo.ObtainCoefficient(degreeCoefficient) != null
                    ? $"коэффицент при {degreeCoefficient}-й степени второго многочлена равен {polynomialNamberTwo.ObtainCoefficient(degreeCoefficient)}"
                    : "такого коэффицента не существует у второго многочлена");

            Console.Write("сумма многочленов :");
            Console.WriteLine((polynomialNamberOne + polynomialNamberTwo).BuildPolynomial());

            Console.Write("разность многочленов :");
            Console.WriteLine((polynomialNamberOne - polynomialNamberTwo).BuildPolynomial());

            Console.Write("перемножение многочленов :");
            Console.WriteLine((polynomialNamberOne * polynomialNamberTwo).BuildPolynomial());

            Console.WriteLine("унарный минус для первого многочлена");
            var polynomialUnaryMinus = -polynomialNamberOne;
            Console.WriteLine("-(" + polynomialUnaryMinus.BuildPolynomial() + ")");
            Console.WriteLine("унарный минус для второго многочлена");
            polynomialUnaryMinus = -polynomialNamberTwo;
            Console.WriteLine("-(" + polynomialUnaryMinus.BuildPolynomial() + ")");

            Console.WriteLine(
                polynomialNamberOne.ComparePolynomials(polynomialNamberTwo)
                    ? "многочлены равны"
                    : "многочлены не равны");

            Console.WriteLine("введите значение переменной х для обоих многочленов");
            var variableX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(
                $"значение первого многочлена при х = {variableX} равно {polynomialNamberOne.CalculatePolynomials(variableX)}");
            Console.WriteLine(
                $"значение второго многочлена при х = {variableX} равно {polynomialNamberTwo.CalculatePolynomials(variableX)}");

            Console.WriteLine("вычисление значений многочлена могих переменных");
            Console.WriteLine("введите количество переменных");
            var numberVariables = Convert.ToInt32(Console.ReadLine());
            var values = InputValues(numberVariables);
            var valuesPolynomial = polynomialNamberOne.CalculatePolynomialOfSeveralVariables(values);
            var iteration = 1;
            OutputSetValuesPolynomial(values, valuesPolynomial, iteration);
            iteration++;
            valuesPolynomial = polynomialNamberTwo.CalculatePolynomialOfSeveralVariables(values);
            OutputSetValuesPolynomial(values, valuesPolynomial, iteration);

            Console.WriteLine("Нахождение корней на интервале");
            Console.WriteLine("введите левую границу интервала");
            var leftBorder = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("введите правую границу интервала");
            var rightBorder = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("введите точность");
            var epsilon = Convert.ToDouble(Console.ReadLine());
            var rootsPolynomial = polynomialNamberOne.FindRoots(leftBorder, rightBorder, epsilon);
            Console.WriteLine(
                rootsPolynomial != null
                    ? $"корень первого многочлена равен {rootsPolynomial}"
                    : "у первого многочлена нет корней на данном интервале");
            rootsPolynomial = polynomialNamberTwo.FindRoots(leftBorder, rightBorder, epsilon);
            Console.WriteLine(
                rootsPolynomial != null
                    ? $"корень второго многочлена равен {rootsPolynomial}"
                    : "у второго многочлена нет корней на данном интервале");
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
                Console.WriteLine($"введите {i}-е значение переменной");
                var importance = Convert.ToDouble(Console.ReadLine());
                valueVariable.Add(importance);
            }

            return valueVariable;
        }

        public static void OutputSetValuesPolynomial(
            List<double> inputValues,
            List<double> resultValues,
            int iterationMetod)
        {
            for (var i = 0; i < resultValues.Count; i++)
            {
                Console.WriteLine(
                    $"значение{iterationMetod}-го многочлена при х = {inputValues[i]} равно {resultValues[i]}");
            }
        }
    }
}