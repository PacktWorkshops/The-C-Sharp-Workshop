using System;

namespace Chapter03Examples
{
    public class VendingRequestArgs : EventArgs
    {
        public VendingRequestArgs(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; }
    }

    public class EventExamples
    {
        public event EventHandler OrderProcessed;

        protected event EventHandler<VendingRequestArgs> ItemRequested;

        public delegate void ItemProcessedEventHandler(object sender, VendingRequestArgs e);


        private event ItemProcessedEventHandler ItemProcessed;



        public EventExamples()
        {
            OrderProcessed?.Invoke(null, EventArgs.Empty);
            ItemRequested?.Invoke(null, new VendingRequestArgs(1));
            ItemProcessed?.Invoke(null, new VendingRequestArgs(99));
        }
    }

    public static class Program1
    {
        public static void Main()
        {
            var evtSnips = new EventExamples();
            evtSnips.OrderProcessed += (sender, args) => {; };
        }
    }
}


