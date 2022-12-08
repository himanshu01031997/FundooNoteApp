using BusinessLayer.Interface;
using CommonLayer.Model;
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
    public class LabelBL:ILabelBL
    {
        private readonly ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
      


        public LabelEntity AddMyLabel(long userid, long noteid, string label)
        {
            try
            {
                return labelRL.AddMyLabel(userid, noteid, label);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<LabelEntity> ShowlabelByNoteID(long userid, long noteid)
        {
            try
            {
                return labelRL.ShowlabelByNoteID(userid, noteid);   
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
                return labelRL.RemoveLabelFromNote(userid, labelid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RenameMyLabel(long userid, string oldname, string newname)
        {
            try
            {
                return labelRL.RenameMyLabel(userid, oldname, newname);
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
