using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_hw2
{
    public delegate void LogHandler(string type, string command, string message); // 로그 종류, 명령어, 메시지를 받아 처리하는 대리자

    internal static class Logger
    {
        // LogHandler 타입의 델리게이트를 선언하고, LogToConsole과 LogToFile 메서드를 등록함
        private static LogHandler handlers;

        static Logger() // Logger 클래스가 처음 사용될 때 한 번만 실행됨
        {
            handlers += LogToConsole;
            handlers += LogToFile;
        }

        // 위에서 등록된 모든 핸들러(콘솔, 파일)를 순서대로 호출함.
        // type에는 "Log" 또는 "Error", command에는 words[0]를 호출하는 쪽에서 직접 넣어줌
        public static void Log(string type, string command, string message)
        {
            handlers(type, command, message);
        }

        private static void LogToConsole(string type, string command, string message)
        {
            Console.WriteLine($"{type}: {message}");
        }

        private static void LogToFile(string type, string command, string message)
        {
            File.AppendAllText("log.csv", $"{type},{command},{message}\n");
        }
    }
}
