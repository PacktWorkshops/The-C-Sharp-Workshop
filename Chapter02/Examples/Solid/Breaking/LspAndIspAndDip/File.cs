namespace Chapter02.Examples.Solid.Breaking.LspAndIspAndDip
{
    public class File
    {
        private readonly Reader _reader;
        private readonly Writer _writer;

        public File(Reader reader, Writer writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public string Read(string filePath) => _reader.Read(filePath);
        public void Write(string filePath, string content) => _writer.Write(filePath, content);
    }
}
