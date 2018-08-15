using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLM.Business.Abstracts;
using MLM.Business.Extensions;
using MLM.Business.Models.ReqModels;
using MLM.Business.Services;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;

namespace MLM.UserPanel.UI.Controllers
{
   // [RoutePrefix("api/user")]
    public class UserController : Controller
    {
        private readonly IMembershipService _membershipService;
        private readonly IBaseRepository<User> _userRepository;
        public UserController(IMembershipService membershipService, IBaseRepository<User> userRepository)
        {
            _membershipService = membershipService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        
        public IActionResult Registration()
        {
            return View();
        }

       // [Route("register")]
        [HttpPost]
        public IActionResult Register(RegistrationRequest register)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                else
                {
                    User user = this._membershipService.CreateUser(register);
                        return Ok();
                }
            }
            catch (Exception ex)
            {
                return new ContentResult { Content = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, ContentType = "text/plain" };
            }
        }

        public IActionResult UpdateUserToken(Guid userID, string tokenKey)
        {
            try
            {
                _userRepository.UpdateToken(userID, tokenKey);
                return Ok();
            }
            catch (Exception ex)
            {
                return new ContentResult { Content = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, ContentType = "text/plain" };
            }
        }
    }
}