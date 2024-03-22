using NUnit.Framework;
using System.Security.AccessControl;
using CalculatorApi;
using Moq;

namespace CalculatorTests
{
    [TestFixture]
    public class CalcEquationTests
    {
        [Test]
        public void AdditionOfTwoPositiveNumbers()
        {
            //Arrange
            int numOne = 10;
            int numTwo = 20;
            Calculator calc = new Calculator();
             
            //Act
            int expectedValue = 30;
            int actualValue = calc.Add(numOne, numTwo);

            //Assert
            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }

        [Test]
        public void AdditionOfTwoNegativeNumbers()
        {
            //Arrange
            int numOne = -10;
            int numTwo = -20;
            Calculator calc = new Calculator();

            //Act
            int expectedValue = -30;
            int actualValue = calc.Add(numOne, numTwo);

            //Assert
            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }

        [Test]
        public void SubtractionOfTwoNumbers()
        {
            //Arrange
            int numOne = 10;
            int numTwo = 5;
            Calculator calc = new Calculator();

            //Act
            int expectedValue = 5;
            int actualValue = calc.Subtract(numOne, numTwo);

            //Assert
            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }

        [Test]
        public void MultiplicationOfTwoNumbers()
        {
            //Arrange
            int numOne = 5;
            int numTwo = 5;
            Calculator calc = new Calculator();

            //Act
            int expectedValue = 25;
            int actualValue = calc.Multiply(numOne, numTwo);

            //Assert
            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }

        [Test]
        public void DivisionOfTwoNumbers()
        {
            //Arrange
            int numOne = 5;
            int numTwo = 5;
            Calculator calc = new Calculator();

            //Act
            int expectedValue = 1;
            int actualValue = calc.Divide(numOne, numTwo);

            //Assert
            Assert.That(expectedValue, Is.EqualTo(actualValue));
        }

        [Test]
        public void TestingDiagnosticsInterfaceWithAddition()
        {
            var mockDiagnostics = new Mock<IDiagnostics>();
            var underTest = new Calculator(mockDiagnostics.Object);

            int a = 5;
            int b = 5;

            int expectedValue = a + b;
            int actualValue = underTest.Add(a, b);

            Assert.That(expectedValue, Is.EqualTo(actualValue));
            mockDiagnostics.Verify(d => d.Log($"Successfully added: {a} and {b}"), Times.Once);
        }
    }
}
