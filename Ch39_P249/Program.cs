namespace Ch39_P249
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(FrogRace);
            Thread thread2 = new Thread(FrogRace);
            Thread thread3 = new Thread(FrogRace);

            thread1.Start(1);
            thread2.Start(2);
            thread3.Start(3);

            thread1.Join();
            thread2.Join();
            thread3.Join();
        }

        public static void FrogRace(object input)
        {
            int frogNumber = (int)input;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Frog #{frogNumber} jumped");
                Thread.Sleep(Random.Shared.Next(0, 1001)); // Shared 의미: Random 객체를 여러 스레드에서 안전하게 공유할 수 있도록 제공하는 정적 속성
            }

            Console.WriteLine($"Frog #{frogNumber} finished");
        }
    }
}