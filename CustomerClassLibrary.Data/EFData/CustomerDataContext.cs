using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.EFData
{
    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext() : base("Server=GUS1WS-00202\\SQLEXPRESS;Database=customer_lib_Opishniak_R;Trusted_Connection=True;")
        {                                   //"Server=GUS1WS-00202\\SQLEXPRESS;"
                                            //Server=WIN-QTLFNRNOL1C\\SQL2019

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> AdressesList { get; set; }

        public DbSet<CustomerNote> Note { get; set; }
    }
}
