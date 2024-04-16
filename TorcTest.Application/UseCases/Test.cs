using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorcTest.Application.UseCases
{
    public interface TestIn
    {
        string TestString();
    }

    public class Test: TestIn
    {
        public Test()
        {
                
        }

        public string TestString()
        {
            return "hello app";
        }
    }
}
