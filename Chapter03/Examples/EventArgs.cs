namespace Chapter03Examples
{
    public class EventArgs<T> : System.EventArgs
    {
        public EventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public class EventArgs<T1, T2> : System.EventArgs
    {
        public EventArgs(T1 value1, T2 value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public T1 Value1 { get; }
        public T2 Value2 { get; }
    }

    public class TestArgs
    {
        public TestArgs()
        {
            var args = new EventArgs<int,int>(10, 2);
        }
    }
}
