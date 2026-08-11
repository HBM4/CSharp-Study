namespace Ch34_P222
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(3, 3, 3);

            Vector v3 = v1 + v2;
            Console.WriteLine($"v1 + v2 = ({v3.X}, {v3.Y}, {v3.Z})"); // (4, 5, 6)

            Vector v4 = v1 - v2;
            Console.WriteLine($"v1 - v2 = ({v4.X}, {v4.Y}, {v4.Z})"); // (-2, -1, 0)

            Vector v5 = -v1;
            Console.WriteLine($"-v1 = ({v5.X}, {v5.Y}, {v5.Z})"); // (-1, -2, -3)

            Vector v6 = v1 * 4;
            Console.WriteLine($"v1 * 4 = ({v6.X}, {v6.Y}, {v6.Z})"); // (4, 8, 12)

            Vector v7 = v2 / 2;
            Console.WriteLine($"v2 / 2 = ({v7.X}, {v7.Y}, {v7.Z})"); // (1.5, 1.5, 1.5)
        }
    }
}
