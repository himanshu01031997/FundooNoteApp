using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Context;

namespace FundooNoteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]//for all method need token (authorization)
    public class NoteController : ControllerBase
    {
        private readonly INoteBL inoteBL;
        private readonly FundooDBContext dbContext;
        public NoteController(INoteBL inoteBL, FundooDBContext dbContext)
        {
            this.inoteBL = inoteBL;
            this.dbContext = dbContext;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateNotes(NoteModel notemodel)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);//claiming the userid from the token .this should be where we are applying token
                var notes = inoteBL.CreateNotes(notemodel, userId);
                if (notes != null)
                {
                    return Ok(new { success = true, message = "notes added successfully", data = notes });
                }
                else
                {
                    return BadRequest(new { success = false, message = "notes not added" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult DisplayNotes()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);///////
                var result = inoteBL.DisplayNote(userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "data retrived", data = result });

                }
                else
                {
                    return BadRequest(new { success = false, message = "failed to retrive the data" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPatch]//or pput
        [Route("Update")]
        public IActionResult UpdateNotes(long noteid, long Userid, NoteModel node)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);//
                var result = inoteBL.UpdateNotes(noteid, Userid, node);
                if (result != null)
                {
                    return Ok(new { success = true, message = "notes updated succesfully" });
                }
                else
                {
                    return BadRequest(new { success = true, message = "notes not uploaded" });
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("DeleteNote")]
        public IActionResult Deletenote(long noteid, long userid)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);//
                var result = inoteBL.DeleteNote(noteid, userid);
                if (result != null)
                {
                    return Ok(new { success = true, message = "notes Deleted succesfully" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "notes does not Deleted " });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("colorchange")]
        public IActionResult Color(long noteid, string color)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);//
                var result = inoteBL.Color(noteid, color);
                if(result != null)
                {
                    return Ok(new { success = true, message = "colour is working" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "colour not working" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
