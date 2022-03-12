namespace Chapter02.Examples.SOLID.Good
{
    public class File : IReader, IWriter
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public File(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public string Read(string filePath) => _reader.Read(filePath);
        public void Write(string filePath, string content) => _writer.Write(filePath, content);
    }
}
