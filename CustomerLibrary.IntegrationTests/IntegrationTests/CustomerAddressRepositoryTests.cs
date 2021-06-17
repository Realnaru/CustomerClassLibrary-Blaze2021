using CustomerClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerLibraryTests.IntegrationTests
{
    public class CustomerAddressRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var customerAddressRepository = new CustomerAddressRepository();

            Assert.NotNull(customerAddressRepository);
        }
    }
}
