﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.Repositories
{
    public interface IEntityRepository<TEntity>
    {
        public int Create(TEntity entity);

        public TEntity Read(int entityId);

        public void Update(TEntity entity);

        public void Delete(TEntity entity);
        List<Address> ReadByCustomerId(int customerId);
        List<CustomerNote> ReadNoteByCustomerId(int customerId);
    }
}
