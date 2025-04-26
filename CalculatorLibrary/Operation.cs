using CalculatorLibrary;

public abstract class Operation : IOperation
{
    public abstract double Execute(double operand1, double operand2);
}