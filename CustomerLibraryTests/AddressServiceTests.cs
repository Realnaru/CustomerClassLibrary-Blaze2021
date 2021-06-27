﻿using CustomerClassLibrary.Data.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using CustomerClassLibrary.Data.Repositories;
using CustomerClassLibrary;
using CustomerLibrary.IntegrationTests.IntegrationTests;

namespace CustomerLibraryTests
{
    public class AddressServiceTests
    {
        [Fact]
        public void ShouldInitializeAddressService()
        {
            var addressService = new AddressService();
        }

        [Fact]
        public void ShouldBeAbleToCreateAddressAndReturnAddressId()
        {
            var addressMock = new Mock<IEntityRepository<Address>>();
            var addressFixture = new CustomerAddressFixture();

            var addressToCreate = addressFixture.MockAddress();
            int expectedId = 1;

            addressMock.Setup(x => x.Create(addressToCreate)).Returns(() => expectedId);

            var addressService = new AddressService(addressMock.Object);

            int addressId = addressService.CreateAddress(addressToCreate);

            Assert.Equal(expectedId, addressId);
        }

        [Fact]
        public void ShouldBeAbleToChangeAddress()
        {
            var addressMock = new Mock<IEntityRepository<Address>>();
            var addressFixture = new CustomerAddressFixture();

            var addressToChange = addressFixture.MockAddress();
           

            addressMock.Setup(x => x.Update(addressToChange));

            var addressService = new AddressService(addressMock.Object);

            addressService.ChangeAddress(addressToChange);

            addressMock.Verify(x => x.Update(addressToChange), Times.Exactly(1));
        }

        [Fact]
        public void ShouldBeAbleToGetAddress()
        {
            var addressMock = new Mock<IEntityRepository<Address>>();
            var addressFixture = new CustomerAddressFixture();

            var addressToGet = addressFixture.MockAddress();
            addressToGet.AddressId = 1;
            


            addressMock.Setup(x => x.Read(1)).Returns(addressToGet);

            var addressService = new AddressService(addressMock.Object);

            var address = addressService.GetAddress(1);

            addressMock.Verify(x => x.Read(1), Times.Exactly(1));
            Assert.Equal(addressToGet, address);
        }
    }
}
