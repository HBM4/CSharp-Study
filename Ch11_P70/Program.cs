namespace Ch11_P70
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the operator in English (+, -, *, /, %):");
            string op = Console.ReadLine();

            switch (op)
            {
                case "+":
                    Console.WriteLine($"{a} + {b} = {a + b:f2}");
                    break;
                case "-":
                    Console.WriteLine($"{a} - {b} = {a - b:f2}");
                    break;
                case "*":
                    Console.WriteLine($"{a} * {b} = {a * b:f2}");
                    break;
                case "/":
                    Console.WriteLine($"{a} / {b} = {a / b:f2}");
                    break;
                case "%":
                    Console.WriteLine($"{a} % {b} = {a % b:f2}");
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }

            Console.ReadKey();
        }
    }
}
