namespace Ch10_P67
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 입력: 2개의 double 형 변수
            Console.WriteLine("Enter first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            // 곱셈 결과가 양수이면 true (둘 다 양수 또는 둘 다 음수)
            bool isPositive = num1 * num2 > 0;
            Console.WriteLine(isPositive);
        }
    }
}