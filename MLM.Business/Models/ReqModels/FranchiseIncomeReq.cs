using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Models.ReqModels
{
    public class FranchiseIncomeReq
    {
        public int FrenchiseIncomeTypeID { get; set; }
        public int Pins { get; set; }
        public int FreePins { get; set; }
        public decimal Amount { get; set; }
        public string UserID { get; set; }
    }
}
