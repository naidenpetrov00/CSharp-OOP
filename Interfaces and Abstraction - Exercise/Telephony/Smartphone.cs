namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Smartphone : ICallable, IBrowsable
    {
        private string phoneNumber;
        private string site;

        public string PhoneNumber 
        {
            get { return this.phoneNumber; }
            private set
            {
                if (!value.All(char.IsDigit))
                {
                    throw new ArgumentException("Invalid number!");
                }
                else if (value.Length != 10)
                {
                    throw new ArgumentException("Invalid number!");
                }

                this.phoneNumber = value;
            }
        }

        public string Site
        {
            get { return this.site; }
            private set
            {
                if (value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Invalid URL!");
                }

                this.site = value;
            }
        }

        public string Brows(string site)
        {
            this.Site = site;

            return $"Browsing: {this.Site}!";
        }

        public string Call(string number)
        {
            this.PhoneNumber = number;

            return $"Calling... {this.PhoneNumber}";
        }
    }
}
