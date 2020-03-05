namespace Mankind
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set 
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {value}");
                }
                if (value.Length <= 3)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: {value}");
                }

                this.firstName = value;
            }
        }

        public string LastName 
        {
            get { return this.lastName; }
            private set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {value}");
                }
                if (value.Length <= 2)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: {value}");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat(string.Format("First Name: {0}" +
                "\nLast Name: {1}", this.FirstName, this.LastName));

            return result.ToString();
        }
    }
}
