using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Models.ViewModels
{
    public class LevelIncomeView
    {
        public int LevelNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreditOn { get; set; }
    }
}
