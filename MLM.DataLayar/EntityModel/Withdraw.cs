using MLM.DataLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.EntityModel
{
    public class Withdraw : IBaseEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal WithdrawAmount { get; set; }
        public string TransectionID { get; set; }
        public DateTime WithdrawOn { get; set; }
        public DateTime CeatedOn { get; set; }

        public virtual LevelIncomeType LevelIncomeType { get; set; }
    }
}
