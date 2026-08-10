namespace Ch29_FileStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = File.OpenWrite("Here3.txt");          
            StreamWriter writer = new StreamWriter(fileStream);

            writer.Write(3);
            writer.Write("Hello");
            writer.Close(); // Close 의미: 버퍼에 남아있는 데이터를 파일에 최종적으로 쓰고(flush), 스트림이 사용 중이던 파일 핸들 등의 리소스를 해제한다.


            FileStream fileStream2 = File.OpenRead("Here3.txt");
            StreamReader reader = new StreamReader(fileStream2);

            char nextCharacter = (char)reader.Read(); // 한 번에 문자 하나씩 읽는다.
            Console.WriteLine(nextCharacter); // 3

            char[] bufferToPutStuffIn = new char[2]; // 한 번에 두 글자를 읽을 수 있는 버퍼를 만든다.
            reader.Read(bufferToPutStuffIn, 0, 2); // 버퍼에 두 글자를 읽는다.
            string whatWasReadIn = new string(bufferToPutStuffIn); // 버퍼에 있는 글자를 문자열로 만든다.
            Console.WriteLine(whatWasReadIn); // He

            string restOfLine = reader.ReadLine(); // 한 줄 읽는다.
            Console.WriteLine(restOfLine); // llo

            reader.Close();
        }
    }
}
