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

        public int CreateNote(CustomerNote note);

        public CustomerNote GetNote(int noteId);

        public void ChangeNote(CustomerNote note);

        public void DeleteNote(int noteId);
    }
}
