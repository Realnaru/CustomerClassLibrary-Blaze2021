using System;
using Xunit;
using CustomerClassLibrary;

namespace CustomerLibraryTests
{
    public class AddressTests
    {
        [Fact]
        public void ShouldCreateAddress()
        {
            Address address = new Address();
            Assert.Equal(0, address.AddressId);
            Assert.Equal(0, address.CustomerId);
            Assert.Null(address.AdressLine);
            Assert.Null(address.AdressLine2);
            Assert.Null(address.City);
            Assert.Equal(AddressType.Shipping, address.AddressTypeEnum);
            Assert.Null(address.PostalCode);

        }
        [Fact]
        public void ShouldSetAndGetProperties()
        {
            Address address = new Address();

            address.AddressId = 1;
            address.CustomerId = 1;
            address.AdressLine = "4 Privet Drive";
            address.AdressLine2 = "Little Whinging";
            address.AddressTypeEnum = AddressType.Billing;
            address.City = "Surrey";
            address.Country = "USA";
            address.State = "England";
            address.PostalCode = "CH61 1DE";

            Assert.Equal(1, address.AddressId);
            Assert.Equal(1, address.CustomerId);
            Assert.Equal("4 Privet Drive", address.AdressLine);
            Assert.Equal("Little Whinging", address.AdressLine2);
            Assert.Equal(AddressType.Billing, address.AddressTypeEnum);
            Assert.Equal("Surrey", address.City);
            Assert.Equal("USA", address.Country);
            Assert.Equal("England", address.State);
            Assert.Equal("CH61 1DE", address.PostalCode);
        }
    }
}
