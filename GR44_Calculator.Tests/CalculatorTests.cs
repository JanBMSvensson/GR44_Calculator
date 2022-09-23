namespace GR44_Calculator.Tests
{
    public class CalculatorTests 
    {
        
        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(3.5)]
        public void AddTwoValues(decimal testValue)
        {
            decimal fixedDecimal = 10;
            Assert.Equal(fixedDecimal + testValue, Calculator.Add(fixedDecimal, testValue));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(3.5)]
        public void SubtractTwoValues(decimal testValue)
        {
            decimal fixedDecimal = 10;
            Assert.Equal(fixedDecimal - testValue, Calculator.Subtract(fixedDecimal, testValue));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(3.5)]
        public void MultiplyTwoValues(decimal testValue)
        {
            decimal fixedDecimal = 10;
            Assert.Equal(fixedDecimal * testValue, Calculator.Multiply(fixedDecimal, testValue));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(3.5)]
        public void DivideTwoValues(decimal testValue)
        {
            decimal fixedDecimal = 10;
            Assert.Equal(fixedDecimal / testValue, Calculator.Divide(fixedDecimal, testValue));
        }

    }
}