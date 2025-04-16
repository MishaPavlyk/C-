using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TemperatureConverterTests
{
    [TestMethod]
    public void FahrenheitToCelsius_FreezingPoint_Returns0()
    {
        double result = TemperatureConverter.FahrenheitToCelsius(32);
        Assert.AreEqual(0, result, 0.001);
    }

    [TestMethod]
    public void CelsiusToFahrenheit_FreezingPoint_Returns32()
    {
        double result = TemperatureConverter.CelsiusToFahrenheit(0);
        Assert.AreEqual(32, result, 0.001);
    }

    [TestMethod]
    public void FahrenheitToCelsius_BodyTemp_Returns37()
    {
        double result = TemperatureConverter.FahrenheitToCelsius(98.6);
        Assert.AreEqual(37, result, 0.1);
    }

    [TestMethod]
    public void CelsiusToFahrenheit_BoilingPoint_Returns212()
    {
        double result = TemperatureConverter.CelsiusToFahrenheit(100);
        Assert.AreEqual(212, result, 0.001);
    }
}