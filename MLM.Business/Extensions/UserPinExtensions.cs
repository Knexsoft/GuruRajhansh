using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Extensions
{
    public static class UserPinExtensions
    {
        public static void AddTokenNumber(this IBaseRepository<UserPin> userPinRepository, Guid userID, int tokenNumber)
        {
            try
            {
                Guid Id = Guid.NewGuid();
                var userPin = new UserPin()
                {
                    ID = Id,
                    FranchiseIncomeID = "0",
                    UserID = userID.ToString(),
                    Pin = tokenNumber,
                    IsUsed = false,
                    CreatedOn = DateTime.Now
                };
                userPinRepository.Add(userPin);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
