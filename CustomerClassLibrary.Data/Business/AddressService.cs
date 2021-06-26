using CustomerClassLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.Business
{
    public class AddressService
    {
        private readonly IEntityRepository<Address> _addressRepository;

        public AddressService()
        {
            _addressRepository = new CustomerAddressRepository();
        }

        public AddressService(IEntityRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public int CreateAddress(Address address)
        {
            return _addressRepository.Create(address);
        }

        public Address GetAddress(int addressId)
        {
            return _addressRepository.Read(addressId);
        }

        public void ChangeAddress(Address address)
        {
            _addressRepository.Update(address);
        }

        
    }
}
