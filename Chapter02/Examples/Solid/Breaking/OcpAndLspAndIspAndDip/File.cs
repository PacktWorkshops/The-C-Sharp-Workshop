namespace Chapter02.Examples.SOLID.BreakingOLID
{
    public class File
    {
        private readonly Reader _reader;
        private readonly Writer _writer;

        public File()
        {
            _reader = new Reader();
            _writer = new Writer();
        }

        public string Read(string filePath) => _reader.Read(filePath);
        public void Write(string filePath, string content) => _writer.Write(filePath, content);
    }
}
