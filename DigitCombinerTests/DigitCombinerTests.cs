using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YourMainNamespace; // Замініть на простір імен вашого проекту

[TestClass]
public class DigitCombinerTests
{
    [TestMethod]
    public void CombineDigits_1578_Returns1578()
    {
        // Arrange
        int expected = 1578;

        // Act
        int actual = Program.CombineDigits(1, 5, 7, 8);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void CombineDigits_0000_Returns0()
    {
        Assert.AreEqual(0, Program.CombineDigits(0, 0, 0, 0));
    }

    [TestMethod]
    public void CombineDigits_9999_Returns9999()
    {
        Assert.AreEqual(9999, Program.CombineDigits(9, 9, 9, 9));
    }

    [TestMethod]
    public void CombineDigits_1234_Returns1234()
    {
        Assert.AreEqual(1234, Program.CombineDigits(1, 2, 3, 4));
    }

    [TestMethod]
    public void CombineDigits_5678_Returns5678()
    {
        Assert.AreEqual(5678, Program.CombineDigits(5, 6, 7, 8));
    }
}