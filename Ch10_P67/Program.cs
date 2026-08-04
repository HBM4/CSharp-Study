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

            // 출력: 곱셈 결과가 양수인지 음수인지 여부
            // 둘다 양수이거나, 둘다 음수일 경우 양수이다.
            bool isPositive = (num1 > 0 && num2 > 0) || (num1 < 0 && num2 < 0);
            Console.WriteLine(isPositive);
        }
    }
}