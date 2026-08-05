namespace Ch15_P96
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 숫자를 입력 받으면 피보나치 수열 n번째 값 출력
            Console.Write("Enter a number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(FibonacciSequence(n));
        }

        static int FibonacciSequence(int number)
        {
            if (number <= 1)
            {
                return number;
            }
            else
            {
                return FibonacciSequence(number - 1) + FibonacciSequence(number - 2);
            }
        }
    }
}
