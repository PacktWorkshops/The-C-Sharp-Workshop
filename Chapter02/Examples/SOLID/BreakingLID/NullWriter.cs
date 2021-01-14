namespace Chapter02.Examples.SOLID.BreakingLID
{
    class NullWriter : Writer
    {
        public override void Write(string filePath, string content)
        {
            // Does nothing
        }
    }
}
