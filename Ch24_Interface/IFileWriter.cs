using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch24_Interface
{
    internal interface IFileWriter
    {
        string Extension { get; }
        void Write(string filename);
    }
}
