public abstract class Prototype
{
    public string Id { get; set; }

    protected Prototype(string id) => Id = id;

    public abstract Prototype Clone();
}

public class ConcretePrototype : Prototype
{
    public ConcretePrototype(string id) : base(id) { }

    public override Prototype Clone() => (Prototype)this.MemberwiseClone();
}
