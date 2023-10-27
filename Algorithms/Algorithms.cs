using System;
using System.Linq;
using System.Text;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            int result = 1;

            for(int i = 2 ; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            if(items == null || items.Length == 0)
            {
                return string.Empty;
            }
            
            if(items.Length < 2)
            {
                return items[0];
            }

            var firstNItems = items.Take(items.Length - 1);

            StringBuilder stringBuilder = new StringBuilder(string.Join(", ", firstNItems));
            stringBuilder.Append($" and {items[items.Length - 1]}");

            return stringBuilder.ToString();
        }
    }
}