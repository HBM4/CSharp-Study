using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2_hw2
{
    internal delegate void LogHandler(string type, string command, string message); // 로그 종류, 명령어, 메시지를 받아 처리하는 대리자

    internal static class Logger
    {
        private static LogHandler logHandlers; // LogHandler 타입의 델리게이트를 선언하고, LogToConsole과 LogToFile 메서드를 등록함

        private static object fileLock = new object(); // log.csv에 동시에 쓰지 못하도록 막는 잠금
        private static Task lastWrite; // 가장 최근에 시작한 파일 쓰기 작업

        static Logger() // Logger 클래스가 처음 사용될 때 한 번만 실행됨
        {
            logHandlers += LogToConsole;
            logHandlers += LogToFile;
        }

        // 위에서 등록된 모든 핸들러(콘솔, 파일)를 순서대로 호출함.
        // type에는 "Log" 또는 "Error", command에는 words[0]를 호출하는 쪽에서 직접 넣어줌
        public static void Log(string type, string command, string message)
        {
            logHandlers(type, command, message);
        }

        // 프로그램이 끝나기 전에, 아직 끝나지 않은 마지막 파일 쓰기 작업이 끝날 때까지 기다림
        public static void Wait()
        {
            if (lastWrite != null)
                lastWrite.Wait();
        }

        private static void LogToConsole(string type, string command, string message)
        {
            Console.WriteLine($"{type}: {message}");
        }

        private static void LogToFile(string type, string command, string message)
        {
            // 파일 쓰기는 시간이 걸릴 수 있으므로 별도 스레드에서 실행함 (Task.Run)
            lastWrite = Task.Run(() =>
            {
                lock (fileLock) // 임계 구역: 한 번에 하나의 스레드만 파일에 쓸 수 있음
                {
                    File.AppendAllText("log.csv", $"{type},{command},\"{message}\"\n", new UTF8Encoding(true));
                    // UTF8Encoding(true): BOM(Byte Order Mark) 포함 UTF-8 인코딩으로 파일에 기록
                }
            });
        }
    }
}
