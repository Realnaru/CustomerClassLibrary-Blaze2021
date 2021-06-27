using CustomerClassLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.Business
{
    public class NoteService
    {
        private readonly IEntityRepository<CustomerNote> _noteRepository;

        public NoteService()
        {
            _noteRepository = new CustomerNoteRepository();
        }

        public NoteService(IEntityRepository<CustomerNote> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public CustomerNote GetNote(int noteId)
        {
            return _noteRepository.Read(noteId);
        }

        public void ChangeNote(CustomerNote note)
        {
            _noteRepository.Update(note);
        }
    }

   
}
