using System;
using System.Text.RegularExpressions;

namespace Rentfy.Domain.ValueObjects
{
    public class EmailValueObject : AValueObject
    {
        public string Address { get; private set; }

        public EmailValueObject() { }

        public EmailValueObject(string address)
        {
            Address = address;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Address))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(Address,
                pattern,
                RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(250));
        }
    }
}
