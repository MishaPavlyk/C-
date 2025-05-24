// Ланцюжок обов'язків
public abstract class Handler
{
    protected Handler next;
    public void SetNext(Handler next) => this.next = next;
    public abstract void HandleRequest(int level);
}

public class ConcreteHandlerA : Handler
{
    public override void HandleRequest(int level)
    {
        if (level < 10)
            Console.WriteLine("Оброблено A");
        else
            next?.HandleRequest(level);
    }
}

public class ConcreteHandlerB : Handler
{
    public override void HandleRequest(int level)
    {
        if (level >= 10)
            Console.WriteLine("Оброблено B");
        else
            next?.HandleRequest(level);
    }
}
