using System;

namespace Chapter03Examples
{
    public delegate void MessageReceivedHandler(string message, int size);
    public delegate bool OrderReceivedHandler(string message);
    public delegate void ProgressUpdatedHandler();
    // Generic form using contravariant In
    public delegate int Compare<in T>(T left, T right);

    public delegate bool IsValid(DateTime dateTime);
}
