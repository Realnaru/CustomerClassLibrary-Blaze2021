using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CustomerClassLibrary.Data.Common;
using CustomerClassLibrary.Common;
using CustomerClassLibrary.Validators;

namespace CustomerClassLibrary 
{
    public class Customer : Person
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "The field is required"),
            EnsureOneItemAttribute(ErrorMessage = "The field is required")]
        public List<Address> AdressesList { get; set; } = new List<Address>();

        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Phone Number should have E.164 standart")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      ErrorMessage = "Email adress should be valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field is required"),
            EnsureOneItemAttribute(ErrorMessage = "The field is required")]
        public List<CustomerNote> Note { get; set; } = new List<CustomerNote>();

        public decimal? TotalPurshasesAmount { get; set; }

        public int AddressesCount = 0;
        public int NoteCount = 0;

        public void AddAddress(Address address)
        {
            var addressValidator = new AddressValidator();
            List<string> results = addressValidator.ValidateAdress(address);

            if (results.Count != 0)
            {
                throw new WrongDataException($"Address data is invalid. {string.Join(" ", results)}");
            }

            if (CustomerId == address.CustomerId)
            {
                AdressesList.Add(address);
            } else
            {
                throw new WrongIdException();
            }
           
        }

        public void AddNote(CustomerNote note)
        {
            if (note.CustomerId == CustomerId)
            {
                Note.Add(note);
            } else
            {
                throw new WrongIdException();
            }
             
        }

    }
}
