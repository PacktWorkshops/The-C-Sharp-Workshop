using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Common
{
    public static class ExceptionAssertions
    {
        public static async Task DoesNotThrow(this Func<Task> task)
        {
            try
            {
                await task();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        public static void DoesNotThrow(this Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}
