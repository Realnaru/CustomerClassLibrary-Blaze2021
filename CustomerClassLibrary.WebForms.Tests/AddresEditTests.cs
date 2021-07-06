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
    public class AddresEditTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressEdit()
        {
            var addressEdit = new AddressEdit();
            Assert.NotNull(addressEdit);
        }

        [Fact]
        public void ShouldBeAbleToEditAddress()
        {
            var addressServiceMock = new Mock<IAddressService>();
            var addressEdit = new AddressEdit(addressServiceMock.Object);

            try
            {
                addressEdit.OnSaveClick(this, EventArgs.Empty);
            }
            catch (System.Web.HttpException)
            {

            }

            addressServiceMock.Verify(x => x.ChangeAddress(It.IsAny<Address>()));
        }

    }
}
