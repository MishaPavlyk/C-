// Реалізація
public interface IImplementation
{
    string OperationImplementation();
}

public class ConcreteImplementationA : IImplementation
{
    public string OperationImplementation()
    {
        return "ConcreteImplementationA";
    }
}

public class ConcreteImplementationB : IImplementation
{
    public string OperationImplementation()
    {
        return "ConcreteImplementationB";
    }
}

// Абстракція
public abstract class Abstraction
{
    protected IImplementation _implementation;

    protected Abstraction(IImplementation implementation)
    {
        _implementation = implementation;
    }

    public virtual string Operation()
    {
        return $"Abstract: Base operation with {_implementation.OperationImplementation()}";
    }
}

// Розширена абстракція
public class ExtendedAbstraction : Abstraction
{
    public ExtendedAbstraction(IImplementation implementation) : base(implementation)
    {
    }

    public override string Operation()
    {
        return $"ExtendedAbstraction: Extended operation with {_implementation.OperationImplementation()}";
    }
}

// Використання
var implementation = new ConcreteImplementationA();
var abstraction = new Abstraction(implementation);
Console.WriteLine(abstraction.Operation());

implementation = new ConcreteImplementationB();
abstraction = new ExtendedAbstraction(implementation);
Console.WriteLine(abstraction.Operation());