namespace ECS.Legacy;

public interface IHeater
{
    void TurnOn();
    void TurnOff();
    bool RunSelfTest();
}