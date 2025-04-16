using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ArmstrongNumberTests
{
    [TestMethod]
    public void TestSingleDigitNumbers()
    {
        Assert.IsTrue(ArmstrongNumberChecker.IsArmstrongNumber(0));
        Assert.IsTrue(ArmstrongNumberChecker.IsArmstrongNumber(1));
        Assert.IsTrue(ArmstrongNumberChecker.IsArmstrongNumber(9));
    }

    [TestMethod]
    public void TestKnownArmstrongNumbers()
    {
        Assert.IsTrue(ArmstrongNumberChecker.IsArmstrongNumber(153));  // 1? + 5? + 3? = 153
        Assert.IsTrue(ArmstrongNumberChecker.IsArmstrongNumber(370));  // 3? + 7? + 0? = 370
        Assert.IsTrue(ArmstrongNumberChecker.IsArmstrongNumber(371));  // 3? + 7? + 1? = 371
        Assert.IsTrue(ArmstrongNumberChecker.IsArmstrongNumber(407));  // 4? + 0? + 7? = 407
        Assert.IsTrue(ArmstrongNumberChecker.IsArmstrongNumber(1634)); // 1? + 6? + 3? + 4? = 1634
    }

    [TestMethod]
    public void TestNonArmstrongNumbers()
    {
        Assert.IsFalse(ArmstrongNumberChecker.IsArmstrongNumber(10));
        Assert.IsFalse(ArmstrongNumberChecker.IsArmstrongNumber(123));
        Assert.IsFalse(ArmstrongNumberChecker.IsArmstrongNumber(200));
        Assert.IsFalse(ArmstrongNumberChecker.IsArmstrongNumber(9474)); // 9474 is actually Armstrong (for 4 digits)
    }

    [TestMethod]
    public void TestNegativeNumber()
    {
        Assert.IsFalse(ArmstrongNumberChecker.IsArmstrongNumber(-153));
    }
}