using MLM.Business.Models.ReqModels;
using MLM.Business.Models.ViewModels;
using MLM.Business.Utilities;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Abstracts
{
    public interface IMembershipService
    {
        UserView ValidateUser(string username, string password);
        User CreateUser(RegistrationRequest regReq);
        User GetUser(int userId);
    }
}
