using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Context;

namespace FundooNoteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollabController : ControllerBase
    {
        private readonly ICollabBL IcollabBL;
        private readonly FundooDBContext dbContext;
        public CollabController(ICollabBL IcollabBL, FundooDBContext dbContext)
        {
            this.IcollabBL = IcollabBL;
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("AddCollab")]
        public IActionResult AddCollab(long noteid,string email)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result= IcollabBL.AddCollab(userid,noteid,email);
                if (result != null)
                {
                    return Ok(new { sucess = true, message = "Added to Collab", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Not added to collab" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetCollabList")]
        public IActionResult DisplayCollab(long collabid)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = IcollabBL.DisplayCollab(collabid,userid);
                if(result != null)
                {
                    return Ok(new { success = true, message = "Displayed collab",data=result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "collab not displayed" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("DeleteCollab")]
        public IActionResult DeleteCollab(long collabid)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var temp = IcollabBL.DeleteCollab(userid, collabid);
                if (temp != null)
                {
                    return Ok(new { success = true, message = "collab deleted",data=temp });
                }
                else
                {
                    return BadRequest(new {success=false,message="collab not deleted"});
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
