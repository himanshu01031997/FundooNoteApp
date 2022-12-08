using BusinessLayer.Interface;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class CollabBL:ICollabBL
    {
        private readonly ICollabRL collabRL;
        public CollabBL(ICollabRL collabRL)
        {
            this.collabRL = collabRL;
        }
        public CollabratorEntity AddCollab(long userid, long noteid, string email)
        {
            try
            {
                return collabRL.AddCollab(userid, noteid, email);

            }
            catch(Exception)
            {
                throw;
            }
        }
        public bool DeleteCollab(long userid,long collabid)
        {
            try
            {
                return collabRL.DeleteCollab(userid, collabid);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<CollabratorEntity> DisplayCollab(long collabid, long userid)
        {
            try
            {
                return collabRL.DisplayCollab(collabid, userid);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
