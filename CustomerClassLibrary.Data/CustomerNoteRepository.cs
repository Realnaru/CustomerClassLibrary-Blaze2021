using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CustomerClassLibrary.Data
{
    public class CustomerNoteRepository : BaseRepository
    {
        public void Create(CustomerNote customerNote)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO [dbo].customer_note (customer_id, note)" +
                    "VALUES (@customer_id, @note)", connection);

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

                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
