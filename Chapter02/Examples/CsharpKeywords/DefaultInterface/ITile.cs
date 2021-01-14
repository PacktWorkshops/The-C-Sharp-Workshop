using System;

namespace Chapter02.Examples.CsharpKeywords.DefaultInterface
{
    interface ITile
    {
        void Render() => Console.WriteLine("Drawing tile");
    }
}
