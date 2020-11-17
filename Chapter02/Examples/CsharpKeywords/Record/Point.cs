namespace Chapter02.Examples.CsharpKeywords.Record
{
    public record Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);
    }
}
