using MLM.Business.Models.ViewModels;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLM.Business.Extensions
{
    public static class UserExtensions
    {
        public static User GetUserByMobile(this IBaseRepository<User> userRepository, string mobile)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.ContactNumber == mobile);
        }

        public static void UpdateToken(this IBaseRepository<User> userRepository, Guid userID, string tokenKey)
        {
            var user = userRepository.Get(userID);
            if (user != null)
            {
                user.ActiveToken = tokenKey;
                userRepository.Update(user, tokenKey);
            }               
        }

        public static UserView GetUserView(this User user)
        {
            var obj = new UserView();
            obj.FullName = string.Format("{0} {1}", user.FirstName, user.LastName);
            obj.MobileNumber = user.ContactNumber;
            obj.City = user.City;
            obj.EmailID = user.EmailID;
            obj.Gender = user.Gender;
            obj.ParentSponserID = user.ParentSponserID;
            obj.SponserID = user.SponserID;
            obj.UserRole = user.UserRole;
            obj.UserID = user.ID.ToString();
            return obj;
        }
    }
}
