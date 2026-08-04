namespace Ch12_P76_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = 5;

            for (int i = 1; i <= row; i++)
            {
                for (int j = 0; j < row - i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k < i * 2 - 1; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
