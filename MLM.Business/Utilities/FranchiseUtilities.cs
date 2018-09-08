using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        private static SqlDataReader rdr = null;
        private static SqlCommand cmd = null;
        private static SqlConnection con = null;
        private static string _connection = "Data Source=LAPTOP-5B2JV023\\SQLEXPRESS;Initial Catalog=MLM;Integrated Security=True";

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
            var _ID = Guid.NewGuid();
            var _oData = _franchiseIncomeRepository.Get(_ID);
            if(_oData == null)
            {
                var _frenchiseIncome = new FranchiseIncome();
                _frenchiseIncome.ID = _ID;
                _frenchiseIncome.UserID = Guid.Parse(model.UserID);
                _frenchiseIncome.FranchiseIncomeTypeID = model.FrenchiseIncomeTypeID;
                _frenchiseIncome.TotalAmount = model.Amount;
                _frenchiseIncome.Income = model.Amount;
                _frenchiseIncome.CreatedOn = DateTime.Now;
                _frenchiseIncome.IsActive = false;
                _franchiseIncomeRepository.Add(_frenchiseIncome);
                _unitOfWork.Commit();
            }
            return _oData;
        }

        public void CreateNewFrenchisePins(IBaseRepository<UserPin> userPinRepository, FranchiseIncomeReq model, Guid FranchiseIncomeID, Guid UserID)
        {
            var _totalPins = model.Pins + model.FreePins;
            for (int i = 0; i <= _totalPins; i++)
            {
                var _userPin = new UserPin();
                _userPin.ID = Guid.NewGuid();
                _userPin.FranchiseIncomeID = FranchiseIncomeID.ToString();
                _userPin.UserID = string.Empty;
                _userPin.Pin = GetRandomPin();
                _userPin.IsUsed = false;
                _userPin.CreatedOn = DateTime.Now;
                userPinRepository.Add(_userPin);
            }
        }

        public int GetRandomPin()
        {
            Random _random = new Random();
            int _num = _random.Next(10000000, 99999999);
            return _num;
        }

        public List<UserPin> GetPinListByFrenchiseID(string franchiseIncomeTypeID)
        {
            try
            {
                var _userPinList = new List<UserPin>();
                try
                {
                    // Open connection to the database
                    string ConnectionString = _connection;
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                    string CommandText = "SELECT * FROM UserPins where FranchiseIncomeID ='" + franchiseIncomeTypeID + "'";
                    cmd = new SqlCommand(CommandText);
                    cmd.Connection = con;
                    // Execute the query
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        UserPin _upin = new UserPin();
                        _upin.UserID = rdr["UserID"].ToString();
                        _upin.Pin = Convert.ToInt32(rdr["Pin"].ToString());
                        _upin.IsUsed = Convert.ToBoolean(rdr["IsUsed"].ToString());
                        _upin.CreatedOn = Convert.ToDateTime(rdr["CreatedOn"].ToString());
                        _userPinList.Add(_upin);
                    }
                    return _userPinList;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
                finally
                {
                    // Close data reader object and database connection
                    if (rdr != null)
                        rdr.Close();

                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
                return _userPinList;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new List<UserPin>();
            }
        }

        #endregion
    }
}
