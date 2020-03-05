namespace Mankind
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student : Human
    {
        private string facultyNum;

        public Student(string first, string last, string facultyNum)
            :base(first, last)
        {
            this.FacultyNumber = facultyNum;
        }

        public string FacultyNumber 
        {
            get { return this.facultyNum; }
            private set 
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNum = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat(string.Format("First Name: {0}" +
                "\nLast Name: {1}" +
                "\nFaculty number: {2}", this.FirstName, this.LastName, this.FacultyNumber));

            return result.ToString();
        }
    }
}
