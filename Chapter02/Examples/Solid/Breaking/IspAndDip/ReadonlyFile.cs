namespace Chapter02.Examples.Solid.Breaking.IspAndDip
{
    // what interface should ReadonlyFile implement?
    public class ReadonlyFile
    {
        private readonly Reader _reader;

        public ReadonlyFile(Reader reader)
        {
            _reader = reader;
        }

        public string Read(string filePath) => _reader.Read(filePath);
    }
}
