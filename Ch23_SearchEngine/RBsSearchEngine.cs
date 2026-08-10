using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch23_SearchEngine
{
    internal class RBsSearchEngine : SearchEngine
    {
        public override string[] Search(string findThis)
        {
            return new string[]
            {
                "find this",
                "hello"
            };
        }
    }
}
