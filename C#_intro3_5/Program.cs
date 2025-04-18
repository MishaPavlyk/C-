using System;
using System.Collections.Generic;
using System.Linq;

class ScientificCalculator
{
    static void Main()
    {
        Console.WriteLine("Scientific Calculator (+, -, *, /, ^)");
        Console.WriteLine("Enter expression (e.g., 2^3+5*2):");
        string input = Console.ReadLine();

        try
        {
            double result = EvaluateExpression(input);
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static double EvaluateExpression(string expr)
    {
        expr = expr.Replace(" ", "");
        if (string.IsNullOrEmpty(expr))
            throw new ArgumentException("Empty expression");

        List<double> numbers = new List<double>();
        List<char> ops = new List<char>();

        int i = 0;
        while (i < expr.Length)
        {
            string numStr = "";

            while (i < expr.Length && (char.IsDigit(expr[i]) || expr[i] == '.'))
            {
                numStr += expr[i];
                i++;
            }

            if (numStr.Length == 0)
                throw new ArgumentException("Invalid number format");

            if (!double.TryParse(numStr, out double num))
                throw new ArgumentException($"Invalid number: {numStr}");

            numbers.Add(num);

            if (i >= expr.Length)
                break;

            if ("+-*/^".Contains(expr[i]))
            {
                ops.Add(expr[i]);
                i++;
            }
            else
            {
                throw new ArgumentException($"Invalid operator: {expr[i]}");
            }
        }

        if (numbers.Count != ops.Count + 1)
            throw new ArgumentException("Operator count mismatch");

        // First pass for ^ (exponentiation)
        for (int j = ops.Count - 1; j >= 0; j--)
        {
            if (ops[j] == '^')
            {
                double a = numbers[j];
                double b = numbers[j + 1];
                double tempResult = Math.Pow(a, b);

                numbers[j] = tempResult;
                numbers.RemoveAt(j + 1);
                ops.RemoveAt(j);
            }
        }

        // Second pass for * and /
        for (int j = 0; j < ops.Count; j++)
        {
            if (ops[j] == '*' || ops[j] == '/')
            {
                double a = numbers[j];
                double b = numbers[j + 1];
                double tempResult = ops[j] == '*' ? a * b : a / b;

                if (ops[j] == '/' && b == 0)
                    throw new DivideByZeroException();

                numbers[j] = tempResult;
                numbers.RemoveAt(j + 1);
                ops.RemoveAt(j);
                j--;
            }
        }

        // Third pass for + and -
        double result = numbers[0];
        for (int j = 0; j < ops.Count; j++)
        {
            if (ops[j] == '+')
                result += numbers[j + 1];
            else
                result -= numbers[j + 1];
        }

        return result;
    }
}