using System.Threading;

namespace ECS.Legacy;

public class FakeWindow : IWindow
{         
    public bool _windowOpen;
    public void OpenWindow()                                    
    {                                                           
        System.Console.WriteLine("Opening Window");
        _windowOpen = true;
    }                                                           
                                                                    
    public void CloseWindow()                                       
    {                                                               
        System.Console.Write("Closing Window");
        _windowOpen = false;
    }                                                               
                                                                    
    public bool RunSelfTest()                                       
    {                                                               
        return true;                                                
    }                                                               
}                                                                   