// Збереження стану (Memento)
public class Memento
{
    public string State { get; }
    public Memento(string state) => State = state;
}

public class Originator
{
    public string State { get; set; }
    public Memento Save() => new(State);
    public void Restore(Memento m) => State = m.State;
}

public class Caretaker
{
    public Memento Memento { get; set; }
}
