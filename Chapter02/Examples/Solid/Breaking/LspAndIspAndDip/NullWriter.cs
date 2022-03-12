namespace Chapter02.Examples.Solid.Breaking.LspAndIspAndDip
{
    class NullWriter : Writer
    {
        public override void Write(string filePath, string content)
        {
            // Does nothing
        }
    }
}
