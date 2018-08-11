using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.EntityModel
{
    public class LevelIncomeType
    {
        public int LevelIncomeTypeID { get; set; }
        public int LevelNo { get; set; }
        public decimal IncomePercentage { get; set; }

        public virtual ICollection<LevelIncome> LevelIncomes { get; set; }
    }
}
