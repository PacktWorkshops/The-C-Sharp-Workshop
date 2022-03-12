namespace Chapter02.Examples.Solid.Breaking.IspAndDip
{
    interface IFile
    {
        string Read(string filePath);
        void Write(string filePath, string content);
    }
}
