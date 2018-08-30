using System;
using System.Collections.Generic;
using System.Text;
using MLM.Business.Models.ReqModels;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;

namespace MLM.Business.Utilities
{
    public class FranchiseUtilities
    {
        #region objects
        private readonly IBaseRepository<FranchiseIncome> _franchiseIncomeRepository;
        private readonly IBaseRepository<UserPin> _userPinRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public FranchiseUtilities() { }

        public FranchiseUtilities(IBaseRepository<FranchiseIncome> franchiseIncomeRepository, IUnitOfWork unitOfWork, IBaseRepository<UserPin> userPinRepository)
        {
            _franchiseIncomeRepository = franchiseIncomeRepository;
            _userPinRepository = userPinRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Method

        public FranchiseIncome AddNewFrenchise(FranchiseIncomeReq model)
        {
            var _frenchiseIncome = new FranchiseIncome();
            _frenchiseIncome.ID = Guid.NewGuid();
            _frenchiseIncome.UserID = Guid.Parse(model.UserID);
            _frenchiseIncome.FranchiseIncomeTypeID = model.FrenchiseIncomeTypeID;
            _frenchiseIncome.TotalAmount = model.Amount;
            _frenchiseIncome.Income = model.Amount;
            _franchiseIncomeRepository.Add(_frenchiseIncome);
            _unitOfWork.Commit();
            return _frenchiseIncome;
        }

        public void CreateNewFrenchisePins(FranchiseIncomeReq model,Guid FranchiseIncomeID,Guid UserID)
        {
            var _totalPins = model.Pins + model.FreePins;
            for (int i = 0; i <= _totalPins; i++)
            {
                var _userPin = new UserPin();
                _userPin.ID = Guid.NewGuid();
                _userPin.FranchiseIncomeID = FranchiseIncomeID;
                _userPin.UserID = UserID;
                _userPin.Pin = GetRandomPin();
                _userPin.IsUsed = false;
                _userPin.CreatedOn = DateTime.Now;
                _userPinRepository.Add(_userPin);
                _unitOfWork.Commit();
            }
        }

        public int GetRandomPin()
        {
            Random _random = new Random();
            int _num = _random.Next(10000000, 99999999);
            return _num;
        }

        public ICollection<UserPin> GetPinListByUserID(Guid userID)
        {
            var _list = _userPinRepository.FindAll(x => x.UserID == userID);
            return _list;
        }

        #endregion
    }
}
