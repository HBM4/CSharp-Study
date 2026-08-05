namespace Ch14_P85
{
    enum Month { January, February, March, April, May, June, July, August, September, October, November, December };

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a month number (1-12):");
            int inputMonth = Convert.ToInt32(Console.ReadLine());

            if (inputMonth < 1 || inputMonth > 12)
            {
                Console.WriteLine("Invalid month number. Please enter a number between 1 and 12.");
                return;
            }

            Month month = (Month)(inputMonth - 1);

            switch (month)
            {
                case Month.January:
                    Console.WriteLine("January");
                    break;
                case Month.February:
                    Console.WriteLine("February");
                    break;
                case Month.March:
                    Console.WriteLine("March");
                    break;
                case Month.April:
                    Console.WriteLine("April");
                    break;
                case Month.May:
                    Console.WriteLine("May");
                    break;
                case Month.June:
                    Console.WriteLine("June");
                    break;
                case Month.July:
                    Console.WriteLine("July");
                    break;
                case Month.August:
                    Console.WriteLine("August");
                    break;
                case Month.September:
                    Console.WriteLine("September");
                    break;
                case Month.October:
                    Console.WriteLine("October");
                    break;
                case Month.November:
                    Console.WriteLine("November");
                    break;
                case Month.December:
                    Console.WriteLine("December");
                    break;
            }
        }
    }
}
