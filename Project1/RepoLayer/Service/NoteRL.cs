using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Service
{
    public class NoteRL:INoteRL
    {
        FundooDBContext funcontext;
        public NoteRL(FundooDBContext funcontext)
        {
            this.funcontext = funcontext;
        }
        public MyNoteEntity CreateNotes(NoteModel notemodel, long UserId)
        {
            try
            {
                var validateuser = funcontext.UserDetailTable.Where(r => r.UserId == UserId);
                if (validateuser != null)
                {
                    MyNoteEntity note = new MyNoteEntity();
                    note.Title = notemodel.Title;
                    note.Body = notemodel.Body;
                    note.Reminder = notemodel.Reminder;
                    note.Color = notemodel.Color;
                    note.Image = notemodel.Image;
                    note.Archive = notemodel.Archive;
                    note.PinNotes = notemodel.PinNotes;
                    note.Trash = notemodel.Trash;
                    note.Created = notemodel.Created;
                    note.Modified = notemodel.Modified;
                    note.UserId =  UserId;
                    funcontext.NoteEntityTable.Add(note);
                    funcontext.SaveChanges();
                    return note;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<MyNoteEntity> DisplayNote(long userId)//we can acces display note through userid only
        {
            try
            {
                var result = funcontext.NoteEntityTable.Where(r => r.UserId == userId);//after adding the note only we hava to use note entity table
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateNotes(long noteid,long userId,NoteModel node)
        {
            try
            {
                var result= funcontext.NoteEntityTable.FirstOrDefault(r=>r.NoteId==noteid && r.UserId==userId);//
                if(result != null)
                {
                    if(node.Title != null)
                    {
                        result.Title = node.Title;
                    }
                    if (node.Color != null)
                    {
                        result.Color = node.Color;
                    }
                    result.Modified = DateTime.Now;//
                    funcontext.SaveChanges();

                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteNote(long noteid,long userid)
        {
            try
            {
                var result=funcontext.NoteEntityTable.FirstOrDefault(r=>r.NoteId==noteid && r.UserId==userid);
                if(result != null)
                {
                    funcontext.NoteEntityTable.Remove(result);
                    funcontext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MyNoteEntity Color(long noteid,string color)
        {
            try
            {
                MyNoteEntity note = this.funcontext.NoteEntityTable.FirstOrDefault(e => e.NoteId == noteid);
                if (note.Color != null)
                {
                    note.Color = color;
                    this.funcontext.SaveChanges();
                    return note;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

