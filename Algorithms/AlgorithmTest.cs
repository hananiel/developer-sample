using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(6, 3)]
        [InlineData(24, 4)]
        [InlineData(120, 5)]
        [InlineData(3628800, 10)]

        public void CanGetFactorial(int expected,int factorial)
        {
            Assert.Equal(expected, Algorithms.GetFactorial(factorial));

        }

        [Fact]
        public void NegativeFactorial()
        {
            Assert.Throws<ArgumentException>(()=> Algorithms.GetFactorial(-5));
           
        }
        [Theory]
        [InlineData("a", new string[] {"a" })]
        [InlineData("a and b", new string[] { "a", "b" })]
        [InlineData("a, b and c", new string[] { "a", "b", "c" })]
        [InlineData("a, b, c and d", new string[] { "a", "b", "c", "d" })]
        public void CanFormatSeparators(string output, string[] input)
        {
            Assert.Equal(output, Algorithms.FormatSeparators(input));

        }
    }
}