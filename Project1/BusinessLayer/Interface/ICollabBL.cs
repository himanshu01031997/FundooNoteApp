using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICollabBL
    {
        public CollabratorEntity AddCollab(long userid, long noteid, string email);
        public IEnumerable<CollabratorEntity> DisplayCollab(long collabid, long userid);
        public bool DeleteCollab(long userid, long collabid);


    }
}
