using MLM.DataLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.EntityModel
{
    public class SingleLegIncome : IBaseEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public int SingleLegIncomeID { get; set; }
        public int TotalDirects { get; set; }
        public int TotalTeams { get; set; }
        public DateTime LevelCompleteDate { get; set; }
        public decimal SingleLegIncomeAmount { get; set; }
        public decimal LevelIncomeAmount { get; set; }
        public decimal TotalIncome { get; set; }

        public virtual User User { get; set; }
        public virtual SingleLegIncomeType SingleLegIncomeType { get; set; }
    }
}
