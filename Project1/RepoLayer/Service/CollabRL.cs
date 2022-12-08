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
    public class CollabRL: ICollabRL
    {
        FundooDBContext funcontext;
        private readonly IConfiguration configuration;//used to read setting and connection string from appsetting.json

        public CollabRL(FundooDBContext funcontext, IConfiguration configuration)
        {
            this.funcontext = funcontext;
            this.configuration = configuration;
        }
        public CollabratorEntity AddCollab(long userid,long noteid,string email)
        {
            try
            {
                CollabratorEntity collabrator = new CollabratorEntity();
                collabrator.CollabEmail = email;
                collabrator.Modifiedat = DateTime.Now;
                collabrator.UserId= userid;
                collabrator.NoteId = noteid;
                this.funcontext.Add(collabrator);
                int temp=this.funcontext.SaveChanges();
                if (temp > 0)
                {
                    return collabrator;
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
        public IEnumerable<CollabratorEntity> DisplayCollab(long collabid,long userid)
        {
            try
            {
                var result = this.funcontext.CollabTable.Where(e => e.CollabID == collabid && e.UserId==userid);
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


        public bool DeleteCollab(long userid,long collabid )
        {
            try
            {
                var result = this.funcontext.CollabTable.FirstOrDefault(e => e.UserId==userid&& e.CollabID==collabid);
                if(result != null)
                {
                    this.funcontext.CollabTable.Remove(result);
                    this.funcontext.SaveChanges();
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
