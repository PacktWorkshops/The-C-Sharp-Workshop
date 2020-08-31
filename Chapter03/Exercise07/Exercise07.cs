using System;
namespace Chapter3
{

public static class CalculatorFactory
{
    public enum Shape
    {
        Triangle,
        Rectangle
    }

    public static Func<double, double, double> Get(Shape shape)
    {
        Func<double, double, double> calc;
        switch (shape)
        {
            case Shape.Triangle:
                calc = delegate (double argA, double argB)
                {
                    return (argA * argB) / 2.0D;
                };
                break;

            case Shape.Rectangle:
                calc = delegate (double argA, double argB)
                {
                    return argA * argB;
                };
                break;

            default:
                calc = delegate
                {
                    return 0D;
                };
                break;
        }

        return calc;

        //Func<double, double, double> calc = shape switch
        //{
        //    Shape.Triangle => delegate(double argA, double argB) 
        //        { return (argA * argB) / 2.0D; },
        //    Shape.Rectangle => delegate(double argA, double argB) 
        //        { return argA * argB; },
        //    _ => 
        //        delegate { return 0D; }
        //};
        //return calc;
    }
}

}
