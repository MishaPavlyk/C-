using CalculatorLibrary;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Extended Calculator");
        Console.WriteLine("Available operations: +, -, *, /");
        Console.WriteLine("Enter 'exit' to quit");

        while (true)
        {
            try
            {
                Console.Write("Enter expression (e.g., 5 + 3): ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit")
                    break;

                string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 3)
                {
                    Console.WriteLine("Invalid input format. Please use: number operator number");
                    continue;
                }

                if (!double.TryParse(parts[0], out double operand1) ||
                    !double.TryParse(parts[2], out double operand2))
                {
                    Console.WriteLine("Invalid numbers");
                    continue;
                }

                char operationSymbol = parts[1][0];
                IOperation operation = OperationFactory.CreateOperation(operationSymbol);
                double result = operation.Execute(operand1, operand2);

                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}