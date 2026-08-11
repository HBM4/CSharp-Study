namespace Ch34_OperatorOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector a = new Vector(5, 2);
            Vector b  = new Vector(-3, 4);

            Vector result = a + b;

            Console.WriteLine($"({a.X}, {a.Y}) + ({b.X}, {b.Y}) = ({result.X}, {result.Y})");
        }
    }
}
