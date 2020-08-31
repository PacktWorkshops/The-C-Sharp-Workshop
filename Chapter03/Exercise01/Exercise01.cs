using System;

namespace Chapter3
{
    public delegate bool DateValidationHandler(DateTime dateTime);

    public class OrderValidator
    {
        private readonly DateValidationHandler _dateValidator;

        public OrderValidator(DateValidationHandler dateValidator)
        {
            _dateValidator = dateValidator;
        }
    }

}

