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
            this.Validation(minValue, maxValue);

            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is Int32)
            {
                var value = (int)obj;

                if (value >= minValue && value <= maxValue)
                {
                    return true;
                }

                return false;
            }
            else
            {
                throw new InvalidOperationException("Cannot validate this type!");
            }
        }

        public void Validation(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}