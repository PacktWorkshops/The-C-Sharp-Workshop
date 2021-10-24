namespace Chapter02.Exercises.Exercise03
{
    public class Rectangle : IShape
    {
        private readonly double _width;
        private readonly double _height;

        public double Area
        {
            get
            {
                return _width * _height;
            }
        } 

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }
    }
}