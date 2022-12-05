using CommonLayer.Model;
using Experimental.System.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Service
{
    public class UserRL : IUserRL
    {
        FundooDBContext funcontext;
        private readonly IConfiguration configuration;//used to read setting and connection string from appsetting.json
        public UserRL(FundooDBContext funcontext, IConfiguration configuration)
        {
            this.funcontext = funcontext;
            this.configuration = configuration;
        }
        public Entity.UserTable AddUser(UserPostModel usermodel)
        {
            try
            {
                Entity.UserTable MyUser = new Entity.UserTable();
                MyUser.UserId = new Entity.UserTable().UserId;
                MyUser.FirstName = usermodel.FirstName;
                MyUser.LastName = usermodel.LastName;
                MyUser.EmailId = usermodel.EmailId;
                MyUser.Password = EncriptPassword(usermodel.Password);
                funcontext.UserDetailTable.Add(MyUser);
                funcontext.SaveChanges();
                return MyUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UserLoginRegistration(string email, string password)
        {
            try
            {
                var result = funcontext.UserDetailTable.Where(u => u.EmailId == email && u.Password == EncriptPassword(password)).FirstOrDefault();
                if (result != null)
                {
                    return GetJWToken(email, result.UserId);
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public static string EncriptPassword(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                {
                    return null;
                }
                else
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(password);
                    string encrypted = Convert.ToBase64String(bytes);
                    return encrypted;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        private string GetJWToken(string Email, long UserId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"])); var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); var claims = new[] { new Claim(ClaimTypes.Email, Email), new Claim("UserId", UserId.ToString()) };
            var token = new JwtSecurityToken(configuration["Jwt:key"], configuration["Jwt:key"], claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials); return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //public string GetJWToken(string email, long UserId)
        //    {

        //        var tokenhandler = new JwtSecurityTokenHandler();
        //        var tokenkey = Encoding.ASCII.GetBytes(this.configuration[("Jwt:key")]);//
        //        var tokenDescripter = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //            new Claim(ClaimTypes.Email, email),
        //            new Claim("UserId", UserId.ToString()),

        //            }),
        //            Expires = DateTime.UtcNow.AddYears(1),
        //            SigningCredentials =
        //            new SigningCredentials(
        //                new SymmetricSecurityKey(tokenkey),
        //                SecurityAlgorithms.HmacSha256Signature)

        //        };
        //        var token = tokenhandler.CreateToken(tokenDescripter);
        //        return tokenhandler.WriteToken(token);
        //    }
        //}
        public static string DecriptPassword(string encryptedpassword)
        {
            byte[] bytes;
            string decrypted;
            try
            {
                if (string.IsNullOrEmpty(encryptedpassword))
                {
                    return null;
                }
                else
                {
                    bytes = Convert.FromBase64String(encryptedpassword);
                    decrypted = Encoding.ASCII.GetString(bytes);
                    return decrypted;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ForgetPassword(string email)
        {
            try
            {
                var CheckEmail = funcontext.UserDetailTable.FirstOrDefault(e => e.EmailId == email);
                if (CheckEmail != null)
                {
                    var Token = GetJWToken(CheckEmail.EmailId, CheckEmail.UserId);
                    MSMQModel msmqModel = new MSMQModel();
                    msmqModel.sendDatatoQueue(Token);
                    return Token.ToString();
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
        
        public bool ChangePassword(string email,PasswordValidation valid)
        {
            try
            {
                if (valid.Password.Equals(valid.ConfirmPassword))
                {
                    var user = funcontext.UserDetailTable.Where(x => x.EmailId == email).FirstOrDefault();
                    user.Password = EncriptPassword(valid.ConfirmPassword);//
                    funcontext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
