// Інтерпретатор
public interface IExpression
{
    int Interpret(Dictionary<string, int> context);
}

public class NumberExpression : IExpression
{
    private int _number;
    public NumberExpression(int number) => _number = number;
    public int Interpret(Dictionary<string, int> context) => _number;
}

public class VariableExpression : IExpression
{
    private string _name;
    public VariableExpression(string name) => _name = name;
    public int Interpret(Dictionary<string, int> context) => context[_name];
}

public class AddExpression : IExpression
{
    private IExpression _left, _right;
    public AddExpression(IExpression left, IExpression right) => (_left, _right) = (left, right);
    public int Interpret(Dictionary<string, int> context) => _left.Interpret(context) + _right.Interpret(context);
}
