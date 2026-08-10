namespace Ch29_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // HighScore Class 테스트 코드
            string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string filePath = Path.Combine(projectDirectory, "highscores.csv");

            // 저장할 HighScore 배열 생성
            HighScore[] highScores = new HighScore[]
            {
                new HighScore { Name = "Tester", Score = 9999 },
                new HighScore { Name = "Chulsoo", Score = 8500 },
                new HighScore { Name = "Younghee", Score = 7200 }
            };

            // 파일에 저장 (CSV 형식)
            HighScore saver = new HighScore();
            saver.SaveHighScores(highScores);
            Console.WriteLine($"저장 완료: {filePath}");

            // 파일에서 불러오기
            HighScore loader = new HighScore();
            HighScore[] loadedHighScores = loader.LoadHighScores(filePath);

            foreach (HighScore score in loadedHighScores)
            {
                Console.WriteLine($"{score.Name} - {score.Score}");
            }
        }
    }
}
