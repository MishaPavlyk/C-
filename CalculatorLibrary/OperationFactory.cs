using CalculatorLibrary;

public static class OperationFactory
{
    public static IOperation CreateOperation(char operationSymbol)
    {
        return operationSymbol switch
        {
            '+' => new AdditionOperation(),
            '-' => new SubtractionOperation(),
            '*' => new MultiplicationOperation(),
            '/' => new DivisionOperation(),
            _ => throw new ArgumentException("Invalid operation symbol")
        };
    }
}