using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace CustomerClassLibrary
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(Customer => Customer.FirstName).MaximumLength(50).WithMessage("Maximum length is 50 characters");

            RuleFor(Customer => Customer.LastName).NotEmpty().WithMessage("The field is required");

            RuleFor(Customer => Customer.AdressesList).NotEmpty().WithMessage("The field is required");

            RuleForEach(Customer => Customer.AdressesList).NotNull().WithMessage("Minimum length is 1 item");

            RuleFor(Customer => Customer.Email).Matches(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$").WithMessage("Email adrress should be valid");

            RuleFor(Customer => Customer.Note).NotEmpty().WithMessage("The field is required");

            RuleForEach(Customer => Customer.Note).NotNull().WithMessage("Minimum length is 1 item");


        }

        //public List<Tuple<string, string>> ValidateCustomer(Customer anyCustomer)//tuple or struct
        //{
        //    var result = new List<Tuple<string, string>>();
        //    var results = new List<ValidationResult>();
        //    var context = new ValidationContext(anyCustomer);

        //    if (!Validator.TryValidateObject(anyCustomer, context, results, true))
        //    {
        //        foreach (var error in results)
        //        {
        //            foreach (var propertyName in error.MemberNames)
        //            {
        //                result.Add(new Tuple<string, string>(propertyName, error.ErrorMessage));
        //            }
                    
        //        }
        //    }
        //    return result;
        //}
    }
}
