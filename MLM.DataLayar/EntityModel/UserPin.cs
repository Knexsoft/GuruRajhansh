using MLM.DataLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.EntityModel
{
    public class UserPin : IBaseEntity
    {
        public Guid ID { get; set; }
        public string FranchiseIncomeID { get; set; }
        public string UserID { get; set; }
        public int Pin { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedOn { get; set; }

        //public virtual FranchiseIncome FranchiseIncome { get; set; }
        //public virtual User User { get; set; }
    }
}
