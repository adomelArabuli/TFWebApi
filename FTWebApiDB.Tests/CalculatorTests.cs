using TFWebApi.Data.Model;

namespace FTWebApiDB.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_WhenGivenTwoIntegers_ReturnsSum()
        {
            // A(arrange) A(Act) A(Assert)

            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.Add(3, 5);

            //Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtract_WhenGivenTwoIntegers_ReturnsDifference()
        {
            // A(arrange) A(Act) A(Assert)

            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.Subtract(8, 5);

            //Assert
            Assert.Equal(3, result);
        }
    }
}