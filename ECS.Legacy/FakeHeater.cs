namespace ECS.Legacy;

public class FakeHeater : IHeater
{
    public void TurnOn()
    {
    }

    public void TurnOff()
    {
    }

    public bool RunSelfTest()
    {
        return false;
    }
}