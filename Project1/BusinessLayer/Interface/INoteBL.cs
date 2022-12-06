using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        
        public MyNoteEntity CreateNotes(NoteModel notemodel, long UserId);
        public IEnumerable<MyNoteEntity> DisplayNote(long userId);
        public bool UpdateNotes(long noteid, long userId, NoteModel node);
        public bool DeleteNote(long noteid, long userid);
        public MyNoteEntity Color(long noteid, string color);
        public bool PinOrNot(long noteid);
        public bool ArchiveORNot(long noteid);
        public bool Trashornot(long noteid);
        public string UploadImage(long userid, long noteid, IFormFile img);
        public bool DeleteTrashForEver(long noteid);
        public IEnumerable<MyNoteEntity> GetAllArchieve(long userid);
        public IEnumerable<MyNoteEntity> GetAllTrash(long userid);










    }
}
