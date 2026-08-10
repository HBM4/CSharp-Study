namespace Ch25_Dictionary
{
    public class PhoneNumber
    {
        public string Number { get; set; }

        public PhoneNumber(string number)
        {
            Number = number;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // [교재 오타 수정] Dictionary의 Value 타입을 int가 아닌 PhoneNumber로 선언합니다.
            Dictionary<string, PhoneNumber> phoneBook = new Dictionary<string, PhoneNumber>();

            // 값 저장하기 (Key: 이름, Value: PhoneNumber 객체)
            phoneBook["Gates, Bill"] = new PhoneNumber("5550100");
            phoneBook["Zuckerberg, Mark"] = new PhoneNumber("5551438");

            // 특정 Key의 Value 가져오기
            PhoneNumber billsNumber = phoneBook["Gates, Bill"];

            // Bill Gates's Number 출력
            Console.WriteLine($"Bill Gates's Number: {billsNumber.Number}");
        }
    }
}
