using System;

namespace Chapter3Example
{

    public class OrderEntryValidator
    {
        private readonly Func<DateTime, bool> _dateValidator;

        public OrderEntryValidator(Func<DateTime, bool> dateValidator)
        {
            _dateValidator = dateValidator;
        }

        public DateTime OrderDate { get; set; }


        public bool IsValid()
            => _dateValidator(OrderDate);
    }

}
