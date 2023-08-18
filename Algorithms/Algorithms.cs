using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if value is less than 0</exception>
        public static int GetFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Values must be greater than 0");
            if (n == 0)
                return 1;
            int returnValue = n;
            /*
                decrement n until it reaches 1 
                each time multiply returnValue by i
                ex if n = 5 , returnValue=5 ,  i = 4 , the final iteration will look like
                returnValue*4*3*2*1
                resulting in 120
             */
            for (int i = n-1; i >0; i--)
            {
                returnValue *= i;
            }
            return returnValue;
        }

        public static string FormatSeparators(params string[] items)
        {
            //if items is a single array no list needed
            if (items.Length == 1)
                return items[0];
            return String.Join(", ", items, 0, items.Length - 1) + " and " + items[items.Length - 1];
            //return items.Take(items.Length - 1).Aggregate((a, b) => a + ", " + b) + " and " + items[items.Length-1];
            //always have an and when items is greater than 1
            //take all items except the last one ex a,b should be a; a,b,c should be a,b
            //then append final item with an and at the beggining ex a,b should be 'a and b'

        }
    }
}