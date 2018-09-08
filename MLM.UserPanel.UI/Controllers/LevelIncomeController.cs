using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLM.Business.Utilities;

namespace MLM.UserPanel.UI.Controllers
{
    [Authorize]
    [Route("[Controller]")]
    public class LevelIncomeController : Controller
    {
        private readonly LeveIIncomeUtilities _leveIIncomeUtilities = new LeveIIncomeUtilities();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetLevelIncome")]
        public IActionResult GetLevelIncome(Guid userId)
        {
            var _levelIncome = _leveIIncomeUtilities.GetLevelIncomeByUserID(userId);
            return Ok(_levelIncome);
        }
    }
}