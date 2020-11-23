namespace Chapter02.Examples.SOLID.Good
{
    public class Writer: IWriter
    {
        public virtual void Write(string filePath, string content)
        {
            // implementation how to append content to an existing file
            // complex logic
        }
    }
}
