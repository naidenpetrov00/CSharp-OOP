namespace ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    [AttributeUsage(AttributeTargets.Property)]
    class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return true;
        }
    }
}
