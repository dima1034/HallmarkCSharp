using System;

namespace HallmarkCSharp
{
    /*
     * Lesson here - is how stack_trace may be differ for throw and throw(ex)
     *
     * 1. The Throw method throws the current exception and didn't change stack_trace
     * 
     * 2. The Throw(ex) method will reset your stack trace so the error will appear from the line where Throw(ex) is written
     *
     * Since Throw does not reset the stack trace, you will get the information about the original exception. 
     * 
     */
    public static class ThrowVsThrowEx
    {
        private static void DevideByZero(int i)
        {
            int j = 0;
            int k = i / j;
            Console.WriteLine(k);
        }

        public static void Start()
        {
            try
            {
                DevideByZero(10);
            }
            catch (Exception exception)
            {
                // throw;
                // or
                // throw exception; /* exception rethrow possibly intendeds */
            }
        }
    }
}