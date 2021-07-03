using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.Business
{
    public interface IAddressService
    {
        public int CreateAddress(Address address);
        public IReadOnlyCollection<Address> GetAllAddresses(int customerId);
        public Address GetAddress(int addressId);

        public void ChangeAddress(Address address);

        public void DeleteAddress(int addressId);


    }
}
