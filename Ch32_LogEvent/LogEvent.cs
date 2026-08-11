namespace Ch32_LogEvent
{
    internal class LogEvent
    {
        public LogEvent(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }

    internal delegate void LogEventHandler(LogEvent logEvent); // 커스텀 대리자 정의 (일반적으론 안쓰고, Action과 Func 대리자를 씀)
}