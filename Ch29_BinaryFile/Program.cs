namespace Ch29_BinaryFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = File.OpenWrite("Here4.txt");
            BinaryWriter writer = new BinaryWriter(fileStream); // 개념: BinaryWriter는 이진 데이터를 파일에 쓰기 위해 사용되는 클래스입니다.
            writer.Write(3);
            writer.Write("Hello");
            writer.Close();

            FileStream fileStream2 = File.OpenRead("Here4.txt");
            BinaryReader reader = new BinaryReader(fileStream2);

            // 개념: BinaryWriter가 쓴 순서와 동일한 순서로 읽어야 합니다.
            // Write(3)으로 int(4바이트)가 먼저 기록되었고, 그 다음 Write("Hello")로
            // 문자열이 기록되었기 때문에, ReadInt32()로 먼저 4바이트를 읽어 정수를 복원하고
            // 그 다음 ReadString()을 호출해야 합니다.
            // ReadString()은 문자열 앞에 저장된 길이 prefix(7-bit 인코딩된 정수)를 먼저 읽어
            // 문자열의 바이트 길이를 파악한 뒤, 그만큼의 바이트를 읽어 문자열로 변환합니다.
            // 즉, 각 데이터 타입마다 읽는 방식(고정 크기 vs 길이 prefix + 가변 크기)이 다르기 때문에
            // 쓴 순서와 타입에 맞는 Read 메서드를 순서대로 호출해야 정확하게 값을 분리해서 가져올 수 있습니다.
            int number = reader.ReadInt32();
            string text = reader.ReadString();

            Console.WriteLine($"number: {number}, text: {text}");

            reader.Close();
        }
    }
}
