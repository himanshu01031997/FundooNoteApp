using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class NoteBL:INoteBL
    {
        
        private readonly INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }
        public MyNoteEntity CreateNotes(NoteModel notemodel, long UserId)
        {
            try
            {
                return noteRL.CreateNotes(notemodel,  UserId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<MyNoteEntity> DisplayNote(long userId)
        {
            try
            {
                return noteRL.DisplayNote(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateNotes(long noteid, long userId, NoteModel node)
        {
            try
            {
                return noteRL.UpdateNotes(noteid, userId, node);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool DeleteNote(long noteid, long userid)
        {
            try
            {
                return noteRL.DeleteNote(noteid, userid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MyNoteEntity Color(long noteid, string color)
        {
            try
            {
                return noteRL.Color(noteid, color);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}

