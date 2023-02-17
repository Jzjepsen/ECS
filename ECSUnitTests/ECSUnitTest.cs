using ECS.Legacy;

namespace ECSUnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ECSUnitTest
{
    private ECS.Legacy.ECS _uutEcs;
    private FakeTempSensor _fakeTempSensor;
    private FakeHeater _fakeHeater;
    private FakeWindow _fakeWindow;

    [SetUp]
    public void Setup()
    {
        /* _fakeTempSensor = new FakeTempSensor();
        _fakeHeater = new FakeHeater();
        _uutEcs = new ECS.Legacy.ECS(23,_fakeTempSensor, _fakeHeater);
        */
    }

    [TestCase(10, true)]
    [TestCase(-5, true)]
    [TestCase(25, false)]
    public void TestRegulateTurnOn(int thres, bool result)
    {
        //arrange
        _uutEcs = new ECS.Legacy.ECS(thres, new FakeTempSensor(), new FakeHeater(), new FakeWindow());
        _fakeHeater._heating = !result;
        //act
        _uutEcs.Regulate();
        //assert
        Assert.That(_fakeHeater._heating, Is.EqualTo(result));

    }

    [TestCase(10, false)]
    [TestCase(-5, false)]
    [TestCase(25, true)]
    public void TestRegulateTurnOff(int thres, bool result)
    {
        //arrange
        _uutEcs = new ECS.Legacy.ECS(thres, new FakeTempSensor(), new FakeHeater(), new FakeWindow());
        _fakeHeater._heating = !result;
        //act
        _uutEcs.Regulate();
        //assert
        Assert.That(_fakeHeater._heating, Is.EqualTo(result));
    }

    [TestCase(20, 20)]
    [TestCase(21, 21)]
    [TestCase(22, 22)]
    public void TestSetThreshold(int thres, int result)
    {
        //arrange
        _uutEcs = new ECS.Legacy.ECS(thres, new FakeTempSensor(), new FakeHeater(), new FakeWindow());
        _uutEcs._threshold = 0;
        //act
        _uutEcs.SetThreshold(thres);
        //assert
        Assert.That(_uutEcs._threshold, Is.EqualTo(result));

    }

    [TestCase(20, 20)]
    [TestCase(21, 21)]
    [TestCase(22, 22)]
    public void TestGetThreshold(int thres, int result)
    {
        //arrange
        _uutEcs = new ECS.Legacy.ECS(thres, new FakeTempSensor(), new FakeHeater(), new FakeWindow());
        _uutEcs._threshold = thres;
        //act
        _uutEcs.GetThreshold();
        //assert
        Assert.That(_uutEcs.GetThreshold(), Is.EqualTo(result));
    }

    [Test]
    public void TestGetCurTemp()
    {
        Assert.That(_fakeTempSensor.GetTemp(), Is.EqualTo(42));
    }

    [TestCase(25, true)]
    [TestCase(-2, false)]
    [TestCase(5, false)]
    public void TestRegulateOpenWindow(int thres, bool result)
    {
        //arrange
        _uutEcs = new ECS.Legacy.ECS(thres, new FakeTempSensor(), new FakeHeater(), new FakeWindow());
        _fakeWindow._windowOpen != result;
        //act
        _uutEcs.Regulate();
        //assert
        Assert.That(_fakeWindow._windowOpen, Is.EqualTo(result));
    }

    [TestCase(25, false)]
    [TestCase(-2, true)]
    [TestCase(5, true)]
    public void TestRegulateClose(int thres, bool result)
    {
        //arrange
        _uutEcs = new ECS.Legacy.ECS(thres, new FakeTempSensor(), new FakeHeater(), new FakeWindow());
        _fakeWindow._windowOpen != result;
        //act
        _uutEcs.Regulate();
        //assert
        Assert.That(_fakeWindow._windowOpen, Is.EqualTo(result));
    }
}
