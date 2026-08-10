using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch24_Interface
{
    // 인터페이스가 규정하는 모든 멤버에 대한 구현을 반드시 포함해야 한다.
    // 인터페이스 메서드를 구현할 때에는 override 키워드 사용 안함.
    internal class TextFileWriter : IFileWriter
    {
        public string Extension
        {
            get { return ".txt"; }
        }

        public void Write(string filename)
        {
            // 여기에 파일 작성 코드를 작성합니다.
            Console.WriteLine($"Writing to {filename}");
        }
    }
}
