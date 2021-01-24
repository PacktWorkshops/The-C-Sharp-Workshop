using System;
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
                Console.Write("Phi (eg 1.0 to 6.0):");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Cancelling previous tasks");
                    tokenSource?.Cancel();
                    continue;
                }

                if (!double.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out double phi))
                {
                    continue;
                }

                Console.Write("Image Count (eg 10):");
                input = Console.ReadLine();
                if (!int.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out int imageCount))
                {
                    continue;
                }

                Console.WriteLine($"Creating {imageCount} images...(press ENTER to cancel)");

                tokenSource = new CancellationTokenSource();
                tokenSource.Token.Register(
                    () => Console.WriteLine("Cancelled!"));

                var token = tokenSource.Token;
                Task.Run(() => GenerateAllSequences(tempImagePath, phi, imageCount, token), token);

            }
            while (true);
            
        }


        private static async void GenerateAllSequences(string tempImagePath, double phi, int imageCount, CancellationToken token)
        {
            const double PhiIncrement = 0.015D;
            const int Points = 500;
            const int ImageSize = 300;
            const int PointSize = 3;

            for (var i = 0; i < imageCount; i++)
            {
                var sequence = await Task.Run(
                    () => FibonacciSequence.Calculate(Points, phi),
                    token);

                if (token.IsCancellationRequested)
                {
                    break;
                }

                var imagePath = $"{tempImagePath}Fibonacci_{Points}_{phi:N3}.jpg";
                await Task.Run(
                    () => ImageGenerator.ExportToJpeg(sequence, imagePath, ImageSize, ImageSize, PointSize),
                    token);

                phi += PhiIncrement;
            }
        }
    }
}
