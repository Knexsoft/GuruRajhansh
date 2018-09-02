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
        private readonly IBaseRepository<UserPin> _userPinRepository;
        private readonly FranchiseUtilities _franchiseUtilities = new FranchiseUtilities();
        public FranchiseIncomeController(IBaseRepository<FranchiseIncome> franchiseIncomeRepository, IBaseRepository<UserPin> userPinRepository)
        {
            _franchiseIncomeRepository = franchiseIncomeRepository;
            _userPinRepository = userPinRepository;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("AddFranchise")]
        public IActionResult AddFranchise()
        {
            return View();
        }

        [HttpPost("NewFranchise")]
        public IActionResult AddFranchise(FranchiseIncomeReq oFranchise)
        {
            if (oFranchise.FrenchiseIncomeTypeID != 0)
            {
                //_franchiseIncomeRepository
                var _response = _franchiseUtilities.AddNewFrenchise(oFranchise);
                _franchiseIncomeRepository.Add(_response);
                GenratePins(_response, oFranchise);
             //   _franchiseUtilities.CreateNewFrenchisePins(_userPinRepository, oFranchise, _response.ID, _response.UserID);
            }
            return View();
        }


        private void GenratePins(FranchiseIncome franchiseIncome, FranchiseIncomeReq model)
        {
            var _totalPins = model.Pins + model.FreePins;
            for (int i = 0; i < _totalPins; i++)
            {
                var _userPin = new UserPin();
                _userPin.ID = Guid.NewGuid();
                _userPin.FranchiseIncomeID = franchiseIncome.ID.ToString();
                _userPin.UserID = string.Empty;
                _userPin.Pin = _franchiseUtilities.GetRandomPin();
                _userPin.IsUsed = false;
                _userPin.CreatedOn = DateTime.Now;
                _userPinRepository.Add(_userPin);
            }
        }

        [HttpGet]
        [Route("FranchiseIncomeTypesList")]
        public IActionResult FranchiseIncomeTypesList()
        {
            var allFranchiseIncomeType = FranchiseIncomeExtensions.FranchiseIncomeTypeList();
            return Ok(allFranchiseIncomeType);
        }

        [HttpGet]
        [Route("GetFranchiseIncomeTypes")]
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

        [HttpGet("PinsList")]
        public IActionResult PinsList(string franchiseIncomeTypeID)
        {
            return View();
        }

        [HttpGet("GetPinsByID")]
        public IActionResult PinsByID(string franchiseIncomeTypeID)
        {
            var _list = _franchiseUtilities.GetPinListByFrenchiseID(franchiseIncomeTypeID);
            return Ok(_list);
        }
    }
}