using Chapter05.Activity01;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;

namespace Chapter05.UI.Activity01
{

    public partial class FibonacciWindow : Window
    {
        public FibonacciWindow()
        {
            InitializeComponent();

            TempImagePath.Text = Path.GetTempPath() + "Fibonacci\\";
        }

        private CancellationTokenSource _tokenSource;

        private async void GenerateClick(object sender, RoutedEventArgs e)
        {
            _tokenSource?.Cancel();
            _tokenSource = new CancellationTokenSource();
            
            // Grab values from screen
            var phi =  Phi.Value;
            var phiIncrement = PhiIncrement.Value;
            var points = (int)Points.Value;
            var imageSize = (int)ImageSize.Value;
            var imageCount = (int) ImageCount.Value;
            var pointSize = PointSize.Value;

            var tempPath = TempImagePath.Text;
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }

            var token = _tokenSource.Token;

            //ImagePanel.BeginInit();
            Status.Text = $"Creating {imageCount} images...";
            for (var i = 0; i < imageCount; i ++)
            {
                var sequence = await Task.Run( 
                    () => FibonacciSequence.Calculate(points, phi),
                    token);

                if (token.IsCancellationRequested)
                {
                    break;
                }

                var imagePath = $"{tempPath}Fibonacci_{points}_{phi:N3}.jpg";
                Status.Text = $"Exporting to {imagePath}";
                ImageGenerator.ExportToJpeg(sequence, imagePath, imageSize, imageSize, pointSize);
                AddImageToPanel(imagePath, imageSize);
                phi += phiIncrement;
            }

            //ImagePanel.EndInit();
            Status.Text = $"Created {imageCount} images";
        }

        private void AddImageToPanel(string imagePath, int imageSize)
        {
            var image = new Image();
            image.BeginInit();
            image.Source = LoadBitmapImageFromFile(imagePath);
            image.Stretch = Stretch.None;
            image.Width = imageSize;
            image.Height = imageSize;
            image.Margin = new Thickness(2D);
            image.EndInit();

            ImagePanel.Items.Add(image);
        }

        private static BitmapImage LoadBitmapImageFromFile(string imagePath)
        {
            var bitmap = new BitmapImage();

            using var stream = File.OpenRead(imagePath);
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = stream;
            bitmap.EndInit();
            return bitmap;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Status.Text = "Cancelled";
            _tokenSource?.Cancel();
        }

        private void ClearAllClick(object sender, RoutedEventArgs e)
        {
            var paths = ImagePanel.Items
                .OfType<Image>()
                .Select(i => i.Source)
                .OfType<BitmapImage>()
                .Select(bi => bi.StreamSource)
                .OfType<FileStream>()
                .Select(fs => fs.Name)
                .ToList();

            ImagePanel.Items.Clear();

            foreach (var path in paths)
            {
                File.Delete(path);
            }

            Status.Text = "Ready";
        }

    }
}
