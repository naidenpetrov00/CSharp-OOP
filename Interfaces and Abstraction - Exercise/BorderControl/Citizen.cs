namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Citizen : Id
    {
        public Citizen(string name, int age, char[] idNumber)
            : base(name, age, idNumber) { }
    }
}
