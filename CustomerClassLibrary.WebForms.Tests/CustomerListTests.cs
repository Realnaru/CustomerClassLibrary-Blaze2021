using System;
using Xunit;

namespace CustomerClassLibrary.WebForms.Tests
{
    public class CustomerListTests
    {
        [Fact]
        public void ShouldBeAbleTocreateCustomerList()
        {
            var customerList = new CustomerList();
        }
    }
}
