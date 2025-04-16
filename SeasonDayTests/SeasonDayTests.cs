using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class SeasonDayTests
{
    [TestMethod]
    public void TestSeasonCalculation()
    {
        // Winter dates
        Assert.AreEqual("Winter", Program.CalculateSeason(new DateTime(2023, 12, 22)));
        Assert.AreEqual("Winter", Program.CalculateSeason(new DateTime(2023, 1, 1)));

        // Spring dates
        Assert.AreEqual("Spring", Program.CalculateSeason(new DateTime(2023, 4, 1)));

        // Summer dates
        Assert.AreEqual("Summer", Program.CalculateSeason(new DateTime(2023, 7, 1)));

        // Autumn dates
        Assert.AreEqual("Autumn", Program.CalculateSeason(new DateTime(2023, 10, 1)));
    }

    [TestMethod]
    public void TestDateValidation()
    {
        Assert.IsTrue(Program.IsValidDate("22.12.2021", out _));
        Assert.IsFalse(Program.IsValidDate("32.12.2021", out _)); // Invalid day
        Assert.IsFalse(Program.IsValidDate("22.13.2021", out _)); // Invalid month
        Assert.IsFalse(Program.IsValidDate("22/12/2021", out _)); // Wrong format
    }

    [TestMethod]
    public void TestFullDateInfo()
    {
        var (season, day) = Program.GetDateInfo(new DateTime(2021, 12, 22));
        Assert.AreEqual("Winter", season);
        Assert.AreEqual("Wednesday", day);
    }
}