using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ShippingOrBilling : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputValue = value as string;
            var isValid = false;
            AddressType typeOfAddress;

            if (!string.IsNullOrEmpty(inputValue))
            {
              
                if (Enum.TryParse<AddressType>(inputValue, out typeOfAddress) == true)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

    }
}
