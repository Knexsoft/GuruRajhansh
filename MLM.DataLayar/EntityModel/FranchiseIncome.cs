using MLM.DataLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.EntityModel
{
    public class FranchiseIncome : IBaseEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public int FranchiseIncomeTypeID { get; set; }
        public decimal TotalAmount { get; set; }
        public Decimal Income { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual FranchiseIncomeType FranchiseIncomeType { get; set; }
        // public virtual UserPin UserPin { get; set; }
    }
}
