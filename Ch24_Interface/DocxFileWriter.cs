using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch24_Interface
{
    internal class DocxFileWriter : IFileWriter
    {
        public string Extension
        {
            get { return ".docx"; }
        }

        public void Write(string filename)
        {
            // 여기에 DOCX 파일 작성 코드를 작성합니다.
            Console.WriteLine($"Writing to {filename}");
        }
    }
}
