using System;
using System.Diagnostics;

namespace csharp_getting_started
{
    /*
     * To use subject class correctly please use debugger in class which creates instance of Subject
     * You probably should see additional info in debugger intellisense 
     */
    [DebuggerTypeProxy(typeof(DebuggerMemoryAttribute))]
    [DebuggerDisplay("ID = {SubjectId}, Description {SubjectDescription}")]
    public class Subject
    {
        public string SubjectId => new Random().Next().ToString();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string SubjectDescription =>
            "This object is created to describe any kind of object for testing purpose on attributes";
    }
}