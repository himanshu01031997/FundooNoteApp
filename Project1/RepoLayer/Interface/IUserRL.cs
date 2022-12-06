using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface IUserRL//interface of repoclass
    {
        //Interface for UserRL
        public Entity.UserTable AddUser(UserPostModel usermodel);
        public string UserLoginRegistration(string email, string password);

        public string ForgetPassword(string email);
        public bool ChangePassword(string email, PasswordValidation valid);

        

    }
}
