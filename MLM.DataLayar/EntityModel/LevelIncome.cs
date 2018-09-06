using MLM.DataLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.DataLayer.EntityModel
{
    public class LevelIncome : IBaseEntity
    {
        public Guid ID { get; set; }
        public string UserID { get; set; }
        public Decimal Income { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
