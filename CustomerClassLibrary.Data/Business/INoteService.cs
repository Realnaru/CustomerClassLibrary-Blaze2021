using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.Business
{
    public interface INoteService
    {
        IReadOnlyCollection<CustomerNote> GetAllNotes(int customerId);
    }
}
