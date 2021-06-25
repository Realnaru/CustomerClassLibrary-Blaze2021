using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CustomerClassLibrary;

namespace CustomerLibraryTests
{
    public class AddresValidatorTests
    {
        [Fact]
        public void ShouldReturnErrorMessagesWithFieldNames()
        {
            Address address = new Address();
            AddressValidator addressValidator = new AddressValidator();

            List<Tuple<string, string>> errorList = addressValidator.ValidateAdress(address);

            Assert.Equal("AdressLine", errorList[0].Item1);
            Assert.Equal("The field is required", errorList[0].Item2);

            //Assert.Equal("AddressType", errorList[1].Item1);
            //Assert.Equal("The field can be only Shipping or Billing", errorList[1].Item2);

            Assert.Equal("City", errorList[1].Item1);
            Assert.Equal("The field is required", errorList[1].Item2);

            Assert.Equal("PostalCode", errorList[2].Item1);
            Assert.Equal("The field is required", errorList[2].Item2);

            Assert.Equal("State", errorList[3].Item1);
            Assert.Equal("The field is required", errorList[3].Item2);

            Assert.Equal("Country", errorList[4].Item1);
            Assert.Equal("The field is required", errorList[4].Item2);
           
            Address address1 = new Address();

            address1.AdressLine = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
            address1.AdressLine2 = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
            address1.City = "123456789012345678901234567890123456789012345678901234567890";
            address1.PostalCode = "1234567890";
            address1.State = "12345678901234567890123456789012345678901234567890";
            address1.Country = "Russia";

            List<Tuple<string, string>> errorList1 = addressValidator.ValidateAdress(address1);

            Assert.Equal("AdressLine", errorList1[0].Item1);
            Assert.Equal("Maximum length is 100 characters", errorList1[0].Item2);

            Assert.Equal("AdressLine2", errorList1[1].Item1);
            Assert.Equal("Maximum length is 100 characters", errorList1[1].Item2);

            //Assert.Equal("AddressType", errorList1[2].Item1);
            //Assert.Equal("The field can be only Shipping or Billing", errorList1[2].Item2);

            Assert.Equal("City", errorList1[2].Item1);
            Assert.Equal("Maximum length is 50 characters", errorList1[2].Item2);

            Assert.Equal("PostalCode", errorList1[3].Item1);
            Assert.Equal("Maximum length is 6 characters", errorList1[3].Item2);

            Assert.Equal("State", errorList1[4].Item1);
            Assert.Equal("Maximum length is 20 characters", errorList1[4].Item2);

            Assert.Equal("Country", errorList1[5].Item1);
            Assert.Equal("The field can be only USA or Canada", errorList1[5].Item2);
           
        }
        
        [Fact]
        public void ShouldNotReturnErrorMessagesIfCountryIsValid()
        {
            Address address1 = new Address();
            AddressValidator addressValidator = new AddressValidator();
            List<Tuple<string, string>> errorList = addressValidator.ValidateAdress(address1);

            address1.AdressLine = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
            address1.AdressLine2 = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
            address1.City = "123456789012345678901234567890123456789012345678901234567890";
            address1.PostalCode = "1234567890";
            address1.State = "12345678901234567890123456789012345678901234567890";
            address1.Country = "Canada";

            Assert.Equal(6, errorList.Count);
        }
    }   
}
