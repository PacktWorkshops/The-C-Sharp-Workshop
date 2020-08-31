using System;
namespace Chapter3
{
    
    public static class DateValidators
    {
        public static bool IsWeekend(DateTime dateTime)
            => dateTime.DayOfWeek == DayOfWeek.Saturday ||
               dateTime.DayOfWeek == DayOfWeek.Sunday;

        public static bool IsFuture(DateTime dateTime)
        {
            return dateTime.Date > DateTime.Today;
        }
    }
   
}
