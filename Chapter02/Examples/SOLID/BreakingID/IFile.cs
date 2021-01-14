namespace Chapter02.Examples.SOLID.BreakingID
{
    interface IFile
    {
        string Read(string filePath);
        void Write(string filePath, string content);
    }
}
