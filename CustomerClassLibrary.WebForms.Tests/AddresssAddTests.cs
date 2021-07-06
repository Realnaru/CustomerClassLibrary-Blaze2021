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
    }
}
