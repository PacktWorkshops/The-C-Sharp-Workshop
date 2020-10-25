using System;

namespace Chapter03Examples
{
    public class MouseClickedEventArgs 
    {
        public MouseClickedEventArgs(int clicks)
        {
            Clicks = clicks;
        }

        public int Clicks { get; }
    }

    public class MouseClickPublisher
    {
        public event EventHandler<MouseClickedEventArgs> MouseClicked = delegate { };

        protected virtual void OnMouseClicked( MouseClickedEventArgs e)
        {
            var evt = MouseClicked;
            evt?.Invoke(this, e);
        }

        private void TrackMouseClicks()
        {
            OnMouseClicked(new MouseClickedEventArgs(2));
        }
    }

    public class MouseSingleClickPublisher : MouseClickPublisher
    {
        protected override void OnMouseClicked(MouseClickedEventArgs e)
        {
            if (e.Clicks == 1)
            {
                OnMouseClicked(e);
            }
        }

    }

}


