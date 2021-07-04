using CustomerClassLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.EFData
{
    public class EFCustomerNoteRepository : IEntityRepository<CustomerNote>
    {
        private CustomerDataContext _context;

        public EFCustomerNoteRepository()
        {
            _context = new CustomerDataContext();
        }
        public int Create(CustomerNote entity)
        {
            _context.Note.Add(entity);
            _context.SaveChanges();

            return entity.NoteId;
        }

        public void Delete(CustomerNote entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            var note = _context.Note.Find(entityId);
            if (note != null)
            {
                _context.Note.Remove(note);
            }
        }

        public int GetAmountOfRows()
        {
            throw new NotImplementedException();
        }

        public CustomerNote Read(int entityId)
        {
            var note = _context.Note.Find(entityId);
            return note;             
        }

        public List<CustomerNote> ReadAll()
        {
            throw new NotImplementedException();
        }

        public List<CustomerNote> ReadAll(int entityId)
        {
            var notes = _context.Note.Where(x => x.CustomerId == entityId).ToList();
            return notes;
        }

        public List<CustomerNote> ReadPartially(int pageNumber, int rowsCount)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerNote entity)
        {
            var note =_context.Note.Find(entity.NoteId);
            if (note == null)
            {
                return;
            }
            _context.Entry(note).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
