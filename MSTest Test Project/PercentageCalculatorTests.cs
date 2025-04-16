using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YourMainProjectNamespace; // Замініть на простір імен вашого основного проекту

[TestClass]
public class PercentageCalculatorTests
{
    [TestMethod]
    public void CalculatePercentage_10PercentOf90_Returns9()
    {
        // Arrange
        double number = 90;
        double percent = 10;
        double expected = 9;

        // Act
        double actual = Program.CalculatePercentage(number, percent);

        // Assert
        Assert.AreEqual(expected, actual, 0.001, "10% від 90 має бути 9");
    }

    [TestMethod]
    public void CalculatePercentage_50PercentOf200_Returns100()
    {
        // Arrange
        double number = 200;
        double percent = 50;
        double expected = 100;

        // Act
        double actual = Program.CalculatePercentage(number, percent);

        // Assert
        Assert.AreEqual(expected, actual, 0.001, "50% від 200 має бути 100");
    }

    [TestMethod]
    public void CalculatePercentage_0PercentOf100_Returns0()
    {
        // Arrange
        double number = 100;
        double percent = 0;
        double expected = 0;

        // Act
        double actual = Program.CalculatePercentage(number, percent);

        // Assert
        Assert.AreEqual(expected, actual, 0.001, "0% від будь-якого числа має бути 0");
    }

    [TestMethod]
    public void CalculatePercentage_100PercentOf50_Returns50()
    {
        // Arrange
        double number = 50;
        double percent = 100;
        double expected = 50;

        // Act
        double actual = Program.CalculatePercentage(number, percent);

        // Assert
        Assert.AreEqual(expected, actual, 0.001, "100% від числа має дорівнювати самому числу");
    }

    [TestMethod]
    public void CalculatePercentage_25PercentOfNegative40_ReturnsNegative10()
    {
        // Arrange
        double number = -40;
        double percent = 25;
        double expected = -10;

        // Act
        double actual = Program.CalculatePercentage(number, percent);

        // Assert
        Assert.AreEqual(expected, actual, 0.001, "25% від -40 має бути -10");
    }
}