using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CustomerClassLibrary.Data.Repositories;

namespace CustomerClassLibrary.Data
{
    public class CustomerNoteRepository : BaseRepository, IEntityRepository<CustomerNote>
    {
        public int Create(CustomerNote customerNote)
        {
            int noteId;

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO [dbo].customer_note (customer_id, note)" +
                    "VALUES (@customer_id, @note) SELECT CAST(scope_identity() AS int)", connection);

                var customer_idParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Value = customerNote.CustomerId
                };


                var noteParam = new SqlParameter("@note", SqlDbType.NVarChar, 255)
                {
                    Value = customerNote.Note
                };

                command.Parameters.Add(customer_idParam);
                command.Parameters.Add(noteParam);

                noteId = (Int32)command.ExecuteScalar();

            }

            return noteId;

        }

        public CustomerNote Read(int customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [dbo].customer_note " +
                    "WHERE customer_id = @customer_id", connection);

                var customerIdParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(customerIdParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new CustomerNote()
                        {
                            CustomerId = (Int32)reader["customer_id"],
                            NoteId = (Int32)reader["note_id"],
                            Note = reader["note"].ToString()
                        };
                    }
                }
            }
            return null;
        }
        public List<CustomerNote> ReadAll(int customerId)
        {
            List<CustomerNote> notes = new List<CustomerNote>();

            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM [dbo].customer_note " +
                    "WHERE customer_id = @customer_id", connection);

                var customerIdParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(customerIdParam);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notes.Add(new CustomerNote()
                        {
                            CustomerId = (Int32)reader["customer_id"],
                            NoteId = (Int32)reader["note_id"],
                            Note = reader["note"].ToString()
                        });
                    }
                }
            }
            return notes;
        }

        public void Update(CustomerNote customerNote)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("Update [dbo].customer_note SET note=@note WHERE customer_id = @customer_id", connection);

                var customerIdParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Value = customerNote.CustomerId
                };

                var noteParam = new SqlParameter("@note", SqlDbType.NVarChar)
                {
                    Value = customerNote.Note
                };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(noteParam);

                command.ExecuteNonQuery();

            }
        }

        public void Delete(int customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM [dbo].customer_note WHERE customer_id = @customer_id", connection);

                var customerIdParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Value = customerId
                };

                command.Parameters.Add(customerIdParam);

                command.ExecuteNonQuery();
            }
        }

        //------------------------------------------------//

        public List<CustomerNote> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(CustomerNote entity)
        {
            throw new NotImplementedException();
        }
    }

        
    
}
