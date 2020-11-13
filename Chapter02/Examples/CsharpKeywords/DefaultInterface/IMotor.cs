using System;

namespace Chapter02.Examples.CsharpKeywords.DefaultInterface
{
    public interface IMotor
    {
        void Move() => Console.WriteLine("Moving");
    }
}
