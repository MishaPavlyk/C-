using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class NumberSwapperTests
{
    [TestMethod]
    public void SwapPositions_SwapFirstAndLast_ReturnsCorrectNumber()
    {
        // Arrange
        string number = "723895";
        int pos1 = 1;
        int pos2 = 6;
        string expected = "523897";

        // Act
        char[] digits = number.ToCharArray();
        char temp = digits[pos1 - 1];
        digits[pos1 - 1] = digits[pos2 - 1];
        digits[pos2 - 1] = temp;
        string actual = new string(digits);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SwapPositions_SwapMiddleDigits_ReturnsCorrectNumber()
    {
        string number = "123456";
        string expected = "126453";

        char[] digits = number.ToCharArray();
        char temp = digits[2];  // 3rd digit (index 2)
        digits[2] = digits[4];   // 5th digit (index 4)
        digits[4] = temp;
        string actual = new string(digits);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SwapPositions_SwapSamePositions_ReturnsOriginalNumber()
    {
        string number = "987654";
        string expected = "987654";

        char[] digits = number.ToCharArray();
        char temp = digits[3];  // 4th digit
        digits[3] = digits[3];  // Same position
        digits[3] = temp;
        string actual = new string(digits);

        Assert.AreEqual(expected, actual);
    }
}