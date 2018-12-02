using System;
using System.Threading;
using System.Threading.Tasks;

namespace HallmarkCSharp
{
    public class AsyncAwaitCS122 : IGettingStartedExample
    {
        public async void Start()
        {
            await this.SharedResourcesProblem().ConfigureAwait(false);
        }
        
        int value = 0;
        async Task<int> GetNextValueAsync(int current)
        {
            await Task.Delay(10).ConfigureAwait(false);
            return ++current;
        }

        async Task UpdateValueAsync()
        {
            value = await GetNextValueAsync(value).ConfigureAwait(false);
            Console.WriteLine(value);
            Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId);
        }
        
        /* The problem is that the method reads the value and suspends itself at the await,
         and when the method resumes it assumes the value hasn’t changed. */
        async Task SharedResourcesProblem()
        {
            await UpdateValueAsync().ConfigureAwait(false);
            await UpdateValueAsync().ConfigureAwait(false);
            await UpdateValueAsync().ConfigureAwait(false);
            await UpdateValueAsync().ConfigureAwait(false);
            await UpdateValueAsync().ConfigureAwait(false);
            await UpdateValueAsync().ConfigureAwait(false);
            await UpdateValueAsync().ConfigureAwait(false);
        }
        // looks like no problem at all
    }
}