using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLM.Business.Abstracts;
using MLM.Business.Extensions;
using MLM.Business.Models.ReqModels;
using MLM.Business.Utilities;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MLM.UserPanel.UI.Controllers
{
    [Authorize]
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private readonly IMembershipService _membershipService;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<UserPin> _userPinRepository;
        private readonly ISessionHandler _sessionHandler;
        private readonly UserUtilities _userUtilities = new UserUtilities(); // added by SB
        private readonly UserPinUtilities _userPinUtilities = new UserPinUtilities();

        public UserController(IMembershipService membershipService, 
            IBaseRepository<User> userRepository, 
            IBaseRepository<UserPin> userPinRepository, 
            ISessionHandler sessionHandler)
        {
            _membershipService = membershipService;
            _userRepository = userRepository;
            _sessionHandler = sessionHandler;
            _userPinRepository = userPinRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                else
                {
                    string mobileNumber = login.UserID.Trim();
                    var user = _membershipService.ValidateUser(mobileNumber, login.Password);
                    if (user != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.FullName),
                            new Claim(ClaimTypes.MobilePhone, user.MobileNumber),
                            new Claim(ClaimTypes.Authentication, user.ActiveToken)
                        };
                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                        await HttpContext.SignInAsync(principal);
                        _sessionHandler.SetUser(user);
                        return new JsonResult(user);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [AllowAnonymous]
        [HttpGet("Registration")]
        public IActionResult Registration()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(RegistrationRequest register)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                else
                {
                    User user = this._membershipService.CreateUser(register);
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return new ContentResult { Content = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, ContentType = "text/plain" };
            }
        }

        [HttpGet("Welcome")]
        public IActionResult Welcome()
        {
            return View();
        }

        [HttpPost("UpdateToken")]
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

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        // added by SB 29-28-2018
        [AllowAnonymous]
        [HttpGet("GetUserBySponserID")]
        public IActionResult GetUserBySponserID(int sponserID = 0)
        {
            try
            {
                if (sponserID > 0)
                {
                    var _allUsers = _userUtilities.GetAllUsersBySponserId(sponserID);
                    return Ok(_allUsers);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return new ContentResult { Content = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, ContentType = "text/plain" };
            }
        }

        [AllowAnonymous]
        [HttpGet("GenrateUserPin")]
        public IActionResult GenrateUserPin(string userID, string mobileNo)
        {
            try
            {
                var obj = _userPinRepository.BindUserPin(userID);
                if(obj != null)
                {
                   _userRepository.UpdateTokenByUserID(userID, obj.Pin);
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return new ContentResult { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        [Authorize]
        [HttpGet("UserProfile")]
        public IActionResult ViewProfile()
        {
            return View();
        }

        [Authorize]
        [HttpPost("UserProfile")]
        public IActionResult ViewProfile(UserProfile profile)
        {
            UserExtensions.UpdateUserProfile(_userRepository, profile);
            return Ok();
        }

        [HttpGet("GetProfile")]
        public IActionResult GetProfile(Guid userID)
        {
            var _data = _userUtilities.GetUserProfile(userID);
            return Ok(_data);
        }

        [HttpGet("GetTeamInfoBySponserID")]
        public IActionResult GetTeamInfo(string sponserID)
        {
            var _dashData = _userUtilities.GetTeamInfoBySponserId(Convert.ToInt32(sponserID));
            return Ok(_dashData);
        }


    }
}