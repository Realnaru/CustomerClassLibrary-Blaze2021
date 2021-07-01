﻿using CustomerClassLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data.Business
{
    public class NoteService : INoteService
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

        public int CreateNote(CustomerNote note)
        {
            return _noteRepository.Create(note);
        }

        public CustomerNote GetNote(int noteId)
        {
            return _noteRepository.Read(noteId);
        }

        public void ChangeNote(CustomerNote note)
        {
            _noteRepository.Update(note);
        }

        //public List<CustomerNote> GetAllNotes(int customerId)
        //{
        //    return _noteRepository.ReadAll(customerId);
        //}

        IReadOnlyCollection<CustomerNote> INoteService.GetAllNotes(int customerId)
        {
            var notes = _noteRepository.ReadAll(customerId);
            return notes.ToArray();
        }

        public void DeleteNote(int noteId)
        {
             _noteRepository.Delete(noteId);
        }

        public List<CustomerNote> GetAllNotes(int customerId)
        {
            throw new NotImplementedException();
        }
    }

   
}
