using System;

namespace HallmarkCSharp
{
    public class DebuggerMemoryAttribute
    {
        private Subject _subject;

        public DebuggerMemoryAttribute(Subject subject)
        {
            this._subject = subject;
        }

        public string MemoryAddressString => GetMemoryAddressString();
        public IntPtr MemoryAddress => GetMemoryAddress();

        string GetMemoryAddressString()
        {
            string localMemoryAddressString = "";
            this.GetMemoryAddress(ref localMemoryAddressString);
            return localMemoryAddressString;
        }
        
        IntPtr GetMemoryAddress()
        {
            IntPtr ptr = new IntPtr();
            this.GetMemoryAddress(ref ptr);
            return ptr;
        }
        
        private unsafe void GetMemoryAddress(ref string data)
        {
             object o = new object();
             TypedReference tr = __makeref(o);
             IntPtr ptr = **(IntPtr**) (&tr);
             data = ptr.ToString();
        }
        
        private unsafe void GetMemoryAddress(ref IntPtr ptr)
        {
            object o = new object();
            TypedReference tr = __makeref(o);
            ptr = **(IntPtr**) (&tr);
        }
    }
}