using MLM.Business.Abstracts;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLM.Business.Utilities
{
    public class UserPinUtilities
    {
        #region objects
        private readonly IBaseRepository<UserPin> _userPinRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor

        public UserPinUtilities() { }

        public UserPinUtilities(IBaseRepository<UserPin> userPinRepository, IUnitOfWork unitOfWork)
        {
            _userPinRepository = userPinRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public methods

        public UserPin AddTokenNumber(Guid userID, int tokenNumber)
        {
            try
            {
                Guid Id = Guid.NewGuid();
                var user = new UserPin()
                {
                    ID = Id,
                    FranchiseIncomeID = string.Empty,
                    UserID = userID.ToString(),
                    Pin = tokenNumber,
                    IsUsed = false,
                    CreatedOn = DateTime.Now
                };
                _userPinRepository.Add(user);
                _unitOfWork.Commit();
                return user;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return new UserPin();
            }

        }

        #endregion
    }
}
