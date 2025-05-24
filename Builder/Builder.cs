public class Product
{
    public List<string> Parts { get; } = new List<string>();

    public void Show()
    {
        Console.WriteLine("Product Parts: " + string.Join(", ", Parts));
    }
}

public abstract class Builder
{
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    public abstract Product GetResult();
}

public class ConcreteBuilder : Builder
{
    private Product _product = new Product();

    public override void BuildPartA() => _product.Parts.Add("PartA");
    public override void BuildPartB() => _product.Parts.Add("PartB");

    public override Product GetResult() => _product;
}

public class Director
{
    public void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}
