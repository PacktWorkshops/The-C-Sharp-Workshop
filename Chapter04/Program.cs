using System;
using System.Linq;

namespace Chapter04
{
    class Program
    {
        static void Main(string[] args)
        {
			var files = Mp3Linq.GetMp3InfoAll(@"C:\Users\adamo\OneDrive\Music").Take(100);

            Mp3Linq.ShowByYearArtistAlbum(files);
		}

		private static T Prompt<T>(string message, Func<string, T> convertResult)
        {
            Console.Write(message);
            string result = Console.ReadLine();
            return convertResult.Invoke(result);
        }
    }
}
