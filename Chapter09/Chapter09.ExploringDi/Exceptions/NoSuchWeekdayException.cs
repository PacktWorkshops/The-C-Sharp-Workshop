using System;

namespace Chapter09.ExploringDi.Exceptions
{
    public class NoSuchWeekdayException : Exception
    {
        public NoSuchWeekdayException(int day) 
            : base($"'{day}' is not a valid day of a week.") { }
    }
}
