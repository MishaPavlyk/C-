// Команда
public interface ICommand
{
    void Execute();
}

public class Receiver
{
    public void Action() => Console.WriteLine("Виконано дію");
}

public class ConcreteCommand : ICommand
{
    private Receiver _receiver;
    public ConcreteCommand(Receiver receiver) => _receiver = receiver;
    public void Execute() => _receiver.Action();
}

public class Invoker
{
    private ICommand _command;
    public void SetCommand(ICommand command) => _command = command;
    public void Run() => _command.Execute();
}
