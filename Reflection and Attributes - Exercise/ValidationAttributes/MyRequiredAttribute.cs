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
            var typeClass = Type.GetType(obj.GetType().FullName);

            var propertyForName = typeClass.GetProperty("FullName");
            var propertyForAge = typeClass.GetProperty("Age");

            var attributeForName = propertyForName.GetCustomAttributes();
            var attributeForAge = propertyForAge.GetCustomAttributes();

            if (attributeForName.GetType().Name.Contains(this.GetType().Name))
            {
                return false;
            }
            if (attributeForAge.GetType().Name.Contains(nameof(MyRangeAttribute)))
            {
                return false;
            }

            return true;
        }
    }
}
