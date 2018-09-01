using MLM.DataLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.EntityModel
{
    public class User : IBaseEntity
    {
        public Guid ID { get; set; }
        public int SponserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string UserRole { get; set; }
        public string PasswordSalt { get; set; }
        public string HashPassword { get; set; }
        public int ParentSponserID { get; set; }
        public bool IsActive { get; set; }
        public string ActiveToken { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<SingleLegIncome> SingleLegIncomes { get; set; }
        public virtual ICollection<LevelIncome> LevelIncomes { get; set; }
        public virtual ICollection<FranchiseIncome> FrenchiseIncomes { get; set; }
    }

    public enum UserRole
    {
        Admin = 0,
        Member = 1
    }
}
