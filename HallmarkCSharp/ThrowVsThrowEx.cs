using System;

namespace csharp_getting_started
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
<<<<<<< HEAD:csharp-getting-started/ThrowVsThrowEx.cs
    public static class ThrowVsThrowEx
=======
    public class throw_vs_throwEx : IGettingStartedExample
>>>>>>> work items:csharp-getting-started/throw_vs_throwEx.cs
    {
        private static void DevideByZero(int i)
        {
            int j = 0;
            int k = i / j;
            Console.WriteLine(k);
        }

        public void Start()
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