using CustomerClassLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.EFData
{
    public class EFCustomerRepository : IEntityRepository<Customer>
    {
        private CustomerDataContext _context;

        public EFCustomerRepository()
        {
            _context = new CustomerDataContext();
        }

        public int Create(Customer entity)
        {
            var customer = _context.Customers.Add(entity);
            _context.SaveChanges();
            return customer.CustomerId;     
        }

        public void Delete(Customer entity)
        {
            var customer = _context.Customers.Find(entity.CustomerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            var customers = _context.Customers.Include("AdressesList").Include("Note").ToList();

            foreach (var customer in customers)
            {
                _context.Customers.Remove(customer);
            }

            _context.SaveChanges();
        }

        public int GetAmountOfRows()
        {
            List<Customer> customers = _context.Customers.ToList();
            return customers.Count;
        }

        public Customer Read(int entityId)
        {
            var customer = _context.Customers.Find(entityId);
            return customer;
        }

        public List<Customer> ReadAll()
        {
            List<Customer> customers = _context.Customers.ToList();
            return customers;
        }

        public List<Customer> ReadAll(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> ReadPartially(int pageNumber, int rowsCount)
        {
            List<Customer> customers = _context.Customers.
                                                OrderBy(x => x.CustomerId).
                                                Skip(pageNumber).
                                                Take(rowsCount).
                                                ToList();
            return customers;
        }

        public void Update(Customer entity)
        {
            var customer = _context.Customers.Find(entity.CustomerId);

            if (customer == null)
            {
                return;
            }

            _context.Entry(customer).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
