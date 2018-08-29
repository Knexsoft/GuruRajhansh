using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MLM.UserPanel.UI.Controllers
{
    public class SingleLegIncomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}