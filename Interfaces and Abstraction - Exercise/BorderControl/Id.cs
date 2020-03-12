namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Id
    {
        private string name;
        private int age;
        private string model;
        private char[] idNumber;

        public Id(string name, int age, char[] idNumber)
        {
            this.Name = name;
            this.Age = age;
            this.IdNumber = idNumber;
        }

        public Id(string model, char[] idNumber)
        {
            this.Model = model;
            this.IdNumber = idNumber;
        }

        public string Name 
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public string Model
        {
            get { return this.model; }
            protected set { this.model = value; }
        }

        public int Age
        {
            get { return this.age; }
            protected set { this.age = value; }
        }

        public char[] IdNumber
        {
            get { return this.idNumber; }
            protected set { this.idNumber = value; }
        }
    }
}
