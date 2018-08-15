using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLM.Business.Abstracts;
using MLM.Business.Extensions;
using MLM.Business.Models.ReqModels;
using MLM.Business.Services;
using MLM.Business.Utilities;
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

        //public IActionResult Login()
        //{

        //    return View();
        //}

        [HttpPost]
        public IActionResult Login(LoginRequest entity)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                else
                {
                    var entityModel = new MembershipContext();
                    string mobile = entity.UserID;
                    string password = entity.Password;

                    entityModel = this._membershipService.ValidateUser(mobile, password);

                    string user = null;
                    string role = null;
                    HttpContext.Session.SetString(user, entityModel.User.FirstName);
                    HttpContext.Session.SetString(role, entityModel.User.UserRole);

                   
                }
                return Redirect("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }       
                       
        }

        public IActionResult Registeration() 
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
                if(userID==Guid.Empty||tokenKey==null)
                    throw new Exception("parameter null");
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