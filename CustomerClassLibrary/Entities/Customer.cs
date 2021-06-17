using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CustomerClassLibrary.Data.Common;

namespace CustomerClassLibrary 
{
    public class Customer : Person
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "The field is required"),
            MinLength(1, ErrorMessage = "The field is required")]
        public List<Address> AdressesList { get; set; } = new List<Address>();

        [RegularExpression(@"^\+?\d{10, 14}$", ErrorMessage = "Phone Number should have E.164 standart")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      ErrorMessage = "Email adress should be valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field is required"),
            MinLength(1, ErrorMessage = "The field is required")]
        public List<CustomerNote> Note { get; set; } = new List<CustomerNote>();

        public decimal? TotalPurshasesAmount { get; set; }

        public void AddAddress(Address address)
        {
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
