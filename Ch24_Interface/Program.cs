namespace Ch24_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFileWriter[] fileWriters = new IFileWriter[2];
            fileWriters[0] = new TextFileWriter();
            fileWriters[1] = new DocxFileWriter();

            foreach(IFileWriter fileWriter in fileWriters)
            {
                fileWriter.Write("path/to/file" + fileWriter.Extension);
            }
        }
    }
}
