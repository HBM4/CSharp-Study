using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch23_SearchEngine
{
    internal class GoogleSearch : SearchEngine
    {
        public override string[] Search(string findThis)
        {
            return new string[]
            {
                "test1",
                "test2",
                "test3"
            };
        }
    }
}
