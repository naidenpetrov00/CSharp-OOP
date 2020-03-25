namespace ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string fullName;
        private int age;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName
        {
            get => this.fullName;
            set => this.fullName = value;
        }

        [MyRange(12, 90)]
        public int Age
        {
            get => this.age;
            private set => this.age = value;
        }
    }
}
