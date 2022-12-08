using Microsoft.Extensions.Configuration;
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
    public class LabelRL:ILabelRL
    {
        FundooDBContext funcontext;
        private readonly IConfiguration configuration;//used to read setting and connection string from appsetting.json

        public LabelRL(FundooDBContext funcontext, IConfiguration configuration)
        {
            this.funcontext = funcontext;
            this.configuration = configuration;
        }
        public LabelEntity AddMyLabel(long userid,long noteid,string label)
        {
            try
            {
                LabelEntity entity = new LabelEntity();
                entity.LabelName=label;
                entity.UserId=userid;
                entity.NoteId = noteid;
                this.funcontext.LabelTable.Add(entity);
                int temp=this.funcontext.SaveChanges();
                if (temp > 0)
                {
                    return entity;
                }
                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<LabelEntity> ShowlabelByNoteID(long userid,long noteid)
        {
            try
            {
                var result = this.funcontext.LabelTable.Where(e => e.NoteId == noteid && e.UserId == userid);
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool RemoveLabelFromNote(long userid, long labelid)
        {
            try
            {
                var result = this.funcontext.LabelTable.FirstOrDefault(e =>  e.UserId == userid && e.LabelId== labelid);
                if (result != null)
                {
                    this.funcontext.LabelTable.Remove(result);
                    this.funcontext.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool RenameMyLabel(long userid,string oldname,string newname)
        {
            try
            {
                var result = this.funcontext.LabelTable.FirstOrDefault(e => e.UserId == userid && e.LabelName == oldname);
                if(result != null)
                {
                    result.LabelName = newname;
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

    }
}
