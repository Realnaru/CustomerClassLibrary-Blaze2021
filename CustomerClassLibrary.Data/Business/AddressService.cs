using CustomerClassLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CustomerClassLibrary.Data.Business
{
    public class AddressService : IAddressService
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

        public List<Address> GetAllAddresses(int customerId)
        {
            return _addressRepository.ReadAll(customerId);
        }

        public void ChangeAddress(Address address)
        {

            _addressRepository.Update(address);
           
        }

        public void DeleteAddress(int addressId)
        {
            _addressRepository.Delete(addressId);
        }

        
    }
}
