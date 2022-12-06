using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserBL//interface of business layer
    {
        //Interface for add user
        public UserTable AddUser(UserPostModel user);
        public string LoginUser(string email, string password);
        public string ForgetPassword(string email);
        public bool ChangePassword(string email, PasswordValidation valid);




    }
}
