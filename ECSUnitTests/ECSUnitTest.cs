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
    
    [SetUp]
    public void Setup()
    {
         _fakeTempSensor = new FakeTempSensor();
         _fakeHeater = new FakeHeater();
         _uutEcs = new ECS.Legacy.ECS(23,_fakeTempSensor, _fakeHeater);
    }
    
    [Test]
    public void TestRegulateTurnOn()
    {
        //arrange
        _fakeTempSensor._temperature = 15;
        _fakeHeater._heating = false;
        //act
        _uutEcs.Regulate();
        //assert
        Assert.That(_fakeHeater._heating,Is.True);
    }
    
    [Test]
    public void TestRegulateTurnOff()
    {
        //arrange
        _fakeTempSensor._temperature = 28;
        _fakeHeater._heating = false;
        //act
        _uutEcs.Regulate();
        // assert
        Assert.That(_fakeHeater._heating,Is.False);
    }
    
    //[TestCase(20)]
    //[TestCase(21)]
    //[TestCase(22)]

    [Test]
    public void TestSetThreshold()
    {
        //arrange
        _uutEcs._threshold = 0;
        //act
        _uutEcs.SetThreshold(21);
        //assert
        Assert.That(_uutEcs._threshold,Is.EqualTo(21));
        // Assert.That(_uutEcs._threshold,Is.EqualTo(21));
        //Assert.That(_uutEcs._threshold,Is.EqualTo(22));
    }

    [Test]
    public void TestGetThreshold()
    {
        //arrange
        _uutEcs.GetThreshold();
        //act
        _uutEcs._threshold = 20;
        Assert.That(_uutEcs.GetThreshold(), Is.EqualTo(20));
    }
    
    [Test]
    public void TestGetCurTemp()
    {
        //arrange
        _fakeTempSensor._temperature = 42;
        //act
        _fakeTempSensor.GetTemp();
        //assert
        Assert.That(_fakeTempSensor._temperature, Is.EqualTo(42));
    }
}