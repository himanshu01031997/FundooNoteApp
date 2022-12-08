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
        [HttpPatch]//
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
        [HttpPut]
        [Route("PinOrNot")]
        public IActionResult PinOrNot(long noteid)
        {
            long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
            var result = inoteBL.PinOrNot(noteid);
            if (result != null)
            {
                return Ok(new { success = true, message = "message is pinned" });
            }
            else
            {
                return BadRequest(new { success = false, message = "message is not pinned" });

            }

        }
        [HttpPut]
        [Route("ArchieveMessage")]

        public IActionResult ArchiveORNot(long noteid)
        {

            long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
            var result = inoteBL.ArchiveORNot(noteid);
            if (result != null)
            {
                return Ok(new { success = true, message = "message is Archieved" });
            }
            else
            {
                return BadRequest(new { success = false, message = "message is not Archieved" });

            }
        }
        [HttpGet]
        [Route("GetAllArchieve")]
        public IActionResult GetAllArchieve()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);///////
                var result = inoteBL.GetAllArchieve(userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "get archive list", data = result });

                }
                else
                {
                    return BadRequest(new { success = false, message = "Did'nt get archive list" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("TrashInput")]

        public IActionResult Trashornot(long noteid)
        {
            long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
            var result = inoteBL.Trashornot(noteid);
            if (result != null)
            {
                return Ok(new { success = true, message = "message is Trashed" });
            }
            else
            {
                return BadRequest(new { success = false, message = "message is not Trashed" });

            }
        }
        [HttpGet]
        [Route("GetAllTrash")]
        public IActionResult GetAllTrash()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);///////
                var result = inoteBL.GetAllTrash(userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Trash list found", data = result });

                }
                else
                {
                    return BadRequest(new { success = false, message = "Trash list not Found" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("UploadImage")]
        public IActionResult UploadMyImage(long noteid, IFormFile img)
        {
            long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
            var result = inoteBL.UploadImage(userId, noteid, img);
            if (result != null)
            {
                return Ok(new { success = true, message = "Image is uploaded" });
            }
            else
            {
                return BadRequest(new { success = false, message = "Image is not uploaded" });
            }

        }
        [HttpPut]
        [Route("DeleteTrashForever")]

        public IActionResult DeleteTrashforever(long noteid)
        {
            long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
            var result = inoteBL.DeleteTrashForEver(noteid);
            if (result != null)
            {
                return Ok(new { success = true, message = "message is deleted from trash" });
            }
            else
            {
                return BadRequest(new { success = false, message = "message is not deleted from trash" });

            }
        }
        [HttpGet]
        [Route("GetReminder")]
        public IActionResult GetReminder(long noteid,DateTime reminder)
        {
            long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
            var result = inoteBL.GetReminder(noteid, reminder);
            if (result != null)
            {
                return Ok(new { success = true, message = "getting reminder" });
            }
            else
            {
                return BadRequest(new { success = false, message = "not getting reminder" });

            }
        }

    }

}

