using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Models.ViewModels
{
   public class DashboardView
    {
        public int ActiveUsers { get; set; }
        public int DeactiveUsers { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal WidralAmount { get; set; }
    }
}
