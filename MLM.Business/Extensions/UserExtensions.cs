﻿using MLM.Business.Models.ReqModels;
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

        public static void UpdateTokenByUserID(this IBaseRepository<User> userRepository, string userID, int pin)
        {
            var id = new Guid(userID);
            var oUser = userRepository.GetAll().FirstOrDefault(x => x.ID == id);
            if(oUser != null && !string.IsNullOrEmpty(pin.ToString()))
            {
                oUser.ActiveToken = pin.ToString();
                oUser.ModifiedOn = DateTime.Now;
                userRepository.Update(oUser, id);
            }
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
            obj.ActiveToken = string.IsNullOrEmpty(user.ActiveToken) ? "0" : user.ActiveToken;
            return obj;
        }

        public static void UpdateUserProfile(this IBaseRepository<User> userRepository, UserProfile profile)
        {
            var user = userRepository.Get(profile.UserID);
            if (user != null)
            {
                user.FirstName = profile.FirstName;
                user.LastName = profile.LastName;
                user.EmailID = profile.EmailID;
                user.Gender = profile.Gender;
                user.City = profile.City;
                userRepository.Update(user,profile.UserID);
            }
        }

        public static User GetParentInfoBySponserID(this IBaseRepository<User> userRepository,int sponserID)
        {
            var userInfo = userRepository.GetAll().FirstOrDefault(x => x.SponserID == sponserID);
            return userInfo;
        }
    }
}
