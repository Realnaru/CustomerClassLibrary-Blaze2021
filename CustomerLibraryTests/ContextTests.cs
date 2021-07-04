using CustomerClassLibrary.Data.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerLibraryTests
{
    public class ContextTests
    {
        [Fact]
        public void ShouldBeAbleToCreateContext()
        {
            var context = new CustomerDataContext();

            Assert.NotNull(context.Customers);
            Assert.NotNull(context.AdressesList);
            Assert.NotNull(context.Note);
        }
    }
}
