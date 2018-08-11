using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.EntityModel
{
    public class FranchiseIncomeType
    {
        public int FranchiseIncomeTypeID { get; set; }
        public int Pins { get; set; }
        public int FreePins { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<FranchiseIncome> FranchiseIncomes { get; set; }

    }
}
