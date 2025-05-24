public abstract class Product
{
    public abstract string GetName();
}

public class ConcreteProductA : Product
{
    public override string GetName() => "Product A";
}

public class ConcreteProductB : Product
{
    public override string GetName() => "Product B";
}

public abstract class Creator
{
    public abstract Product FactoryMethod();
}

public class CreatorA : Creator
{
    public override Product FactoryMethod() => new ConcreteProductA();
}

public class CreatorB : Creator
{
    public override Product FactoryMethod() => new ConcreteProductB();
}
