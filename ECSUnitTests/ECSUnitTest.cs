using ECS.Legacy;

namespace ECSUnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

public class ECSUnitTest
{
    private ECS.Legacy.ECS _uutEcs;
    private ITempSensor _tempSensor;
    private IHeater _heater;
    private IWindow _window;

    [SetUp]
    public void Setup()
    {
        _tempSensor = Substitute.For<ITempSensor>();
        _heater = Substitute.For<IHeater>();
        _window = Substitute.For<IWindow>();
        _uutEcs = new ECS.Legacy.ECS(23, _tempSensor, _heater, _window);
    }

    // interaction based test -> mock
    [TestCase(10, true)]
    [TestCase(-5, true)]
    [TestCase(25, false)]
    public void TestRegulateTurnOnHeater(int temp, bool result)
    {
        //Arrange
        _tempSensor.GetTemp().Returns(temp);
        _heater.TurnOn().Returns(result);

        //Act
        _uutEcs.Regulate();

        //Assert
        Assert.That(_heater.TurnOn(), Is.EqualTo(result));
    }

    // interaction based test -> mock
    [TestCase(10, false)]
    [TestCase(-5, false)]
    [TestCase(25, true)]
    public void TestRegulateTurnOffHeater(int temp, bool result)
    {
        //Arrange
        _tempSensor.GetTemp().Returns(temp);
        _heater.TurnOff().Returns(result);

        //Act
        _uutEcs.Regulate();

        //Assert
        Assert.That(_heater.TurnOff(), Is.EqualTo(result));
    }

    // value based test 
    [TestCase(20)]
    [TestCase(21)]
    [TestCase(22)]
    public void TestSetThreshold(int threshold)
    {
        //Arrange
        _uutEcs._threshold = 0;

        //Act
        _uutEcs.SetThreshold(threshold);

        //Assert
        Assert.That(_uutEcs._threshold, Is.EqualTo(threshold));

    }

    // value based test
    [TestCase(20)]
    [TestCase(21)]
    [TestCase(22)]
    public void TestGetThreshold(int threshold)
    {
        //arrange
        _uutEcs._threshold = threshold;
        //act
        _uutEcs.GetThreshold();
        //assert
        Assert.That(_uutEcs.GetThreshold(), Is.EqualTo(threshold));
    }

    // Value based test
    [TestCase(25, 25)]
    [TestCase(-5, -5)]
    public void TestGetCurTemp(int temp, int result)
    {
        //Arrange
        _tempSensor.GetTemp().Returns(temp);

        //Act

        //Assert
        Assert.That(_tempSensor.GetTemp(), Is.EqualTo(result));

    }

    // interaction based test -> mock with argument matching,
    // notice that this creates the need for an argument in
    // the method OpenWindow() in Window.cs (and the interface of course)
    [TestCase(25, true)]
    [TestCase(-2, false)]
    [TestCase(5, false)]
    public void TestRegulateOpenWindow(int temp, bool result)
    {
        //Arrange
        _tempSensor.GetTemp().Returns(temp);
        _window.OpenWindow(Arg.Any<bool>()).Returns(!result);

        //Act
        _uutEcs.Regulate();

        //Assert
        _window.Received(1).OpenWindow(Arg.Is<bool>(x => x == result));

    }

    // interaction based test -> mock without argument matching
    [TestCase(25, false)]
    [TestCase(-2, true)]
    [TestCase(5, true)]
    public void TestRegulateCloseWindow(int temp, bool result)
    {
        //Arrange
        _tempSensor.GetTemp().Returns(temp);
        _window.CloseWindow().Returns(result);

        //Act
        _uutEcs.Regulate();

        //Assert
        Assert.That(_window.CloseWindow(), Is.EqualTo(result));
    }

    public void TestRunSelfTest()
    {
        //Arrange
        _uutEcs.RunSelfTest().Returns(true);

        //Act
        _uutEcs.RunSelfTest();

        //Assert
        Assert.That(_uutEcs.RunSelfTest, Is.True);
    }
}