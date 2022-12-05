using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Context;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FundooNoteApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //presentation class
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        FundooDBContext context;
        public UserController(IUserBL userBL, FundooDBContext context)
        {
            this.userBL = userBL;
            this.context = context;
        }
        [HttpPost("Register")]//http verb
        public ActionResult RegisterUser(UserPostModel user)
        {
            try
            {
                var result = userBL.AddUser(user);
                if (result != null)
                {
                    return Ok(new { success = true, message = $"Registration successful{result}" });
                }
                return BadRequest(new { success = false, message = $"Registration failed" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost("Login/{email}/{password}")]//http verb
        public ActionResult LoginUser(string email, string password)
        {
            try
            {
                var result = userBL.LoginUser(email, password);
                if (result != null)
                {
                    return Ok(new
                    {
                        success = true,
                        message = $"{result}"
                    });
                }
                return BadRequest(new { success = false, message = $"login failed" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost("ForgetPassword")]
        public ActionResult ForgetPassword(string email)
        {
            try
            {
                var result = this.userBL.ForgetPassword(email);
                if( result != null)
                {
                    return this.Ok(new { success = true, Message = $"Forget Password success" });
                }
                return this.BadRequest(new { success = false, Messsage = $"forget password can not work" });
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [Route("ResetPassword")]
        public ActionResult ResetPassword(string email, PasswordValidation valid)
        {
            try
            {
                //var red = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = userBL.ChangePassword(email,valid);
                if(result != false)
                {
                    return Ok(new { success = true, message = "Password Reset Successfully" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Password Reset not Successfully" });
                }
            }
            catch(System.Exception )
            {
                throw;
            }
        }




    }
}
