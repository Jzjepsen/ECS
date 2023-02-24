namespace ECS.Legacy;

public interface IWindow
{
    bool OpenWindow(bool open);
    bool CloseWindow();
    bool RunSelfTest();
}