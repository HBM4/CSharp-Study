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
            int a = 2147483647;                           // 접미사 필요 없음: 정수 리터럴은 기본적으로 int로 처리됨
            byte b = 255;                                 // 접미사 없음: byte 전용 접미사는 없음, 범위 안이면 자동 허용
            short c = 32767;                              // 접미사 없음: short 전용 접미사는 없음, 범위 안이면 자동 허용
            long d = 9223372036854775807L;                // L 붙이기: int 범위를 넘는 long 리터럴은 L 권장/필요

            sbyte e = 127;                                // 접미사 없음: sbyte 전용 접미사는 없음, 범위 안이면 자동 허용
            ushort f = 65535;                             // 접미사 없음: ushort 전용 접미사는 없음, 범위 안이면 자동 허용
            uint g = 4294967295U;                         // U 붙이기: uint 리터럴임을 명확히 표시
            ulong h = 18446744073709551615UL;             // UL 붙이기: ulong 리터럴임을 명확히 표시

            char i = 'A';                                 // 접미사 없음: char는 작은따옴표 문자 리터럴 사용

            double j = 3.14159265358979323846;            // 접미사 필요 없음: 소수 리터럴은 기본적으로 double
            float k = 3.1415926f;                         // f 붙이기: float 리터럴은 f 또는 F 필요
            decimal l = 3.141592653589793238462643383M;   // M 붙이기: decimal 리터럴은 m 또는 M 필요

            bool m = true;                                // 접미사 없음: bool은 true/false 리터럴 사용
            string n = "Hello, World!";                   // 접미사 없음: string은 큰따옴표 문자열 리터럴 사용

            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            Console.WriteLine($"c = {c}");
            Console.WriteLine($"d = {d}");
            Console.WriteLine($"e = {e}");
            Console.WriteLine($"f = {f}");
            Console.WriteLine($"g = {g}");
            Console.WriteLine($"h = {h}");
            Console.WriteLine($"i = {i}");
            Console.WriteLine($"j = {j}");
            Console.WriteLine($"k = {k}");
            Console.WriteLine($"l = {l}");
            Console.WriteLine($"m = {m}");
            Console.WriteLine($"n = {n}");
        }
    }
}
