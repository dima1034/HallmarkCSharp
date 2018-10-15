using System;
using Xunit;
using HallmarkCSharp;

namespace TestCS177
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {
            /* by default class inaccessible due to protection level */
            /* watch assembly InternalVisibleTo attribute */
            var internalClassVariable = new InternalClass();
            Assert.Equal(1, 1);
        }
    }
}