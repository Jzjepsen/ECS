using System;

namespace ECS.Legacy
{
    public class ECS
    {
        public int _threshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        private readonly IWindow _window;

        public ECS(int thr, ITempSensor tempSensor, IHeater heater, IWindow window)
        {
            SetThreshold(thr);
            _tempSensor = tempSensor;
            _heater = heater;
            _window = window;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            Console.WriteLine($"Temperature measured was {t}");
            if (t < _threshold)
            {
                _heater.TurnOn();
                _window.CloseWindow();
            }
            else
            {
                _heater.TurnOff();
                _window.OpenWindow();
            }
        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
