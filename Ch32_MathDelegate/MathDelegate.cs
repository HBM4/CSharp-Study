using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch32_MathDelegate
{
    // delegate 타입 정의도 이곳에 두는 것이 자연스럽습니다.
    public delegate int MathDelegate(int a, int b);

    public static class MathOperations
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Power(int baseNumber, int exponent)
        {
            return (int)Math.Pow(baseNumber, exponent);
        }
    }
}
