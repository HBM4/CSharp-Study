namespace Ch17_P110
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = 0;

            while (n > 0)
            {
                sum += RandomNumber();
                n--;
            }

            Console.WriteLine(sum);
        }

        static int RandomNumber()
        {
            Random random = new Random();

            return random.Next(6) + 1;
        }
    }
}
