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
        public CustomerDataContext() : base("Server=WIN-QTLFNRNOL1C\\SQL2019;Database=customer_lib_Opishniak_R;Trusted_Connection=True;")
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> AdressesList { get; set; }

        public DbSet<CustomerNote> Note { get; set; }
    }
}
