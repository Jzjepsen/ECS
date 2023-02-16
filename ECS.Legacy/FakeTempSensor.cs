namespace ECS.Legacy;

public class FakeTempSensor : ITempSensor
{
    public int _temperature;

    public int GetTemp()
    {
        return _temperature;
    }

    public bool RunSelfTest()
    {
        return true;
    }
}