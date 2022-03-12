namespace Chapter02.Examples.SOLID.BreakingD
{
    public class ReadonlyFile : IReader
    {
        private readonly Reader _reader;

        public ReadonlyFile(Reader reader)
        {
            _reader = reader;
        }

        public string Read(string filePath) => _reader.Read(filePath);
    }
}
