namespace Ch15_P92
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of the array:");
            int inputLength = Convert.ToInt32(Console.ReadLine());

            int[] numbers = GenerateNumbers(inputLength);
            numbers = Reverse(numbers);
            PrintNumbers(numbers);
        }

        static int[] GenerateNumbers(int length)
        {
            int[] arr = new int[length];

            for (int i = 0; i < length; i++)
            {
                arr[i] = i + 1;
            }

            return arr;
        }

        static int[] Reverse(int[] arr)
        {
            int[] reverseArr = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                reverseArr[i] = arr[arr.Length - 1 - i]; // 배열의 인덱스는 0부터 시작하기 때문에 마지막 요소의 인덱스는 arr.Length - 1 이다.
            }
            return reverseArr;
        }

        static void PrintNumbers(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
