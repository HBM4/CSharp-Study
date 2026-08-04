namespace Ch10_P65
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number:");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(number%2 == 0);
        }
    }
}
