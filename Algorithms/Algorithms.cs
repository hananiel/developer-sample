using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
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

        public static string FormatSeparators(params string[] items) => throw new NotImplementedException();
    }
}