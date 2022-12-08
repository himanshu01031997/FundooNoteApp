using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepoLayer.Entity;
using RepoLayer.Interface;
using RepoLayer.Service;
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
        public bool PinOrNot(long noteid)
        {
            try
            {
                return noteRL.PinOrNot(noteid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ArchiveORNot(long noteid)
        {
            try
            {
                return noteRL.ArchiveORNot(noteid);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public IEnumerable<MyNoteEntity> GetAllArchieve(long userid)
        {
            try
            {
                return noteRL.GetAllArchieve(userid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Trashornot(long noteid)//params
        {
            try
            {
                return noteRL.Trashornot(noteid);
            }
             catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<MyNoteEntity> GetAllTrash(long userid)//
        {
            try
            {
                return noteRL.GetAllTrash(userid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string UploadImage(long userid, long noteid, IFormFile img)
        {
            try
            {
                return noteRL.UploadImage(userid,noteid,img);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteTrashForEver(long noteid)
        {
            try
            {
                return noteRL.DeleteTrashForEver(noteid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MyNoteEntity GetReminder(long noteid, DateTime reminder)
        {
            try
            {
                return noteRL.GetReminder(noteid,reminder);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

