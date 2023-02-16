namespace ECS.Legacy;

public class FakeHeater : IHeater
{
    public bool _heating;
    public void TurnOn()
    {
        _heating = true;
    }

    public void TurnOff()
    {
        _heating = false;
    }

    public bool RunSelfTest()
    {
        return true;
    }
}