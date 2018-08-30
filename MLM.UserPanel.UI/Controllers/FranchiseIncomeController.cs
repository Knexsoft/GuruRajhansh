using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLM.Business.Models.ReqModels;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;

namespace MLM.UserPanel.UI.Controllers
{
    public class FranchiseIncomeController : Controller
    {
        private readonly IBaseRepository<FranchiseIncome> _franchiseIncomeRepository;
        public FranchiseIncomeController(IBaseRepository<FranchiseIncome> franchiseIncomeRepository)
        {
            _franchiseIncomeRepository = franchiseIncomeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddFranchise(FranchiseIncomeReq frenchiseIncomeReq)
        {
            if(frenchiseIncomeReq.FrenchiseIncomeTypeID != 0)
            {
                _franchiseIncomeRepository
            }
            return View();
        }
    }
}