namespace Ch39_P249
{
    internal class Program
    {
        private static readonly object consoleLock = new object(); // 콘솔 출력용 잠금 객체

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
                lock (consoleLock) // 임계 구역: 한 번에 하나의 스레드만 콘솔에 출력하도록 보장
                {
                    Console.WriteLine($"Frog #{frogNumber} jumped");
                }

                Thread.Sleep(Random.Shared.Next(0, 1001)); // Shared 의미: Random 객체를 여러 스레드에서 안전하게 공유할 수 있도록 제공하는 정적 속성
            }

            lock (consoleLock)
            {
                Console.WriteLine($"Frog #{frogNumber} finished");
            }
        }
    }
}