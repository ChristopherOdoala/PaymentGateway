using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Payment.Test
{
    public class BaseClassTest
    {
        protected readonly ITestOutputHelper _output;

        public BaseClassTest(ITestOutputHelper output)
        {
            _output = output;
        }

    }
}
