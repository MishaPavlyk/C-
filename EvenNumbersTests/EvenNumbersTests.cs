using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class EvenNumbersTests
{
    [TestMethod]
    public void GetEvenNumbers_NormalRange_ReturnsCorrectNumbers()
    {
        List<int> expected = new List<int> { 2, 4, 6, 8, 10 };
        CollectionAssert.AreEqual(expected, Program.GetEvenNumbers(1, 10));
    }

    [TestMethod]
    public void GetEvenNumbers_ReverseRange_ReturnsSameResult()
    {
        List<int> expected = new List<int> { 2, 4, 6, 8, 10 };
        CollectionAssert.AreEqual(expected, Program.GetEvenNumbers(10, 1));
    }

    [TestMethod]
    public void GetEvenNumbers_AllOddRange_ReturnsEmptyList()
    {
        List<int> expected = new List<int>();
        CollectionAssert.AreEqual(expected, Program.GetEvenNumbers(11, 15));
    }

    [TestMethod]
    public void GetEvenNumbers_SingleEvenNumber_ReturnsSingleItem()
    {
        List<int> expected = new List<int> { 8 };
        CollectionAssert.AreEqual(expected, Program.GetEvenNumbers(7, 9));
    }

    [TestMethod]
    public void GetEvenNumbers_NegativeRange_ReturnsCorrectNumbers()
    {
        List<int> expected = new List<int> { -4, -2, 0, 2, 4 };
        CollectionAssert.AreEqual(expected, Program.GetEvenNumbers(-5, 5));
    }
}