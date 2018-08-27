using MLM.Business.Models.ReqModels;
using MLM.Business.Models.ViewModels;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace MLM.Business.Utilities
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public UserView User { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }      

    }
}
