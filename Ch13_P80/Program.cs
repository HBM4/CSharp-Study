namespace Ch13_P80
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90, 100 };
            int[] array2 = new int[array1.Length];

            for (int i = 0; i < array1.Length; i++)
            {
                array2[i] = array1[i];
            }

            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }
        }
    }
}
