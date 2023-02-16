namespace ECS.Legacy;

public class FakeTempSensor : ITempSensor
{
    public int GetTemp()
    {
        return 20;
    }

    public bool RunSelfTest()
    {
        return true;
    }
}