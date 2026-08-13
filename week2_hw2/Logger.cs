using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_hw2
{
    public delegate void LogHandler(string type, string message); // 로그 종류와 메시지를 받아 처리하는 대리자

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
        // type에는 "Log" 또는 "Error"처럼 호출하는 쪽에서 종류를 직접 넣어줌
        public static void Log(string type, string message)
        {
            handlers(type, message);
        }

        private static void LogToConsole(string type, string message)
        {
            Console.WriteLine($"{type}: {message}");
        }

        // Log와 Error를 구분 없이 log.csv 한 파일에 모두 기록함 (열: 종류, 내용)
        private static void LogToFile(string type, string message)
        {
            File.AppendAllText("log.csv", $"{type},{message}\n");
        }
    }
}
