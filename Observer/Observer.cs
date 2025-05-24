// Спостерігач
public interface IObserver
{
    void Update(string message);
}

public class ConcreteObserver : IObserver
{
    private string _name;
    public ConcreteObserver(string name) => _name = name;
    public void Update(string message) => Console.WriteLine($"{_name} отримав: {message}");
}

public class Subject
{
    private List<IObserver> _observers = new();
    public void Attach(IObserver observer) => _observers.Add(observer);
    public void Detach(IObserver observer) => _observers.Remove(observer);
    public void Notify(string msg)
    {
        foreach (var obs in _observers)
            obs.Update(msg);
    }
}
