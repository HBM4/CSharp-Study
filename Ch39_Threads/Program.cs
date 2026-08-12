namespace Ch39_Threads
{
    internal class DivisionProblem
    {
        public double Dividend { get; set; } // 나뉘는 수
        public double Divisor { get; set; } // 나누는 수
        public double Quotient { get; set; } // 몫
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(CountTo100); // Thread 객체를 생성하고 CountTo100 메서드를 실행하도록 지정합니다.
            thread1.Start();
            thread1.Join(); // 메인 스레드가 thread1이 종료될 때까지 기다리도록 합니다.

            Thread.Sleep(1000); // 1초 동안 대기합니다.

            Thread thread2 = new Thread(CountTo100);
            thread2.Start();
            thread2.Join(); // 메인 스레드가 thread2가 종료될 때까지 기다리도록 합니다.

            Thread.Sleep(1000); // 1초 동안 대기합니다.

            Thread thread3 = new Thread(CountToNumber);
            thread3.Start(50);
            thread3.Join();

            Thread.Sleep(1000); // 1초 동안 대기합니다.

            Thread thread4 = new Thread(Divide);

            DivisionProblem problem = new DivisionProblem { Dividend = 8, Divisor = 2 }; // DivisionProblem 객체를 생성하고 나뉘는 수와 나누는 수를 설정합니다.
            thread4.Start(problem);
            thread4.Join();

            Console.WriteLine("결과: " + problem.Quotient);
        }

        public static void CountTo100()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Complete");
        }

        // 이 대리자는 반환 타입이 void이고, object 타입의 매개변수를 하나 가지는데,
        // 매개변수가 object 타입이므로, 형변환하기만 한다면 어떤 용도로든 사용할 수 있습니다.
        public static void CountToNumber(object input)
        {
            int n = (int)input; // object -> int 형으로 변환

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + 1);
            }
        }

        public static void Divide(object input)
        {
            DivisionProblem problem = (DivisionProblem)input; // object -> DivisionProblem 형으로 변환
            problem.Quotient = problem.Dividend / problem.Divisor; // 나눗셈 수행
        }
    }
}
