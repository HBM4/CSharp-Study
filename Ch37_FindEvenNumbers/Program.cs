namespace Ch37_FindEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 아래 3가지 기능을 테스트 하는 코드 작성
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("FindEvenNumbers1:");
            foreach (var even in FindEvenNumbers1(numbers))
            {
                Console.WriteLine(even);
            }

            Console.WriteLine("\nFindEvenNumbers2:");
            foreach (var even in FindEvenNumbers2(numbers))
            {
                Console.WriteLine(even);
            }

            Console.WriteLine("\nFindEvenNumbers3:");
            foreach (var even in FindEvenNumber3(numbers))
            {
                Console.WriteLine(even);
            }
        }

        public static IEnumerable<int> FindEvenNumbers1(List<int> numbers)
        {
            return numbers.Where(x => x % 2 == 0); // 평범한 람다 표현식
        }

        public static IEnumerable<int> FindEvenNumbers2(List<int> numbers)
        {
            bool isEven(int number) // 로컬 함수 정의
            {
                return number % 2 == 0;
            }

            return numbers.Where(isEven); // 로컬 함수를 Where에 전달
        }

        public static IEnumerable<int> FindEvenNumber3(List<int> numbers)
        {
            bool isEven(int number) => number % 2 == 0; // 로컬 함수 정의 (람다 표현식)

            return numbers.Where(isEven);
        }
    }
}
