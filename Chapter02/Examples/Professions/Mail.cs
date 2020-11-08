using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter02.Examples.Professions
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
