using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_hw2
{
    public delegate void LogHandler(string message); // 로그 메시지 하나를 받아 처리하는 대리자

    internal static class Logger
    {
        // LogHandler 타입의 델리게이트를 선언하고, LogToConsole과 LogToFile 메서드를 등록함
        private static LogHandler handlers;

        static Logger() // Logger 클래스가 처음 사용될 때 한 번만 실행됨
        {
            handlers += LogToConsole;
            handlers += LogToFile;
        }

        // 등록된 모든 핸들러(콘솔, 파일)를 순서대로 호출함.
        // 일반 로그와 에러 메시지 모두 여기로 들어옴
        public static void Log(string message)
        {
            handlers(message);
        }

        private static void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        // Log와 Error 메시지를 구분 없이 log.csv 한 파일에 모두 기록함 (열: 시각, 메시지)
        private static void LogToFile(string message)
        {
            try
            {
                File.AppendAllText("log.csv", message + "\n"); // 로그 메시지를 CSV 형식으로 기록
            }
            catch (IOException)
            {
                // 콘솔 핸들러는 이미 실행된 뒤이므로, 파일 기록만 실패했다고 알려주고 계속 진행함
                // (Logger.Log를 다시 부르면 무한 재귀가 되므로 여기서는 Console 출력만)
                Console.WriteLine("Error: 로그 파일 기록 실패.");
            }
        }
    }
}
