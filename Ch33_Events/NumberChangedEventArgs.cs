using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch33_Events
{
    internal class NumberChangedEventArgs : EventArgs
    {
        public int Original { get; }
        public int New { get; }

        public NumberChangedEventArgs(int originalValue, int newValue)
        {
            Original = originalValue;
            New = newValue;
        }
    }
}