﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Models.ViewModels
{
    public class UserView
    {
        public string UserID { get; set; }
        public int SponserID { get; set; }
        public int ParentSponserID { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string ActiveToken { get; set; }
        public string UserRole { get; set; }
        public bool IsUsed { get; set; }
    }
}
