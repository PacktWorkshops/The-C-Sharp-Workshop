using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter05.Activities.Activity01
{
    public static class FibonacciConsole
    {
        public static void Main()
        {
            var tempImagePath = Path.GetTempPath() + "Fibonacci\\";
            if (!Directory.Exists(tempImagePath))
            {
                Console.WriteLine($"Creating temp folder: {tempImagePath}");
                Directory.CreateDirectory(tempImagePath);
            }
            else
            {
                Console.WriteLine($"Using temp folder: {tempImagePath}");
            }

            CancellationTokenSource tokenSource = null;
            do
            {
                Console.Write("Phi (eg 1.0 to 6.0) (x=quit, enter=cancel):");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Cancelling previous tasks");
                    tokenSource?.Cancel();
                    continue;
                }

                if (input == "x")
                {
                    break;
                }

                if (!double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out double phi))
                {
                    continue;
                }

                Console.Write("Image Count (eg 1000):");
                input = Console.ReadLine();
                if (!int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out int imageCount))
                {
                    continue;
                }

                Console.WriteLine($"Creating {imageCount} images...");

                tokenSource = new CancellationTokenSource();
                tokenSource.Token.Register(() => Console.WriteLine("Cancelled!"));

                var token = tokenSource.Token;
                Task.Run(() => GenerateImageSequences(tempImagePath, phi, imageCount, token), 
                          token);

            }
            while (true);
            
        }


        private static async Task GenerateImageSequences(string tempImagePath, double phi, int imageCount, CancellationToken token)
        {
            const double PhiIncrement = 0.015D;
            const int Points = 3000;
            const int ImageSize = 800;
            const int PointSize = 5;;
            const string FileExtension = ".png";
            var fileFormat = ImageFormat.Png;

            for (var i = 0; i < imageCount; i++)
            {
                phi += PhiIncrement;
                var sequence = await Task.Run(() => FibonacciSequence.Calculate(Points, phi), token);
                if (token.IsCancellationRequested)
                {
                    break;
                }

                var imagePath = $"{tempImagePath}Fibonacci_{Points}_{phi:N3}{FileExtension}";

                await Task.Run(() => ImageGenerator.ExportSequence(sequence, imagePath, fileFormat, ImageSize, ImageSize, PointSize),
                               token);
            }

        }
        
    }
}
