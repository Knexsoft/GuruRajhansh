using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLM.Business.Abstracts;

namespace MLM.UserPanel.UI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ISessionHandler _sessionHandler;

        public DashboardController(ISessionHandler sessionHandler)
        {
            _sessionHandler = sessionHandler;
        }

        public IActionResult Index()
        {
            var user = _sessionHandler.GetUser(); 
            return View();
        }
    }
}