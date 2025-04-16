using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PerfectNumberTests
{
    [TestMethod]
    public void TestKnownPerfectNumbers()
    {
        Assert.IsTrue(PerfectNumberChecker.IsPerfectNumber(6));     // 1 + 2 + 3 = 6
        Assert.IsTrue(PerfectNumberChecker.IsPerfectNumber(28));    // 1 + 2 + 4 + 7 + 14 = 28
        Assert.IsTrue(PerfectNumberChecker.IsPerfectNumber(496));   // 1 + 2 + 4 + 8 + 16 + 31 + 62 + 124 + 248 = 496
        Assert.IsTrue(PerfectNumberChecker.IsPerfectNumber(8128));  // Large known perfect number
    }

    [TestMethod]
    public void TestNonPerfectNumbers()
    {
        Assert.IsFalse(PerfectNumberChecker.IsPerfectNumber(5));
        Assert.IsFalse(PerfectNumberChecker.IsPerfectNumber(12));
        Assert.IsFalse(PerfectNumberChecker.IsPerfectNumber(27));
        Assert.IsFalse(PerfectNumberChecker.IsPerfectNumber(100));
    }

    [TestMethod]
    public void TestEdgeCases()
    {
        Assert.IsFalse(PerfectNumberChecker.IsPerfectNumber(0));
        Assert.IsFalse(PerfectNumberChecker.IsPerfectNumber(1));
        Assert.IsFalse(PerfectNumberChecker.IsPerfectNumber(-6));
    }
}