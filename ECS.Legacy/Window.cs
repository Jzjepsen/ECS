namespace ECS.Legacy;

public class Window : IWindow
{
    public void OpenWindow()
    {
        System.Console.WriteLine("Opening Window");

    }

    public void CloseWindow()
    {
        System.Console.Write("Closing Window");
    }

    public bool RunSelfTest()
    {
        return true;
    }
}