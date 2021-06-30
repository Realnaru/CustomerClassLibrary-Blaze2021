using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.Business
{
    public interface IAddressService
    {
        public List<Address> GetAllAddresses(int customerId);
    }
}
