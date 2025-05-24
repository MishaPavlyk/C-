
public interface IStrategy
{
    void Execute();
}

public class ConcreteStrategyA : IStrategy
{
    public void Execute() => Console.WriteLine("Стратегія A");
}

public class ConcreteStrategyB : IStrategy
{
    public void Execute() => Console.WriteLine("Стратегія B");
}

public class Context
{
    private IStrategy _strategy;
    public Context(IStrategy strategy) => _strategy = strategy;
    public void SetStrategy(IStrategy strategy) => _strategy = strategy;
    public void ExecuteStrategy() => _strategy.Execute();
}
