namespace ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var classType = typeof(Person);

            //Required Attributes Validation!
            var attributeType = typeof(MyRequiredAttribute);
            var attributeInctanse = Activator.CreateInstance(attributeType);
            var isValid = attributeType.GetMethod("IsValid");

            if (!(bool)isValid.Invoke(attributeInctanse, new object[] { obj }))
            {
                return false;
            }

            //Range Validation!
            attributeType = typeof(MyRangeAttribute);
            var method = classType.GetMethod("Age");
            var attribute = (MyRangeAttribute)Attribute.GetCustomAttribute(method, typeof(MyRangeAttribute));
            attributeInctanse = Activator.CreateInstance(attributeType, new object[] { attribute.MinValue, attribute.MaxValue });
            isValid = attributeType.GetMethod("IsValid");

            if (!(bool)isValid.Invoke(attributeInctanse, new object[] { obj }))
            {
                return false;
            }

            return true;
        }
    }
}
