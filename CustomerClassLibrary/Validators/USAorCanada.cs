using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomerClassLibrary
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class USAorCanada : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputValue = value as string;
            var isValid = false;

            if (!string.IsNullOrEmpty(inputValue))
            {
                if (inputValue == "USA" || inputValue == "Canada")
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}
