using System.IO;

namespace Chapter08.Exercises.Exercise04
{
    static class Demo
    {
        private const string Downloads = "Exercises/Exercise04/Data/Downloads";
        private const string Uploads = "Exercises/Exercise04/Data/Uploads";

        public static void Run()
        {
            var client = new FilesClient("Exercise04");
            var filename1 = "Test1.txt";
            var fullpath1 = Path.Combine(Uploads, filename1);
            client.UploadFile(fullpath1);
            client.DownloadFile(filename1, Downloads);

            var filename2 = "Morning.jpg";
            var container = "Exercise04B";
            var fullpath2 = Path.Combine(Uploads, filename2);
            client.UploadFile(fullpath2, container);
            client.DownloadFile(filename2, container, Downloads);
        }
    }
}
