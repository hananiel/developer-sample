using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
         
            // Test range of int
            int[] fact = {1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600};
            for (int i = 0; i < fact.Length; i++)
            {
                Assert.Equal(fact[i], Algorithms.GetFactorial(i));
            }

        }

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
            Assert.Equal("", Algorithms.FormatSeparators(null));
            Assert.Equal("a", Algorithms.FormatSeparators("a"));

            Assert.Equal("a, b, c, e, f and g", Algorithms.FormatSeparators("a", "b", "c", "e", "f", "g"));

        }
    }
}