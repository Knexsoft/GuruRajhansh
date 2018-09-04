using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLM.Business.Extensions
{
    public static class UserPinExtension
    {
        public static UserPin BindUserPin(this IBaseRepository<UserPin> userPinRepository, string userID)
        {
            var obj = userPinRepository.GetAll().FirstOrDefault(x => x.UserID == userID);
            if (obj == null)
            {
                obj = new UserPin();
                obj.ID = Guid.NewGuid();
                obj.UserID = userID;
                obj.CreatedOn = DateTime.Now;
                obj.IsUsed = true;
                obj.Pin = GenratePin();
                userPinRepository.Add(obj);
            }
            return obj;
        }

        public static bool ValidatePin(this IBaseRepository<UserPin> userPinRepository, int pin)
        {
            bool _flag = false;
            var obj = userPinRepository.GetAll().FirstOrDefault(x => x.Pin == pin);
            if (obj != null)
            {
                _flag = true;
            }
            return _flag;
        }

        public static bool ActivateAccountPin(this IBaseRepository<User> userRepository,int pin,Guid userID)
        {
            bool _flag = false;
            var _oUser = userRepository.GetAll().FirstOrDefault(x => x.ID == userID);
            if(_oUser != null)
            {
                _oUser.ActiveToken = pin.ToString();
                _oUser.ModifiedOn = DateTime.Now;
                userRepository.Update(_oUser, userID);
                _flag = true;
            }
            return _flag;
        }

        public static void UpdatePin(this IBaseRepository<UserPin> userPinRepository, int pin,string userId)
        {
            var obj = userPinRepository.GetAll().FirstOrDefault(x => x.Pin == pin);
            if (obj != null)
            {
                obj.IsUsed = true;
                obj.UserID = userId;
                userPinRepository.Update(obj, obj.ID);
            }
        }

        //Helper method
        private static int GenratePin()
        {
            Random _random = new Random();
            return _random.Next(10000000, 99999999);
        }
    }
}
