using System;

namespace Chapter09.Service.Exceptions
{
    public class NoSuchWeekdayException : Exception
    {
        public NoSuchWeekdayException(int day) 
            : base($"'{day}' is not a valid day of a week.") { }
    }
}
