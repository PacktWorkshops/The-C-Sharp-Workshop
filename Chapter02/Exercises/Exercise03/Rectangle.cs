namespace Chapter02.Exercises.Exercise03
{
    public class Rectangle : IShape
    {
        private readonly double _width;
        private readonly double _height;

        public double Space
        {
            get
            {
                return _width * _height;
            }
        } 

        public Rectangle(in double width, in double height)
        {
            _width = width;
            _height = height;
        }
    }
}