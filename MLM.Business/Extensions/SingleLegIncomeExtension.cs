using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Extensions
{
    public static class SingleLegIncomeExtension
    {
        public static ICollection<SingleLegIncome> GetSingleLegIncome(this IBaseRepository<SingleLegIncome> sinleLegRepository, Guid userID)
        {
            ICollection<SingleLegIncome> _singleLegIncome = null;
            var obj = sinleLegRepository.FindAll(x => x.UserID == userID);
            if (obj != null)
            {
                return obj;
            }
            return _singleLegIncome;
        }
    }
}
