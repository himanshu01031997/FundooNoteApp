using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class UserBL:IUserBL//service class inherite the interface
    {
        //user service business
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public UserTable AddUser(UserPostModel user)
        {
            try
            {
                return this.userRL.AddUser(user);   
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public string LoginUser(string email, string password)
        {
            try
            {
                return userRL.UserLoginRegistration(email, password);
            }
            catch (Exception e)
            {
                throw e;

            }
        }
        public string ForgetPassword(string email)
        {
            try
            {
                return userRL.ForgetPassword(email);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool ChangePassword(string email, PasswordValidation valid)
        {
            try
            {
                return userRL.ChangePassword(email, valid);
            }
            catch(Exception e)
            {
                throw e;
            }
        }




    }
}
