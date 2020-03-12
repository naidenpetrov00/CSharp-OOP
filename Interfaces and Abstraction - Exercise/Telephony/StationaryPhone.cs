namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StationaryPhone : ICallable
    {
        private string phoneNumber;

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            private set
            {
                if (!value.All(char.IsDigit))
                {
                    throw new ArgumentException("Invalid number!");
                }
                else if (value.Length != 7)
                {
                    throw new ArgumentException("Invalid number!");
                }

                this.phoneNumber = value;
            }
        }

        public string Call(string number)
        {
            this.PhoneNumber = number;

            return $"Dialing... {this.PhoneNumber}";
        }
    }
}
