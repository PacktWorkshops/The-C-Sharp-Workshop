namespace Chapter02.Examples.SOLID.BreakingLID
{
    public class ReadonlyFile : File
    {
        public ReadonlyFile(Reader reader) : base(reader, new NullWriter())
        {
        }
    }
}
