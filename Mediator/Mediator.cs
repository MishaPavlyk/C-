// Посередник
public abstract class Mediator
{
    public abstract void Send(string message, Colleague colleague);
}

public abstract class Colleague
{
    protected Mediator mediator;
    public Colleague(Mediator mediator) => this.mediator = mediator;
}

public class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(Mediator mediator) : base(mediator) { }
    public void Send(string msg) => mediator.Send(msg, this);
    public void Notify(string msg) => Console.WriteLine("Colleague1 отримав: " + msg);
}

public class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator) : base(mediator) { }
    public void Send(string msg) => mediator.Send(msg, this);
    public void Notify(string msg) => Console.WriteLine("Colleague2 отримав: " + msg);
}

public class ConcreteMediator : Mediator
{
    public ConcreteColleague1 Colleague1 { get; set; }
    public ConcreteColleague2 Colleague2 { get; set; }

    public override void Send(string message, Colleague colleague)
    {
        if (colleague == Colleague1)
            Colleague2.Notify(message);
        else
            Colleague1.Notify(message);
    }
}
