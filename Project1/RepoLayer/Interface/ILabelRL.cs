using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface ILabelRL
    {
        public LabelEntity AddMyLabel(long userid, long noteid, string label);
        public IEnumerable<LabelEntity> ShowlabelByNoteID(long userid, long noteid);
        public bool RemoveLabelFromNote(long userid, long labelid);
        public bool RenameMyLabel(long userid, string oldname, string newname);




    }
}
