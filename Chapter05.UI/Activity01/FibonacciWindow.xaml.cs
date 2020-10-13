using System;
using System.Collections.Generic;
using Chapter05.Activity01;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Brushes = System.Windows.Media.Brushes;
using Path = System.IO.Path;

namespace Chapter05.UI.Activity01
{
    /// <summary>
    /// Interaction logic for FibonacciWindow.xaml
    /// </summary>
    public partial class FibonacciWindow : Window
    {
        public FibonacciWindow()
        {
            InitializeComponent();

            TempImagePath.Text = Path.GetTempPath() + "Fibonacci\\";
        }

        private void GenerateClick(object sender, RoutedEventArgs e)
        {
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

            ImagePanel.BeginInit();
            Status.Text = $"Creating {imageCount} images...";
            for (var i = 0; i < imageCount; i ++)
            {
                var sequence = FibonacciSequence.Calculate(points, phi);
                var path = $"{tempPath}Fibonacci_{points}_{phi:N3}.jpg";
                Status.Text = $"Exporting to {path}";
                ImageGenerator.ExportToJpeg(sequence, path, imageSize, imageSize, pointSize);

                var image = new Image();
                image.BeginInit();
                image.Source = LoadBitmapImage(path);
                image.Stretch = Stretch.None;
                image.Width = imageSize;
                image.Height = imageSize;
                image.Margin = new Thickness(2D);
                image.EndInit();

                ImagePanel.Items.Add(image);
                phi += phiIncrement;
            }
            ImagePanel.EndInit();
            Status.Text = $"Created {imageCount} images";
        }

        private static BitmapImage LoadBitmapImage(string imagePath)
        {
            var image = new BitmapImage();

            using var stream = File.OpenRead(imagePath);
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();

            return image;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            
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

        /// <summary>
        /// Not very efficient
        /// </summary>
        private void CreateCanvasFromSequence(IList<Fibonacci> sequence)
        {
            double minX = 0;
            double maxX = 0;
            double minY = 0;
            double maxY = 0;

            foreach (var item in sequence)
            {
                if (item.X <= minX)
                {
                    minX = item.X;
                }
                if (item.X >= maxX)
                {
                    maxX = item.X;
                }
                if (item.Y <= minY)
                {
                    minY = item.Y;
                }
                if (item.Y >= maxY)
                {
                    maxY = item.Y;

                }
            }

            const int CanvasWidth = 250;
            const int CanvasHeight = 250;

            var canvas = new Canvas
            {
                Height = CanvasHeight,
                Width = CanvasWidth,
                Background = Brushes.Azure
            };

            var xRatio = CanvasWidth / (minY - maxY);
            var yRatio = CanvasHeight / (minX - maxX);

            foreach (var item in sequence)
            {

                var ellipse = new Ellipse
                {
                    Height = 2,
                    Width = 2
                };

                var left = (double)((CanvasWidth / 2F) + (float)(xRatio * item.X));
                ellipse.SetValue(Canvas.LeftProperty, left);

                var top = (double)((CanvasHeight / 2F) + (float)(yRatio * item.Y));
                ellipse.SetValue(Canvas.TopProperty, top);

                ellipse.Fill = Brushes.Blue;
                canvas.Children.Add(ellipse);
            }

            ImagePanel.Items.Add(canvas);
        }

        
    }
}
