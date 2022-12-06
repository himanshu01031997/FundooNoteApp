using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Service
{
    public class NoteRL:INoteRL
    {
        FundooDBContext funcontext;
        private readonly IConfiguration configuration;//used to read setting and connection string from appsetting.json

        public NoteRL(FundooDBContext funcontext, IConfiguration configuration)
        {
            this.funcontext = funcontext;
            this.configuration = configuration;
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
        
        
        //r => r.UserId == userId && r.archieve==true//get all from archive
        //r => r.UserId == userId && r.trash==true//get all from archive

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
        public bool PinOrNot(long noteid)
        {
            try
            {
                MyNoteEntity result = this.funcontext.NoteEntityTable.FirstOrDefault(e => e.NoteId == noteid);
                if (result.PinNotes == true)
                {
                    result.PinNotes = false;
                    this.funcontext.SaveChanges();
                    return false;
                }
                else
                {
                    result.PinNotes = true;
                    this.funcontext.SaveChanges();
                    return true;
                }
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
                MyNoteEntity result = this.funcontext.NoteEntityTable.FirstOrDefault(e => e.NoteId == noteid);
                if (result.Archive == true)
                {
                    result.Archive = false;
                    this.funcontext.SaveChanges();
                    return false;
                }
                else
                {
                    result.Archive = true;
                    this.funcontext.SaveChanges();
                    return true;
                }

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
                var result = funcontext.NoteEntityTable.Where(r => r.UserId == userid && r.Archive == true);//after adding the note only we hava to use note entity table
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
        public bool Trashornot(long noteid)
        {
            try
            {
                MyNoteEntity result = this.funcontext.NoteEntityTable.FirstOrDefault(e => e.NoteId == noteid);
                if (result.Trash == true)
                {
                    result.Trash = false;
                    this.funcontext.SaveChanges();
                    return false;

                }
                result.Trash=true;
                this.funcontext.SaveChanges();
                return true;


            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<MyNoteEntity> GetAllTrash(long userid)
        {
            try
            {
                var result = funcontext.NoteEntityTable.Where(r => r.UserId == userid && r.Trash == true);//after adding the note only we hava to use note entity table
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

        public bool DeleteTrashForEver(long noteid)
        {
            try
            {
                MyNoteEntity result = this.funcontext.NoteEntityTable.FirstOrDefault(e => e.NoteId == noteid);
                if (result.Trash == true)
                {
                    funcontext.NoteEntityTable.Remove(result);
                    this.funcontext.SaveChanges();
                    return false;

                }
                result.Trash = true;
                this.funcontext.SaveChanges();
                return true;


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
                var result = funcontext.NoteEntityTable.FirstOrDefault(r => r.NoteId == noteid && r.UserId == userid);
                if (result != null)
                {
                    Account account = new Account(
                        this.configuration["CloudinarySetting:CloudName"],
                        this.configuration["CloudinarySetting:ApiKey"],
                        this.configuration["CloudinarySetting:ApiSecret"]);

                    Cloudinary cloudinary = new Cloudinary(account);
                    var uploadparam = new ImageUploadParams()
                    {
                        File = new FileDescription(img.FileName, img.OpenReadStream()),

                    };
                    var uploadresult = cloudinary.Upload(uploadparam);
                    string imagePath = uploadresult.Url.ToString();
                    result.Image = imagePath;
                    funcontext.SaveChanges();
                    return "Image uploaded successfully";
                }
                else
                {
                    return "Image not Uploaded";
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        



    }
}

