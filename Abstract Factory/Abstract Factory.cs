public interface IButton
{
    void Paint();
}

public interface ICheckbox
{
    void Paint();
}

public class WinButton : IButton
{
    public void Paint() => Console.WriteLine("Windows Button");
}

public class MacButton : IButton
{
    public void Paint() => Console.WriteLine("Mac Button");
}

public class WinCheckbox : ICheckbox
{
    public void Paint() => Console.WriteLine("Windows Checkbox");
}

public class MacCheckbox : ICheckbox
{
    public void Paint() => Console.WriteLine("Mac Checkbox");
}

public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

public class WinFactory : IGUIFactory
{
    public IButton CreateButton() => new WinButton();
    public ICheckbox CreateCheckbox() => new WinCheckbox();
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}
