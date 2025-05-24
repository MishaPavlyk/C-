using System;
using System.Collections.Generic;

// ==== 1. Strategy ====
interface IStrategy
{
    void Execute();
}

class StrategyA : IStrategy
{
    public void Execute() => Console.WriteLine("Strategy A");
}

class StrategyB : IStrategy
{
    public void Execute() => Console.WriteLine("Strategy B");
}

class StrategyContext
{
    private IStrategy _strategy;
    public StrategyContext(IStrategy strategy) => _strategy = strategy;
    public void SetStrategy(IStrategy strategy) => _strategy = strategy;
    public void ExecuteStrategy() => _strategy.Execute();
}

// ==== 2. Observer ====
interface IObserver
{
    void Update(string message);
}

class Observer : IObserver
{
    private readonly string _name;
    public Observer(string name) => _name = name;
    public void Update(string message) => Console.WriteLine($"{_name} received: {message}");
}

class Subject
{
    private readonly List<IObserver> _observers = new();
    public void Attach(IObserver observer) => _observers.Add(observer);
    public void Detach(IObserver observer) => _observers.Remove(observer);
    public void Notify(string message)
    {
        foreach (var obs in _observers)
            obs.Update(message);
    }
}

// ==== 3. State ====
interface IState
{
    void Handle(StateContext context);
}

class StateA : IState
{
    public void Handle(StateContext context)
    {
        Console.WriteLine("Switching from State A to State B");
        context.State = new StateB();
    }
}

class StateB : IState
{
    public void Handle(StateContext context)
    {
        Console.WriteLine("Switching from State B to State A");
        context.State = new StateA();
    }
}

class StateContext
{
    public IState State { get; set; }
    public StateContext(IState state) => State = state;
    public void Request() => State.Handle(this);
}

// ==== 4. Command ====
interface ICommand
{
    void Execute();
}

class Receiver
{
    public void Action() => Console.WriteLine("Receiver action executed");
}

class Command : ICommand
{
    private readonly Receiver _receiver;
    public Command(Receiver receiver) => _receiver = receiver;
    public void Execute() => _receiver.Action();
}

class Invoker
{
    private ICommand? _command;
    public void SetCommand(ICommand command) => _command = command;
    public void Run() => _command?.Execute();
}

// ==== 5. Chain of Responsibility ====
abstract class Handler
{
    protected Handler? next;
    public void SetNext(Handler handler) => next = handler;
    public abstract void Handle(int level);
}

class HandlerA : Handler
{
    public override void Handle(int level)
    {
        if (level < 10)
            Console.WriteLine("Handler A handled");
        else
            next?.Handle(level);
    }
}

class HandlerB : Handler
{
    public override void Handle(int level)
    {
        if (level >= 10)
            Console.WriteLine("Handler B handled");
        else
            next?.Handle(level);
    }
}

// ==== 6. Mediator ====
abstract class Mediator
{
    public abstract void Send(string message, Colleague sender);
}

abstract class Colleague
{
    protected readonly Mediator mediator;
    public Colleague(Mediator mediator) => this.mediator = mediator;
}

class Colleague1 : Colleague
{
    public Colleague1(Mediator mediator) : base(mediator) { }
    public void Send(string message) => mediator.Send(message, this);
    public void Receive(string message) => Console.WriteLine("Colleague1 received: " + message);
}

class Colleague2 : Colleague
{
    public Colleague2(Mediator mediator) : base(mediator) { }
    public void Send(string message) => mediator.Send(message, this);
    public void Receive(string message) => Console.WriteLine("Colleague2 received: " + message);
}

class ConcreteMediator : Mediator
{
    public Colleague1? Colleague1 { get; set; }
    public Colleague2? Colleague2 { get; set; }

    public override void Send(string message, Colleague sender)
    {
        if (sender == Colleague1)
            Colleague2?.Receive(message);
        else
            Colleague1?.Receive(message);
    }
}

// ==== 7. Memento ====
class Memento
{
    public string State { get; }
    public Memento(string state) => State = state;
}

class Originator
{
    public string State { get; set; } = "";
    public Memento Save() => new(State);
    public void Restore(Memento m) => State = m.State;
}

class Caretaker
{
    public Memento? Memento { get; set; }
}

// ==== 8. Interpreter ====
interface IExpression
{
    int Interpret(Dictionary<string, int> context);
}

class NumberExpression : IExpression
{
    private readonly int _number;
    public NumberExpression(int number) => _number = number;
    public int Interpret(Dictionary<string, int> context) => _number;
}

class VariableExpression : IExpression
{
    private readonly string _name;
    public VariableExpression(string name) => _name = name;
    public int Interpret(Dictionary<string, int> context) => context[_name];
}

class AddExpression : IExpression
{
    private readonly IExpression _left, _right;
    public AddExpression(IExpression left, IExpression right) => (_left, _right) = (left, right);
    public int Interpret(Dictionary<string, int> context) => _left.Interpret(context) + _right.Interpret(context);
}

// ==== Main ====
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Strategy ===");
        var strategy = new StrategyContext(new StrategyA());
        strategy.ExecuteStrategy();
        strategy.SetStrategy(new StrategyB());
        strategy.ExecuteStrategy();

        Console.WriteLine("\n=== Observer ===");
        var subject = new Subject();
        var o1 = new Observer("A");
        var o2 = new Observer("B");
        subject.Attach(o1);
        subject.Attach(o2);
        subject.Notify("Update!");

        Console.WriteLine("\n=== State ===");
        var stateContext = new StateContext(new StateA());
        stateContext.Request();
        stateContext.Request();

        Console.WriteLine("\n=== Command ===");
        var receiver = new Receiver();
        var command = new Command(receiver);
        var invoker = new Invoker();
        invoker.SetCommand(command);
        invoker.Run();

        Console.WriteLine("\n=== Chain of Responsibility ===");
        var h1 = new HandlerA();
        var h2 = new HandlerB();
        h1.SetNext(h2);
        h1.Handle(5);
        h1.Handle(15);

        Console.WriteLine("\n=== Mediator ===");
        var mediator = new ConcreteMediator();
        var c1 = new Colleague1(mediator);
        var c2 = new Colleague2(mediator);
        mediator.Colleague1 = c1;
        mediator.Colleague2 = c2;
        c1.Send("Hi from C1");
        c2.Send("Hello from C2");

        Console.WriteLine("\n=== Memento ===");
        var originator = new Originator();
        var caretaker = new Caretaker();
        originator.State = "State 1";
        caretaker.Memento = originator.Save();
        originator.State = "State 2";
        originator.Restore(caretaker.Memento);
        Console.WriteLine("Restored State: " + originator.State);

        Console.WriteLine("\n=== Interpreter ===");
        var context = new Dictionary<string, int> { { "x", 10 }, { "y", 5 } };
        var expression = new AddExpression(new VariableExpression("x"), new VariableExpression("y"));
        Console.WriteLine("x + y = " + expression.Interpret(context));
    }
}
