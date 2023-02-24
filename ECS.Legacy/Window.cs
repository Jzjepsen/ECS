namespace ECS.Legacy;

public class Window : IWindow
{
    public bool OpenWindow(bool open)
    {
        System.Console.WriteLine("Opening Window");
        return true;
    }

    public bool CloseWindow()
    {
        System.Console.Write("Closing Window");
        return false;
    }

    public bool RunSelfTest()
    {
        return true;
    }
}