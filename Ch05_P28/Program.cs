using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05_P28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 2;
            b = a;
            a = -3;

            Console.WriteLine($"a = {a}, b = {b}");
        }
    }
}
