using CustomerClassLibrary.Common;
using CustomerClassLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data
{
    public class CustomerAddressRepository : BaseRepository, IEntityRepository<Address>
    {
        public int Create(Address address)
        {
            int addressId;

            var validator = new AddressValidator();

            List<Tuple<string, string>> results = validator.ValidateAdress(address);

            if (results.Count != 0)
            {

                throw new WrongDataException($"Address data is invalid. {string.Join(" ", results)}");
            }

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO [dbo].customer_address (customer_id, address_line, address_line2, address_type, city, postal_code, state, country)" +
                    "VALUES(@customer_id, @address_line, @address_line2, @address_type, @city, @postal_code, @state, @country) SELECT CAST(scope_identity() AS int)", connection);

                var customerIdParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Value = address.CustomerId
                };

                var addressLineParam = new SqlParameter("@address_line", SqlDbType.NVarChar, 100)
                {
                    Value = address.AdressLine
                };

                var addressLine2Param = new SqlParameter("@address_line2", SqlDbType.NVarChar, 100)
                {
                    Value = address.AdressLine2
                };

                var addressTypeParam = new SqlParameter("@address_type", SqlDbType.VarChar, 8)
                {
                    Value = (AddressType)address.AddressType
                };

                var cityParam = new SqlParameter("@city", SqlDbType.NVarChar, 50)
                {
                    Value = address.City
                };

                var postalCodeParam = new SqlParameter("@postal_code", SqlDbType.VarChar, 6)
                {
                    Value = address.PostalCode
                };

                var stateParam = new SqlParameter("@state", SqlDbType.NVarChar, 20)
                {
                    Value = address.State
                };

                var countryParam = new SqlParameter("@country", SqlDbType.NVarChar, 255)
                {
                    Value = address.Country
                };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(addressLineParam);
                command.Parameters.Add(addressLine2Param);
                command.Parameters.Add(addressTypeParam);
                command.Parameters.Add(cityParam);
                command.Parameters.Add(postalCodeParam);
                command.Parameters.Add(stateParam);
                command.Parameters.Add(countryParam);

                addressId = (Int32)command.ExecuteScalar();
            }

            return addressId;
        }

        public Address Read(int addressId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [dbo].customer_address WHERE address_id = @address_Id", connection);

                var addressIdParam = new SqlParameter("@address_id", SqlDbType.Int)
                {
                    Value = addressId
                };

                command.Parameters.Add(addressIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var addressType = reader["address_type"]?.ToString();

                        if (addressType is not null)
                        {
                            return new Address()
                            {
                                AddressId = (Int32)reader["address_id"],
                                CustomerId = (Int32)reader["customer_id"],
                                AdressLine = reader["address_line"].ToString(),
                                AdressLine2 = reader["address_line2"].ToString(),
                                AddressType = (AddressType)Enum.Parse(typeof(AddressType), addressType),
                                City = reader["city"].ToString(),
                                PostalCode = reader["postal_code"].ToString(),
                                State = reader["state"].ToString(),
                                Country = reader["country"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<Address> ReadAll(int customerId)
        {
            List<Address> foundAddresses = new List<Address>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [dbo].customer_address WHERE customer_id = @customer_Id", connection);

                var addressIdParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(addressIdParam);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var addressType = reader["address_type"]?.ToString();

                        if (addressType is not null)
                        {
                            foundAddresses.Add(new Address()
                            {
                                AddressId = (Int32)reader["address_id"],
                                CustomerId = (Int32)reader["customer_id"],
                                AdressLine = reader["address_line"].ToString(),
                                AdressLine2 = reader["address_line2"].ToString(),
                                AddressType = (AddressType)Enum.Parse(typeof(AddressType), addressType),
                                City = reader["city"].ToString(),
                                PostalCode = reader["postal_code"].ToString(),
                                State = reader["state"].ToString(),
                                Country = reader["country"].ToString()
                            });
                        }


                    }
                }
            }

            return foundAddresses;
        }

        public void Update(Address address)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("UPDATE [dbo].customer_address SET address_line = @address_line, address_line2 = @address_line2, address_type = @address_type, " +
                    "city = @city, postal_code = @postal_code, state = @state, country = @country  WHERE address_id = @address_id", connection);

                command.Parameters.Add(new SqlParameter("@address_id", SqlDbType.Int) { Value = address.AddressId });
                command.Parameters.Add(new SqlParameter("@address_line", SqlDbType.NVarChar, 100) { Value = address.AdressLine });
                command.Parameters.Add(new SqlParameter("@address_line2", SqlDbType.NVarChar, 100) { Value = address.AdressLine2 });
                command.Parameters.Add(new SqlParameter("@address_type", SqlDbType.VarChar, 8) { Value = address.AddressType.ToString() });
                command.Parameters.Add(new SqlParameter("@city", SqlDbType.NVarChar, 50) { Value = address.City });
                command.Parameters.Add(new SqlParameter("@postal_code", SqlDbType.VarChar, 6) { Value = address.PostalCode });
                command.Parameters.Add(new SqlParameter("@state", SqlDbType.NVarChar, 20) { Value = address.State });
                command.Parameters.Add(new SqlParameter("@country", SqlDbType.NVarChar, 255) { Value = address.Country });

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int addressId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM [dbo].customer_address WHERE address_id = @address_id", connection);

                command.Parameters.Add(new SqlParameter("@address_id", SqlDbType.Int) { Value = addressId });

                command.ExecuteNonQuery();
            }
        }

        //---------------------------------------------//

        public List<Address> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(Address entity)
        {
            throw new NotImplementedException();
        }

        public List<Address> ReadPartially(int pageNumber, int rowsCount)
        {
            throw new NotImplementedException();
        }
    }
}
