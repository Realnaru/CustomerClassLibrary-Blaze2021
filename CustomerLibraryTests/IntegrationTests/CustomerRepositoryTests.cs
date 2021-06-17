﻿using CustomerClassLibrary;
using CustomerClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerLibraryTests.IntegrationTests
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var customerRepository = new CustomerRepository();
            Assert.NotNull(customerRepository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customerRepository = new CustomerRepository();
            var customer = new Customer();

            customer.FirstName = "John";
            customer.LastName = "Doe";
            customer.PhoneNumber = "123456";
            customer.Email = "hogwards@mail.com";
            customer.TotalPurshasesAmount = 1000;

            customerRepository.Create(customer);

        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var customerRepository = new CustomerRepository();
            var fixture = new CustomerRepositoryFixture();
            customerRepository.DeleteAll();
            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            var createdCustomer = customerRepository.Read(customerId);

            Assert.Equal(customer.FirstName, createdCustomer.FirstName);
            Assert.Equal(customer.LastName, createdCustomer.LastName);
            Assert.Equal(customer.PhoneNumber, createdCustomer.PhoneNumber);
            Assert.Equal(customer.Email, createdCustomer.Email);
            Assert.Equal(customer.TotalPurshasesAmount, createdCustomer.TotalPurshasesAmount);

        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var customerRepository = new CustomerRepository();
            var fixture = new CustomerRepositoryFixture();
            customerRepository.DeleteAll();
            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            var createdCustomer = customerRepository.Read(customerId);

            createdCustomer.FirstName = "Jein";
            createdCustomer.LastName = "Roe";
            createdCustomer.PhoneNumber = "999999";
            createdCustomer.Email = "dj@gmail.com";
            createdCustomer.TotalPurshasesAmount = 1000;

            customerRepository.Update(createdCustomer);

            var updatedCustomer = customerRepository.Read(createdCustomer.CustomerId);

            Assert.Equal("Jein", updatedCustomer.FirstName);
            Assert.Equal("Roe", updatedCustomer.LastName);
            Assert.Equal("999999", updatedCustomer.PhoneNumber);
            Assert.Equal("dj@gmail.com", updatedCustomer.Email);
            Assert.Equal(1000, updatedCustomer.TotalPurshasesAmount);

        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerRepository = new CustomerRepository();
            var fixture = new CustomerRepositoryFixture();
            customerRepository.DeleteAll();
            var customer = fixture.MockCustomer();
            int customerId = customerRepository.Create(customer);

            var createdCustomer = customerRepository.Read(customerId);

            customerRepository.Delete(createdCustomer);

            var deletedCustomer = customerRepository.Read(customerId);

            Assert.Null(deletedCustomer);
           ;

        }
    }
}
