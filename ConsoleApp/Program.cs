using StructuralPatterns.Adapter;
using StructuralPatterns.Bridge;
using StructuralPatterns.Composite;
using StructuralPatterns.Decorator;
using StructuralPatterns.Facade;
using StructuralPatterns.Flyweight;
using StructuralPatterns.Proxy;

// Демонстрація всіх патернів
Console.WriteLine("=== Structural Patterns Demo ===");

// 1. Adapter
AdapterDemo.Run();

// 2. Bridge
BridgeDemo.Run();

// 3. Composite
CompositeDemo.Run();

// 4. Decorator
DecoratorDemo.Run();

// 5. Facade
FacadeDemo.Run();

// 6. Flyweight
FlyweightDemo.Run();

// 7. Proxy
ProxyDemo.Run();