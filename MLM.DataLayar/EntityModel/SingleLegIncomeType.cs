using MLM.DataLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.EntityModel
{
    public class SingleLegIncomeType
    {
        public int SingleLegIncomeID { get; set; }
        public int LevelNo { get; set; }
        public int Directs { get; set; }
        public int Teams { get; set; }
        public decimal Amount { get; set; }
        public decimal UpgradeCharge { get; set; }

        public virtual ICollection<SingleLegIncome> SingleLegIncomes { get; set; }
    }
}
