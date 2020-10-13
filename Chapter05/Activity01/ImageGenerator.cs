using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Chapter05.Activity01
{
    public static class ImageGenerator
    {
        public static void ExportToJpeg(IList<Fibonacci> sequence, string path, int width, int height, double pointSize)
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

            using var image = new Bitmap(width, height);

            using var graphics = Graphics.FromImage(image);
            graphics.CompositingQuality = CompositingQuality.HighQuality;//.HighSpeed;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingMode = CompositingMode.SourceCopy;

            var xRatio = width / (minY - maxY);
            var yRatio = height / (minX - maxX);
            foreach (var item in sequence)
                graphics.FillEllipse(Brushes.Blue, (width / 2F) + (float)(xRatio * item.X), (height / 2F) + (float)(yRatio * item.Y), (float)pointSize, (float)pointSize);

            image.Save(path, ImageFormat.Jpeg);

            Logger.Log($"Saved to {path}");
        }
    }
}
