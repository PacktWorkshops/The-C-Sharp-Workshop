namespace Chapter02.Exercises.Exercise02
{
    public class Rectangle
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

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }
    }
}