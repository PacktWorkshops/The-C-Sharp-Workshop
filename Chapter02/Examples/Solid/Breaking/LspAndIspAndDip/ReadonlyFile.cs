namespace Chapter02.Examples.Solid.Breaking.LspAndIspAndDip
{
    public class ReadonlyFile : File
    {
        public ReadonlyFile(Reader reader) : base(reader, new NullWriter())
        {
        }
    }
}
