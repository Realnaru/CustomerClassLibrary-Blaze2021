using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.WebForms.Tests
{
    public class CustomerDeleteTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerDelete()
        {
            var customerDelete = new CustomerDelete();
        }
    }
}
