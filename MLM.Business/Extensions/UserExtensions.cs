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
    }
}
