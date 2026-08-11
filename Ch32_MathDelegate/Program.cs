using System;

namespace Ch32_MathDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MathDelegate mathOperation = MathOperations.Add;

            int a = 5;
            int b = 7;

            int result = mathOperation(a, b);
            Console.WriteLine(result);
        }
    }
}
