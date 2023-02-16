namespace ECS.Legacy;

public class FakeTempSensor : ITempSensor
{
    public int GetTemp()
    {
        return 42;
    }

    public bool RunSelfTest()
    {
        return false;
    }
}