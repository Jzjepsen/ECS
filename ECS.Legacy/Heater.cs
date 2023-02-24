namespace ECS.Legacy
{
    public class Heater : IHeater
    {
        public bool _heating = false;
        public bool TurnOn()
        {
            System.Console.WriteLine("Heater is on");
            return true;

        }

        public bool TurnOff()
        {
            System.Console.WriteLine("Heater is off");
           return false;

        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}