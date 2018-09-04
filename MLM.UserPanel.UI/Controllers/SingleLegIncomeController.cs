using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLM.Business.Extensions;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;

namespace MLM.UserPanel.UI.Controllers
{
    public class SingleLegIncomeController : Controller
    {
        private readonly IBaseRepository<SingleLegIncome> _singleLegIncomeRepository;
        public SingleLegIncomeController(IBaseRepository<SingleLegIncome> singleLegIncomePinRepository)
        {
            _singleLegIncomeRepository = singleLegIncomePinRepository;
        }

        [Authorize]
        [Route("[Controller]")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetSingleLegIncome")]
        public IActionResult GetSingleLegIncome(Guid userID)
        {
            var _data = SingleLegIncomeExtension.GetSingleLegIncome(_singleLegIncomeRepository, userID);
            return Ok(_data);
        }
    }
}