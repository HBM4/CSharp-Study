namespace Ch07_P45
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 17, b = 4;
            int quotient, remainder;
            
            quotient = a / b;
            remainder = a % b;

            Console.WriteLine($"Quotient: {quotient}, Remainder: {remainder}");

            int newVar = b * quotient + remainder;
            Console.WriteLine(a == newVar ? "True" : "False");
        }
    }
}
