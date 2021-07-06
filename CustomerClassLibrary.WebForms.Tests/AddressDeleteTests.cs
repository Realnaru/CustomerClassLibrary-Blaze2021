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
    public class AddressDeleteTests
    {
        [Fact]
        public void ShouldbeAbleToCrteateAddressDelete()
        {
            var addressDelete = new AddressDelete();
            Assert.NotNull(addressDelete);
        }
    }
}
