using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerClassLibrary.WebForms.Tests
{
    public class CustomerEditTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerEdit()
        {
            var customerEdit = new CustomerEdit();        
        }
    }
}
