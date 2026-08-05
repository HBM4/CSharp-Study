namespace Ch18_P123
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Color redColor = new Color(255, 0, 0);
            Color blueColor = new Color(0, 0, 255);
            Color greenColor = new Color(0, 255, 0);

            Ball ball1 = new Ball(5, redColor);
            Ball ball2 = new Ball(7, blueColor);
            Ball ball3 = new Ball(10, greenColor);

            ball1.Throw();
            Console.WriteLine(ball1.getThrowCount()); // 출력 1
            ball1.Throw();
            ball1.Throw();
            Console.WriteLine(ball1.getThrowCount()); // 출력 3
        }
    }
}