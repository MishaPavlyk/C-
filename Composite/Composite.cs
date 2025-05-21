public abstract class Component
{
    public abstract string Operation();

    public virtual void Add(Component component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Component component)
    {
        throw new NotImplementedException();
    }

    public virtual bool IsComposite()
    {
        return true;
    }
}

public class Leaf : Component
{
    public override string Operation()
    {
        return "Leaf";
    }

    public override bool IsComposite()
    {
        return false;
    }
}

public class Composite : Component
{
    protected List<Component> _children = new List<Component>();

    public override void Add(Component component)
    {
        _children.Add(component);
    }

    public override void Remove(Component component)
    {
        _children.Remove(component);
    }

    public override string Operation()
    {
        int i = 0;
        string result = "Branch(";

        foreach (var component in _children)
        {
            result += component.Operation();
            if (i != _children.Count - 1)
            {
                result += "+";
            }
            i++;
        }

        return result + ")";
    }
}

// Використання
var leaf1 = new Leaf();
var leaf2 = new Leaf();
var composite1 = new Composite();
composite1.Add(leaf1);
composite1.Add(leaf2);

var leaf3 = new Leaf();
var composite2 = new Composite();
composite2.Add(leaf3);
composite2.Add(composite1);

Console.WriteLine(composite2.Operation());