using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ch40_HighScoreManager
{
    internal class Score
    {
        public string PlayerName { get; set; }
        public int Points { get; set; }

        public override string ToString()
        {
            return $"{PlayerName} : {Points}점";
        }
    }

    // 실제로는 DB나 서버에서 데이터를 가져오는 상황을 흉내내는 클래스
    internal class HighScoreManager
    {
        // 태스크 기반 비동기 패턴(TAP): 결과를 Task<T>로 감싸서 반환합니다.
        public Task<Score[]> LookupScores()
        {
            // Task.Run을 사용하여 비동기적으로 작업을 수행합니다.
            return Task.Run(() =>
            {
                // 여기서 실제 작업을 동기적인 방식으로 수행합니다.
                return LookupScoresInternal();
            });
        }

        // 네트워크 통신이나 파일 I/O 등을 흉내내는 지연이 있는 실제 작업
        private Score[] LookupScoresInternal()
        {
            Thread.Sleep(2000);

            return new Score[]
            {
                new Score { PlayerName = "Alice", Points = 100 },
                new Score { PlayerName = "Bob", Points = 90 },
                new Score { PlayerName = "Charlie", Points = 80 },
            };
        }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            HighScoreManager highScoreManager = new HighScoreManager();

            await GrabHighScores(highScoreManager);
        }

        // async/await를 사용한 비동기 메서드
        static async Task GrabHighScores(HighScoreManager highScoreManager)
        {
            // await 이전의 사전 작업: 호출한 스레드가 즉시 실행합니다.
            Console.WriteLine("최고 점수를 비동기적으로 조회하는 작업을 시작합니다.");

            // await 키워드로 Task<Score[]>를 기다립니다.
            // 여기 도달하면 메서드가 둘로 쪼개지고,
            // 태스크가 완료될 때까지 이 지점 이후의 코드는 실행되지 않습니다.
            // await는 Task.Result를 직접 호출하지 않아도 결과값을 꺼내줍니다.
            Score[] highScores = await highScoreManager.LookupScores();

            // 비동기 작업이 완료된 후 수행할 작업입니다.
            Console.WriteLine("최고 점수의 비동기 조회가 완료되었습니다.");

            Console.WriteLine("\n고득점 목록:");
            foreach (Score score in highScores)
            {
                Console.WriteLine(score);
            }
        }
    }
}
