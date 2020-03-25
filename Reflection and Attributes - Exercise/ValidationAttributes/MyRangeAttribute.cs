namespace ValidationAttributes
{
    using System;
    [AttributeUsage(AttributeTargets.Property)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public int MinValue 
        {
            get => this.minValue;
            private set => this.minValue = value;
        }

        public int MaxValue
        {
            get => this.maxValue;
            private set => this.maxValue = value;
        }

        public override bool IsValid(object obj)
        {
            return this.Validation(obj);
        }

        public bool Validation(object obj)
        {
            var deliveredClass = (Person)obj;

            if (deliveredClass.Age >= this.minValue && deliveredClass.Age <= this.maxValue)
            {
                return true;
            }

            return false;
        }
    }
}