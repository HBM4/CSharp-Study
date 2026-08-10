namespace Ch25_Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfStrings = new List<string>();

            listOfStrings.Add("Hello World!");
            listOfStrings.Insert(0, "text3"); // Insert 0을 했으므로, "text3"이 첫 번째 요소가 됩니다. (Hello World는 두 번째 요소가 됨)

            string firstItem = listOfStrings.ElementAt(0);
            Console.WriteLine(firstItem); // 출력: text3

            string secondItem = listOfStrings[1];
            Console.WriteLine(secondItem); // 출력: Hello World!

            listOfStrings[0] = "New Value!";

            // listOfStrings.RemoveAt(2); // 에러 이유: 인덱스 2는 존재하지 않기 때문입니다.

            listOfStrings.Clear(); // 리스트를 다 비웁니다.

            int itemsInList = listOfStrings.Count; // 리스트의 아이템 개수를 가져옵니다.
            Console.WriteLine(itemsInList); // 출력: 0

            List<int> someNumbersInAList = new List<int>();
            someNumbersInAList.Add(14);
            someNumbersInAList.Add(24);
            someNumbersInAList.Add(37);
            // List<int> someNumbersInAList = new List<int>() { 14, 24, 37 }; // 이렇게도 초기화 가능

            int[] numbersInArray = someNumbersInAList.ToArray(); // 리스트를 배열로 변환합니다.
            // ToArray를 쓰는 이유?
            // 크기가 고정된 데이터, 성능이 중요할 때 (일부 구형 API나 라이브러리는 배열만 받기도 함)

            Console.WriteLine(numbersInArray[0]); // 출력: 14

            foreach (int number in someNumbersInAList)
            {
                Console.WriteLine(number); // 출력: 14, 24, 37
            }

            IEnumerable<int> numbers = new int[3] { 1, 2, 3 };
        }
    }
}
