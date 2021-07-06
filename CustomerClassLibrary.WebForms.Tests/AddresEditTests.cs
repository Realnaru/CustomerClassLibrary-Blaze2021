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

    }
}
