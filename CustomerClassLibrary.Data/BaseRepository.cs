﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data
{
    public abstract class BaseRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Server=GUS1WS-00202\\SQLEXPRESS;Database=customer_lib_Opishniak_R;Trusted_Connection=True;");
        }
    }
}
