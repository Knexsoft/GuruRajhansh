using MLM.Business.Abstracts;
using MLM.Business.Extensions;
using MLM.Business.Models.ReqModels;
using MLM.Business.Utilities;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace MLM.Business.Services
{
    public class MembershipService : IMembershipService
    {
        #region objects
        private readonly IBaseRepository<User> _userRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public MembershipService(IBaseRepository<User> userRepository, IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public methods
        public User CreateUser(RegistrationRequest regReq)
        {
            var existingUser = _userRepository.GetUserByMobile(regReq.MobileNumber);
            if (existingUser != null)
            {
                throw new Exception("Mobile No is already in use");
            }

            var _passwordSalt = _encryptionService.CreateSalt();
            var _hashPassword = _encryptionService.EncryptPassword(regReq.Password, _passwordSalt);
            var _userRole = UserRole.Member.ToString();
            Guid Id = Guid.NewGuid();
            var user = new User()
            {
                SponserID = CreateSponserID(),
                ParentSponserID = regReq.ParentSponserID,
                FirstName = regReq.FirstName,
                LastName = regReq.LastName,
                ContactNumber = regReq.MobileNumber,
                EmailID = regReq.EmailID,
                Gender = regReq.Gender,
                DOB = regReq.DOB,
                City = regReq.City,
                UserRole = _userRole,
                PasswordSalt = _passwordSalt,
                HashPassword = _hashPassword,
                IsActive = true,
                IsDeleted = false,
                ModifiedOn = DateTime.MinValue,
                CreatedOn = DateTime.Now
            };
            _userRepository.Add(user);
            _unitOfWork.Commit();
            return user;
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public MembershipContext ValidateUser(string mobile, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = _userRepository.GetUserByMobile(mobile);
            if (user != null && isUserValid(user, password))
            {
                string[] userRoles = new string[2];
                userRoles[0] = user.UserRole;
                membershipCtx.User = user;

                var identity = new GenericIdentity(user.ContactNumber);
                membershipCtx.Principal = new GenericPrincipal(
                    identity,
                    userRoles);
            }

            return membershipCtx;
        }
        #endregion

        #region Helpers
        private bool isUserValid(User user, string password)
        {
            if (isPasswordValid(user, password))
                return !user.IsDeleted;
            else
                return false;
        }

        private bool isPasswordValid(User user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.PasswordSalt), user.HashPassword);
        }

        private int CreateSponserID()
        {
            int initSponserID = 100001;
            int prevSponserID = _userRepository.All.OrderByDescending(x => x.SponserID).Select(x => x.SponserID).FirstOrDefault();
            return prevSponserID == 0 ? initSponserID : prevSponserID++;
        }

        #endregion
    }
}
