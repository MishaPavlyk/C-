using System;

namespace DesignPatterns
{
    // Singleton pattern
    public class Singleton
    {
        private static Singleton? _instance;
        private static readonly object _lock = new();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new Singleton();
                }
            }
        }

        public void DoSomething()
        {
            Console.WriteLine("Singleton is working");
        }
    }

    // Entry point
    class Program
    {
        static void Main()
        {
            var s1 = Singleton.Instance;
            var s2 = Singleton.Instance;

            s1.DoSomething();
            Console.WriteLine($"Same instance? {ReferenceEquals(s1, s2)}"); // True
        }
    }
}
