using System;
using Microsoft.Win32;

class SystemEventsExample
{
    public static void Main()
    {
        SystemEvents.TimeChanged += (sender, args) =>
            Console.WriteLine("Time has been changed");
       
        Console.WriteLine("Press ENTER to stop listening");
        Console.ReadLine();
    }
}
