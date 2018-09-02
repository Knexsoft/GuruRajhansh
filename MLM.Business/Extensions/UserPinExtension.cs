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

        //Helper method
        private static int GenratePin()
        {
            Random _random = new Random();
            return _random.Next(10000000, 99999999);
        }
    }
}
