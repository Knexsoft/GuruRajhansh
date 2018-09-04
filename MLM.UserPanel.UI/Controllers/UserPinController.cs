using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;
using MLM.Business.Extensions;

namespace MLM.UserPanel.UI.Controllers
{
    [Authorize]
    [Route("[Controller]")]
    public class UserPinController : Controller
    {

        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<UserPin> _userPinRepository;
        public UserPinController(IBaseRepository<User> userRepository, IBaseRepository<UserPin> userPinRepository)
        {
            _userRepository = userRepository;
            _userPinRepository = userPinRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Activate")]
        public IActionResult Activate()
        {
            return View();
        }

        [HttpGet("ActivateToken")]
        public IActionResult Token(int pin, Guid userId)
        {
            var _flag = UserPinExtension.ValidatePin(_userPinRepository,pin);
            if (_flag)
            {
                var _res = UserPinExtension.ActivateAccountPin(_userRepository, pin, userId);
                if (_res)
                {
                    UserPinExtension.UpdatePin(_userPinRepository, pin, userId.ToString());
                    return Ok();
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}