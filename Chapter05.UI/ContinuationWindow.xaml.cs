using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Chapter05.UI
{
    public partial class ContinuationWindow : Window
    {
        public ContinuationWindow()
        {
            InitializeComponent();
        }
        private void GetPriceClick(object sender, RoutedEventArgs e)
        {
            Task
                .Run(GetStockPrice)
                .ContinueWith(prev =>
                {
                    Debug.Write($"[Thread {Thread.CurrentThread.ManagedThreadId}]: setting price...");
                    TxtPrice.Text = prev.Result.ToString("N2");
                });

        }
        private void GetPriceSafelyClick(object sender, RoutedEventArgs e)
        {
            Task
                .Run(GetStockPrice)
                .ContinueWith(prev =>
                {
                    Debug.Write($"[Thread {Thread.CurrentThread.ManagedThreadId}]: setting price...");
                    TxtPrice.Text = prev.Result.ToString("N2");
                }, CancellationToken.None, TaskContinuationOptions.None, 
                   TaskScheduler.FromCurrentSynchronizationContext());

        }
        private static double GetStockPrice()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5D));
            return new Random().NextDouble() * 100D;
        }
    }
}
