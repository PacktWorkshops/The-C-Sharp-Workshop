﻿namespace Chapter02.Examples.InheritanceAndPolymorphism
{
    public class Mail
    {
        public string Message { get; }
        public string Address { get; }

        public Mail(string message, string address)
        {
            Message = message;
            Address = address;
        }
    }
}
