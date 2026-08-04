namespace Ch08_P49
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the height:");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the radius:");
            double radius = Convert.ToDouble(Console.ReadLine());

            float pi = 3.1415926f;

            double volume = pi * radius * radius * height;
            Console.WriteLine($"Volume: {volume:f2}");

            double surfaceArea = 2 * pi * radius * (radius + height);
            Console.WriteLine($"Surface Area: {surfaceArea:f2}");

            //Console.ReadKey();
        }
    }
}
