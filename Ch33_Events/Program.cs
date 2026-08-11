namespace Ch33_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(); // Point 클래스의 인스턴스 생성

            // NumberChanged 이벤트 구독
            point.NumberChanged += Point_NumberChanged;

            // 이제 점을 변경하면 NumberChanged 이벤트가 발생하고 구독한 메서드가 호출됩니다.
            point.X = 3;
        }

        // 이벤트 핸들러 메서드
        static void Point_NumberChanged(object? sender, NumberChangedEventArgs e)
        {
            Console.WriteLine($"X값이 {e.Original} -> {e.New} 로 변경됨");
        }
    }
}
