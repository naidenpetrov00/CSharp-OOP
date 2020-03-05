namespace Mankind
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Worker : Human
    {
        private double salary;
        private double hoursPerDay;

        public Worker(string first, string last, double salary, double hoursDay)
            : base(first, last)
        {
            this.Salary = salary;
            this.HoursPerDay = hoursDay;
        }

        public double Salary
        {
            get { return this.salary; }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {value}");
                }

                this.salary = value;
            }
        }

        public double HoursPerDay
        {
            get { return this.hoursPerDay; }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {value}");
                }

                this.hoursPerDay = value;
            }
        }

        public double SalaryPerHour()
        {
            var result = this.Salary / (this.HoursPerDay * 5);

            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat(string.Format("First Name: {0}" +
                "\nLast Name: {1}" +
                "\nWeek Salary: {2:F2}" +
                "\nHours per day: {3:F2}" +
                "\nSalary per hour: {4:F2}", this.FirstName, this.LastName, this.Salary, this.HoursPerDay, SalaryPerHour()));

            return result.ToString();
        }
    }
}
