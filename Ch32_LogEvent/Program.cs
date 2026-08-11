using System;
using System.IO;

namespace Ch32_LogEvent
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Action<LogEvent> handler = LogToConsole;
            handler += LogToFile; // 두 번째 메서드도 등록

            handler(new LogEvent("Message")); // 대리자를 호출하면, 대리자 안의 두 메서드가 순서대로 모두 호출된다. (콘솔과 파일 양쪽 다 전달)

            // 특정 메서드를 빼내는 것은 대리자에서 -= 연산자를 사용하면 된다.
            handler -= LogToFile; // LogToFile 메서드를 대리자에서 제거

        }

        private static void LogToConsole(LogEvent logEvent)
        {
            Console.WriteLine(logEvent.Text);
        }

        private static void LogToFile(LogEvent logEvent)
        {
            File.AppendAllText("log.txt", $"{logEvent.Text}{Environment.NewLine}");
        }
    }
}