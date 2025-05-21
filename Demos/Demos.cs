public static class AdapterDemo
{
    public static void Run()
    {
        Console.WriteLine("\n=== Adapter ===");
        var adaptee = new Adaptee();
        var target = new Adapter(adaptee);
        Console.WriteLine(target.GetRequest());
    }
}

public static class BridgeDemo
{
    public static void Run()
    {
        Console.WriteLine("\n=== Bridge ===");
        var implementation = new ConcreteImplementationA();
        var abstraction = new ExtendedAbstraction(implementation);
        Console.WriteLine(abstraction.Operation());
    }
}
