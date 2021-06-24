using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerClassLibrary;
using Xunit;

namespace CustomerLibraryTests
{
    public class CustomerValidatorTests
    {
        [Fact]
        public void shouldReturnErrorMessages()
        {
            Customer customer = new Customer();
            CustomerValidator customerValidator = new CustomerValidator();
            List<Tuple<string, string>> errorList = customerValidator.ValidateCustomer(customer);

            Assert.Equal("AdressesList", errorList[0].Item1);
            Assert.Equal("The field is required", errorList[0].Item2);
            Assert.Equal("Note", errorList[1].Item1);
            Assert.Equal("The field is required", errorList[1].Item2);
            Assert.Equal("LastName", errorList[2].Item1);
            Assert.Equal("The field is required", errorList[2].Item2);
            
            Customer customer1 = new Customer();

            customer1.AdressesList = new List<Address>();
            customer1.PhoneNumber = "11b111111111";
            customer1.Email = "12345";
            customer1.Note = new List<CustomerNote>();

            List<Tuple<string, string>> errorList1 = customerValidator.ValidateCustomer(customer1);

            Assert.Equal("AdressesList", errorList1[0].Item1);
            Assert.Equal("The field is required", errorList1[0].Item2);

            Assert.Equal("PhoneNumber", errorList1[1].Item1);
            Assert.Equal("Phone Number should have E.164 standart", errorList1[1].Item2);

            Assert.Equal("Email", errorList1[2].Item1);
            Assert.Equal("Email adress should be valid", errorList1[2].Item2);

            Assert.Equal("Note", errorList1[3].Item1);
            Assert.Equal("The field is required", errorList1[3].Item2);
        }
    }
}
