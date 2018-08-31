using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Models.ReqModels
{
    public class LoginRequest
    {
        public string UserID { get; set; }
        public string Password { get; set; }
    }

    public class RegistrationRequest
    {
        public int ParentSponserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class UserProfile : RegistrationRequest
    {
        public Guid UserID { get; set; }
        public int SponserID { get; set; }
    }
}
