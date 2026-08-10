namespace Ch22_Polygon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Polygon polygon = new Square(4.5f); // C#은 자동으로 Square를 Polygon으로 변환합니다.

            // 컴퓨터는 Polygon 타입의 polygon 변수가 Square 객체를 참조하고 있다는 사실을 알지 못합니다.
            //Console.WriteLine(polygon.NumberOfSides); // 가능
            // Console.WriteLine(polygon.Size);          // 불가능

            // is 키워드
            /*
            if (polygon is Square) // polygon 변수가 Square 객체를 참조하고 있는지 확인합니다.
            {
                Square square = (Square)polygon;
                Console.WriteLine(square.Size);
            }
            */

            // as 키워드
            /*
            Square square = polygon as Square; // polygon 변수가 Square 객체를 참조하고 있으면 square 변수에 할당합니다.

            if (square != null)
            {
                Console.WriteLine(square.Size);
            }
            */

            Polygon[] lotsOfPolygons = new Polygon[5];
            lotsOfPolygons[2] = new Square(2.1f);
            lotsOfPolygons[3] = new Triangle();
        }
    }
}
