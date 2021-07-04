using CustomerClassLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.EFData
{
    public class EFAddressRepository : IEntityRepository<Address>
    {
        private CustomerDataContext _context;

        public EFAddressRepository()
        {
            _context = new CustomerDataContext();
        }
        public int Create(Address entity)
        {
            var address = _context.AdressesList.Add(entity);
            _context.SaveChanges();

            return address.AddressId;
        }

        public void Delete(Address entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            var address = _context.AdressesList.Find(entityId);

            if (address != null)
            {
                _context.AdressesList.Remove(address);
            }
            _context.SaveChanges();
        }

        public int GetAmountOfRows()
        {
            throw new NotImplementedException();
        }

        public Address Read(int entityId)
        {
            var address = _context.AdressesList.Find(entityId);
            return address;
        }

        public List<Address> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<Address> ReadAll(int entityId)
        {
            var addresses = _context.AdressesList.Where(x => x.CustomerId == entityId).ToList();
            return addresses;
        }

        public List<Address> ReadPartially(int pageNumber, int rowsCount)
        {
            throw new NotImplementedException();
        }

        public void Update(Address entity)
        {
            var address = _context.AdressesList.Find(entity.AddressId);

            if (address != null)
            {
                _context.AdressesList.Remove(address);
            }
        }
    }
}
