using CustomerClassLibrary.Data.Business;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.WebForms.Tests
{
    public class AddressAddTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressAdd()
        {
            var addressAdd = new AddressAdd();
            Assert.NotNull(addressAdd);
        }

        [Fact]
        public void ShouldBeAbleToAddAddress()
        {
            var mockAddressService = new Mock<IAddressService>();
            var addressAdd = new AddressAdd(mockAddressService.Object);
            try
            {
                addressAdd.OnAddClick(this, EventArgs.Empty);
            }
            catch (System.Web.HttpException)
            {

            }
            mockAddressService.Verify(x => x.CreateAddress(It.IsAny<Address>()));
        }
    }
}
