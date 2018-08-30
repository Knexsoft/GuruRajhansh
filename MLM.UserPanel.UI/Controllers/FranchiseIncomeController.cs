using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLM.Business.Models.ReqModels;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;
using MLM.Business.Extensions;
using Microsoft.AspNetCore.Authorization;
using MLM.Business.Utilities;

namespace MLM.UserPanel.UI.Controllers
{
    [Route("[Controller]")]
    public class FranchiseIncomeController : Controller
    {
        private readonly IBaseRepository<FranchiseIncome> _franchiseIncomeRepository;
        private readonly FranchiseUtilities _franchiseUtilities = new FranchiseUtilities();
        public FranchiseIncomeController(IBaseRepository<FranchiseIncome> franchiseIncomeRepository)
        {
            _franchiseIncomeRepository = franchiseIncomeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddFranchise()
        {
            FranchiseIncomeTypes();
            GetFranchiseDetailByPin(10);
            return View();
        }

        [HttpPost("AddFranchise")]
        public IActionResult AddFranchise(FranchiseIncomeReq oFranchise)
        {
            if (oFranchise.FrenchiseIncomeTypeID != 0)
            {
                //_franchiseIncomeRepository
                var _response = _franchiseUtilities.AddNewFrenchise(oFranchise);
                _franchiseUtilities.CreateNewFrenchisePins(oFranchise, _response.ID, _response.UserID);
            }
            return View();
        }

        [HttpGet("GetFranchiseIncomeTypes")]
        public IActionResult FranchiseIncomeTypes()
        {
            var allFranchiseIncomeType = FranchiseIncomeExtensions.GetAllFranchiseIncomeType();
            return Ok(allFranchiseIncomeType);
        }

        [HttpGet("GetFranchiseDetailByPin")]
        public IActionResult GetFranchiseDetailByPin(int oPin)
        {
            var franchiseIncomeType = FranchiseIncomeExtensions.FindFranchiseIncomeTypeByPin(oPin);
            return Ok(franchiseIncomeType);
        }

        [HttpGet("Pins")]
        public IActionResult PinsList(string userID)
        {
            var _list = _franchiseUtilities.GetPinListByUserID(Guid.Parse(userID));
            return View();
        }
    }
}