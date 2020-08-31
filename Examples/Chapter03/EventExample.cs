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

    public class MouseEventArgs : EventArgs
    { }

    public class EventExamples
    {
        public event EventHandler OrderProcessed;

        public event EventHandler<MouseEventArgs> MouseDoubleClicked = delegate { };

        protected virtual void OnMouseDoubleClicked(object sender, MouseEventArgs e)
        {
            var evt = MouseDoubleClicked;
            evt?.Invoke(sender, e);
        }

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
        public static void Main1()
        {
            var evtSnips = new EventExamples();
            evtSnips.OrderProcessed += (sender, args) => {; };
        }
    }
}


