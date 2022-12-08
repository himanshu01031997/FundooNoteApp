using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Context;
using RepoLayer.Entity;

namespace FundooNoteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabelController : ControllerBase
    {
        private readonly ILabelBL IlabelBL;
        private readonly FundooDBContext dbContext;
        public LabelController(ILabelBL IlabelBL, FundooDBContext dbContext)
        {
            this.IlabelBL = IlabelBL;
            this.dbContext = dbContext;
        }
        [HttpPost]
        [Route("AddMyLabel")]
        public IActionResult AddMyLabel(long noteid,string label) 
        {
            try
            {
                
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);//token is converted into Userid
                var result = this.IlabelBL.AddMyLabel(userid, noteid, label);
                if (result != null)
                {
                    return Ok(new { success = true, message = "label added",date=result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "label not added" });
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpGet]
        [Route("showlabel")]
        public IActionResult ShowlabelByNoteID(long noteid)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = this.IlabelBL.ShowlabelByNoteID(userid, noteid);
                if(result != null)
                {
                    return Ok(new { success = true, message = "displayed all label",data=result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "not displayed" });

                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("deletelabel")]
        public IActionResult RemoveLabelFromNote(long labelid)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = this.IlabelBL.RemoveLabelFromNote(userid, labelid);
                if (result != null)
                {
                    return Ok(new { success = true, message = "removed the label", data = result });

                }
                else
                {
                    return BadRequest(new { success = false, message = "not removed the label" });

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("RenameLabel")]
        public IActionResult RenameMyLabel(string oldlabel,string newlabel)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = this.IlabelBL.RenameMyLabel(userid, oldlabel, newlabel);
                if (result != null)
                {
                    return Ok(new { success = true, message = "rename the label", data = result });

                }
                else
                {
                    return BadRequest(new { success = false, message = "not rename the label" });

                }
            }
            catch (Exception)
            {
                throw;
            }


        }

    }
}
