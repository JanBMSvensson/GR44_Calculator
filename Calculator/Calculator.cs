using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GR44_Calculator.Tests")]

namespace GR44_Calculator
{
    internal static class Calculator
    {
        internal static decimal Add(decimal startValue, decimal addValue) => startValue + addValue;
        internal static decimal Add(decimal startValue, params decimal[] addValues) => startValue + addValues.Sum();
        internal static decimal Subtract(decimal startValue, decimal subtractValue) => startValue - subtractValue;
        internal static decimal Subtract(decimal startValue, params decimal[] subtractValues) => startValue - subtractValues.Aggregate((decimal val1, decimal val2) => val1 - val2);
        internal static decimal Multiply(decimal startValue, decimal multiplyValue) => startValue * multiplyValue;
        internal static decimal Multiply(decimal startValue, params decimal[] multiplyValues) => startValue * multiplyValues.Aggregate((decimal val1, decimal val2) => val1 * val2);
        internal static decimal Divide(decimal startValue, decimal divideValue) => divideValue==0 ? throw new DivideByZeroException() : startValue / divideValue;
        internal static decimal Divide(decimal startValue, params decimal[] divideValues) => startValue / divideValues.Aggregate((decimal val1, decimal val2) => val2 == 0m ? throw new DivideByZeroException() : val1 * val2);

    }
}
