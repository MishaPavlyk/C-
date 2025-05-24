// Стан
public interface IState
{
    void Handle(Context context);
}

public class Context
{
    public IState State { get; set; }
    public Context(IState state) => State = state;
    public void Request() => State.Handle(this);
}

public class StateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Стан A → B");
        context.State = new StateB();
    }
}

public class StateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Стан B → A");
        context.State = new StateA();
    }
}
