namespace Ch09_P56
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 1.0 + 1 + 1.0f;
            // 1.0(double) + 1(int): int인 1이 암시적으로 double로 캐스팅되어 1.0(double)이 되고, 1.0 + 1.0 = 2.0(double)
            // 2.0(double) + 1.0f(float): float인 1.0f가 암시적으로 double로 캐스팅되어 1.0(double)이 되고, 2.0 + 1.0 = 3.0(double)
            // 결과: a = 3.0 (double)
            Console.WriteLine(a);

            int x = (int)(7 + 3.0 / 4.0 * 2);
            // 3.0 / 4.0: 둘 다 double이므로 부동소수점 나누기 결과 0.75(double)
            // 0.75 * 2: int인 2가 암시적으로 double로 캐스팅되어 2.0이 되고, 0.75 * 2.0 = 1.5(double)
            // 7 + 1.5: int인 7이 암시적으로 double로 캐스팅되어 7.0이 되고, 7.0 + 1.5 = 8.5(double)
            // (int)8.5: 명시적 캐스팅으로 소수 부분을 버려 8(int)이 됨
            // 결과: x = 8 (int)
            Console.WriteLine(x);

            Console.WriteLine((1 + 1) / 2 * 3);
            // (1 + 1) = 2 (int)
            // 2 / 2: 둘 다 int이므로 정수 나누기 결과 1(int)
            // 1 * 3 = 3 (int)
            // 결과: 출력값은 3
        }
    }
}
