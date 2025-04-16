using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzz; // якщо ваш основний проект маЇ ≥нший namespace - зм≥н≥ть це

namespace FizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void NumberDivisibleBy3_ReturnsFizz()
        {
            // Arrange
            int number = 9;

            // Act
            string result = Program.GetFizzBuzzOutput(number); // «верн≥ть увагу на "Program"

            // Assert
            Assert.AreEqual("Fizz", result);
        }

        [TestMethod]
        public void NumberDivisibleBy5_ReturnsBuzz()
        {
            int number = 10;
            string result = Program.GetFizzBuzzOutput(number);
            Assert.AreEqual("Buzz", result);
        }

        [TestMethod]
        public void NumberDivisibleBy3And5_ReturnsFizzBuzz()
        {
            int number = 15;
            string result = Program.GetFizzBuzzOutput(number);
            Assert.AreEqual("Fizz Buzz", result);
        }

        [TestMethod]
        public void NumberNotDivisibleBy3Or5_ReturnsNumber()
        {
            int number = 7;
            string result = Program.GetFizzBuzzOutput(number);
            Assert.AreEqual("7", result);
        }
    }
}