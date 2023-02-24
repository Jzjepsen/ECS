namespace ECS.Legacy;

public interface IHeater
{
    bool TurnOn();
    bool TurnOff();
    bool RunSelfTest();
}