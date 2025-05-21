public class Flyweight
{
    private string _sharedState;

    public Flyweight(string sharedState)
    {
        _sharedState = sharedState;
    }

    public void Operation(string uniqueState)
    {
        Console.WriteLine($"Flyweight: Displaying shared {_sharedState} and unique {uniqueState} state.");
    }
}

public class FlyweightFactory
{
    private Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();

    public Flyweight GetFlyweight(string key)
    {
        if (!_flyweights.ContainsKey(key))
        {
            Console.WriteLine($"FlyweightFactory: Can't find a flyweight, creating new one for {key}");
            _flyweights[key] = new Flyweight(key);
        }
        else
        {
            Console.WriteLine($"FlyweightFactory: Reusing existing flyweight for {key}");
        }

        return _flyweights[key];
    }

    public void ListFlyweights()
    {
        Console.WriteLine($"FlyweightFactory: I have {_flyweights.Count} flyweights:");
        foreach (var key in _flyweights.Keys)
        {
            Console.WriteLine(key);
        }
    }
}

// Використання
var factory = new FlyweightFactory();
factory.GetFlyweight("A");
factory.GetFlyweight("B");
factory.GetFlyweight("A"); // буде повторно використано

factory.ListFlyweights();

var flyweight = factory.GetFlyweight("A");
flyweight.Operation("unique state A");