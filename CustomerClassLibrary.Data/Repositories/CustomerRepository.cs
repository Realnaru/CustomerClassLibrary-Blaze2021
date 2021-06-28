using CustomerClassLibrary.Common;
using CustomerClassLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CustomerClassLibrary.Data
{
    public class CustomerRepository : BaseRepository, IEntityRepository<Customer>
    {
        int customerId;
        public int Create(Customer customer)
        {
            var validator = new CustomerValidator();

            List<Tuple<string, string>> results = validator.ValidateCustomer(customer);

            if (results.Count != 0)
            {
                
                throw new WrongDataException($"Customer data is invalid. {string.Join(" ", results)}");
            }

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO [dbo].customer (first_name, last_name, customer_phone_number, customer_email, total_purchase_amount)" +
                    "VALUES (@first_name, @last_name, @customer_phone_number, @customer_email, @total_purchase_amount) SELECT CAST(scope_identity() AS int)", connection);

                var firstNameParam = new SqlParameter("@first_name", SqlDbType.NVarChar, 50)
                {
                    Value = customer.FirstName
                };

                 var lastNameParam = new SqlParameter("@last_name", SqlDbType.NVarChar, 50)
                {
                    Value = customer.LastName
                };

                var customerPhoneNumberParam = new SqlParameter("@customer_phone_number", SqlDbType.VarChar, 15)
                {
                    Value = customer.PhoneNumber
                };

                var customerEmailParam = new SqlParameter("@customer_email", SqlDbType.NVarChar, 100)
                {
                    Value = customer.Email
                };

                var totalPurchaseAmountParam = new SqlParameter("@total_purchase_amount", SqlDbType.Money)
                {
                    Value = customer.TotalPurshasesAmount
                };

                command.Parameters.Add(firstNameParam);
                command.Parameters.Add(lastNameParam);
                command.Parameters.Add(customerPhoneNumberParam);
                command.Parameters.Add(customerEmailParam);
                command.Parameters.Add(totalPurchaseAmountParam);

                customerId = (Int32)command.ExecuteScalar();

            }
            return customerId;
        }

        public  Customer Read(int customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [dbo].customer WHERE customer_id = @customer_id", connection);

                var customerIdParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(customerIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer()
                        {
                            CustomerId = (Int32)reader["customer_id"],
                            FirstName = reader["first_name"]?.ToString(),
                            LastName = reader["last_name"]?.ToString(),
                            PhoneNumber = reader["customer_phone_number"]?.ToString(),
                            Email = reader["customer_email"]?.ToString(),
                            TotalPurshasesAmount = (decimal)reader["total_purchase_amount"]
                        };
                    }
                } 
            }
            return null;
        }

        public List<Customer> ReadAll()
        {
            List<Customer> customers = new List<Customer>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [dbo].customer", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer()
                        {
                            CustomerId = (Int32)reader["customer_id"],
                            FirstName = reader["first_name"]?.ToString(),
                            LastName = reader["last_name"]?.ToString(),
                            PhoneNumber = reader["customer_phone_number"]?.ToString(),
                            Email = reader["customer_email"]?.ToString(),
                            TotalPurshasesAmount = (decimal)reader["total_purchase_amount"]
                        });
                    }
                }
            }
            return customers;
        }

        public List<Customer> ReadPartially(int pageNumber, int rowsCount)
        {
            var customers = new List<Customer>();
            if ( pageNumber >= 0)
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM [dbo].customer ORDER BY customer_id OFFSET(@PageNumber) * @RowsOfPage ROWS FETCH NEXT @RowsOfPage ROWS ONLY", connection);

                    command.Parameters.Add(new SqlParameter("@PageNumber", SqlDbType.Int) { Value = pageNumber});
                    command.Parameters.Add(new SqlParameter("@RowsOfPage", SqlDbType.Int) { Value = rowsCount});

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer()
                            {
                                CustomerId = (Int32)reader["customer_id"],
                                FirstName = reader["first_name"]?.ToString(),
                                LastName = reader["last_name"]?.ToString(),
                                PhoneNumber = reader["customer_phone_number"]?.ToString(),
                                Email = reader["customer_email"]?.ToString(),
                                TotalPurshasesAmount = (decimal)reader["total_purchase_amount"]
                            });
                        }

                    }

                }
                return customers;
            }
            return new List<Customer>();
        }

        public void Update(Customer customer)
        {
            var customerValidator = new CustomerValidator();
            var results = new List<Tuple<string, string>>();

            results = customerValidator.ValidateCustomer(customer);

            if (results.Count > 0)
            {
                throw new WrongDataException($"Customer data is invalid. {string.Join(" ", results)}");
            }
            using(var connection = GetConnection())
            {
                connection.Open();
               
                var command = new SqlCommand("UPDATE [dbo].customer SET first_name=@first_name, last_name=@last_name, customer_phone_number=@customer_phone_number, " +
                    "customer_email=@customer_email, total_purchase_amount=@total_purchase_amount" +
                    " WHERE customer_id=@customer_id", connection);

                var customerIdParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Value = customer.CustomerId
                };

                var firstNameParam = new SqlParameter("@first_name", SqlDbType.NVarChar, 50)
                {
                    Value = customer.FirstName
                };

                var lastNameParam = new SqlParameter("@last_name", SqlDbType.NVarChar, 50)
                {
                    Value = customer.LastName
                };

                var customerPhoneNumberParam = new SqlParameter("@customer_phone_number", SqlDbType.VarChar, 15)
                {
                    Value = customer.PhoneNumber
                };

                var customerEmailParam = new SqlParameter("@customer_email", SqlDbType.NVarChar, 100)
                {
                    Value = customer.Email
                };

                var totalPurchaseAmountParam = new SqlParameter("@total_purchase_amount", SqlDbType.Money)
                {
                    Value = customer.TotalPurshasesAmount
                };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(firstNameParam);
                command.Parameters.Add(lastNameParam);
                command.Parameters.Add(customerPhoneNumberParam);
                command.Parameters.Add(customerEmailParam);
                command.Parameters.Add(totalPurchaseAmountParam);


                command.ExecuteNonQuery();
            }

        }

        public void Delete(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM [dbo].customer WHERE customer_id = @customer_id", connection);

                var customerIdParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Value = customer.CustomerId
                };

                command.Parameters.Add(customerIdParam);

                command.ExecuteNonQuery();

            }

        }

        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var commmand = new SqlCommand("DELETE FROM [dbo].customer", connection);

                commmand.ExecuteNonQuery();
            }
        }

        //----------------------------------------------//

        public List<Customer> ReadAll(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
