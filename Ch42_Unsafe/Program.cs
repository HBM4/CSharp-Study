using System.Runtime.CompilerServices;

namespace Ch42_Unsafe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point();

            unsafe
            {
                // fixed 문으로 p.X의 주소를 얻는 동안
                // 가비지 컬렉터가 p 객체를 이동시키지 못하도록 고정합니다.
                fixed (double* x = &p.X)
                {
                    (*x)++;
                }
                // fixed 블록이 끝나면, 포인터 변수는 더 이상 유효하지 않으며, 가비지 컬렉터가 p 객체를 이동시킬 수 있게 됩니다.
            }

            Console.WriteLine(p.X); // 1

            unsafe
            {
                S s = new S();
                Console.WriteLine(sizeof(S)); // 48

                s.MoreValues[0] = 100;
                Console.WriteLine(s.MoreValues[0]); // 100
            }
        }

        public unsafe void UnsafeMethod()
        {
            int* numbers = stackalloc int[10]; // C#은 stackalloc 키워드로 배열을 스택에 강제 할당할 수 있습니다.
            // stackalloc은 지역 변수에만 사용 가능하며, unsafe 컨텍스트에서만 사용할 수 있습니다.
            // 메서드가 종료되면, 스택에 할당된 메모리는 자동으로 해제됩니다.
        }
    }

    public class Point
    {
        public double X;
        public double Y;
    }

    // 고정 크기 배열(Fixed Size Arrays)은 구조체 안에서만 선언할 수 있으며, unsafe가 필요하다.
    public unsafe struct S
    {
        public int Value1; // 4바이트
        public int Value2; // 4바이트
        public fixed int MoreValues[10]; // 4 * 10 = 40바이트
    }
}
