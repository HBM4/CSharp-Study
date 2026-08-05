namespace Ch13_P82
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
            int currentMinimum = Int32.MaxValue;
            int currentMaximum = Int32.MinValue;
            double total = 0;

            foreach(int number in array)
            {
                if (number < currentMinimum)
                    currentMinimum = number;

                if (number > currentMaximum)
                    currentMaximum = number;

                total += number;
            }

            Console.WriteLine($"Minimum: {currentMinimum}");
            Console.WriteLine($"Maximum: {currentMaximum}");
            Console.WriteLine($"Mean: {total / array.Length:f2}");
        }
    }
}
