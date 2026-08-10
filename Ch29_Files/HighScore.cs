using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch29_Files
{
    // 프로젝트 소스 폴더 기준 경로 (bin/Debug/net8.0에서 상위로 3단계 이동)
    // string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
    // File.WriteAllText(Path.Combine(projectDirectory, "example.txt"), informationToWrite); // 소스 코드 폴더 기준 상대경로

    internal class HighScore
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public void SaveHighScores(HighScore[] highScores)
        {
            string allHightScoresText = "Name,Score\n"; // CSV 파일의 첫 번째 줄은 헤더로 "Name,Score"를 작성

            // 동작: highScores 배열의 각 요소를 순회하며, 각 요소의 Name과 Score를 문자열로 변환하여 allHightScoresText에 추가
            foreach (HighScore score in highScores)
            {
                allHightScoresText += $"{score.Name},{score.Score}\n"; // 개념: 문자열 보간법(string interpolation)
            }

            string projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
            string filePath = Path.Combine(projectDirectory, "highscores.csv");

            File.WriteAllText(filePath, allHightScoresText); // 프로젝트 경로(Program.cs 위치한 곳)에 highscores.csv로 저장
        }

        public HighScore[] LoadHighScores(string filePath)
        {
            string[] highScoresText = File.ReadAllLines(filePath);
            HighScore[] highScores = new HighScore[highScoresText.Length - 1]; // 첫 번째 줄은 헤더이므로 배열 크기를 1 줄임

            for (int i = 1; i < highScoresText.Length; i++) // 첫 번째 줄은 헤더이므로 1부터 시작
            {
                string[] tokens = highScoresText[i].Split(','); // CSV 파일의 각 줄을 ','로 분리하여 tokens 배열에 저장
                string name = tokens[0]; // 첫 번째 토큰은 Name
                int score = Convert.ToInt32(tokens[1]); // 두 번째 토큰은 Score, 문자열을 정수로 변환

                highScores[i - 1] = new HighScore() { Name = name, Score = score };
            }

            return highScores;
        }
    }
}
