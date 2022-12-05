using CommonLayer.Model;
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





    }
}
