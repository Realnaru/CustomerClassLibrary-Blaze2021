using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.WebForms.Tests
{
    public class AddressGroupEditTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressGroupEdit()
        {
            var addressGroupEdit = new AddressGroupEdit();
            Assert.NotNull(addressGroupEdit);
        }
    }
}
