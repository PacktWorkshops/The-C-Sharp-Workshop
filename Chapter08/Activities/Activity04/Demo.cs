using System.IO;
using System.Threading.Tasks;

namespace Chapter08.Activities.Activity04
{
    public static class Demo
    {
        public const string Downloads = "Exercises/Exercise04/Data/Downloads";
        private const string Uploads = "Exercises/Exercise04/Data/Uploads";

        public static async Task Run()
        {
            var client = new FilesClient("Activity04");
            var filename1 = "Test1.txt";
            await client.DeleteFile(filename1);
            var fullpath1 = Path.Combine(Uploads, filename1);
            await client.UploadFile(fullpath1);
            await client.DownloadFile(filename1, Downloads);

            var filename2 = "Morning.jpg";
            var container = "Activity04B";
            var fullpath2 = Path.Combine(Uploads, filename2);
            await client.DeleteFile(filename2, container);
            await client.UploadFile(fullpath2, container);
            await client.DownloadFile(filename2, container, Downloads);
        }
    }
}
