using MLM.Business.Abstracts;
using MLM.Business.Models.ReqModels;
using MLM.Business.Models.ViewModels;
using MLM.DataLayer.Abstracts;
using MLM.DataLayer.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MLM.Business.Utilities
{
    public class UserUtilities
    {
        #region objects
        private readonly IBaseRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        String strConnString = "Data Source=kanha;Initial Catalog=MLM;Integrated Security=True";
        #endregion

        #region Constructor
        public UserUtilities() { }

        public UserUtilities(IBaseRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public Method

        public List<UserView> GetAllUsersBySponserId(int sponserID)
        {
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_getAllUserBySponserID";
            cmd.Parameters.Add("@sponserID", SqlDbType.Int).Value = sponserID;
            cmd.Connection = con;
            List<UserView> _userList = null;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    _userList = new List<UserView>();
                    while (reader.Read())
                    {
                        UserView _userDetail = new UserView();
                        _userDetail.UserID = reader["ID"].ToString();
                        _userDetail.SponserID = Convert.ToInt32(reader["SponserID"].ToString());
                        _userDetail.ParentSponserID = Convert.ToInt32(reader["ParentSponserID"].ToString());
                        _userDetail.FullName = string.Format("{0} {1}", reader["FirstName"].ToString(), reader["LastName"].ToString());
                        _userDetail.City = reader["City"].ToString();
                        _userDetail.MobileNumber = reader["ContactNumber"].ToString();
                        _userDetail.EmailID = reader["EmailID"].ToString();
                        _userDetail.Gender = reader["Gender"].ToString();
                        _userDetail.ActiveToken = reader["ActiveToken"].ToString();
                        _userDetail.UserRole = reader["UserRole"].ToString();
                        //_userDetail.IsUsed = Convert.ToBoolean(reader["IsUsed"]);
                        _userList.Add(_userDetail);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return _userList;
        }

        public UserProfile GetUserProfile(Guid guid)
        {
            //var _userProfile = _userRepository.Find(x => x.ID == guid);
            // Open connection to the database
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            UserProfile _userDetail = null;
            try
            {
                con.Open();
                string CommandText = "SELECT * FROM Users where ID = '" + guid + "'";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                // Execute the query
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _userDetail = new UserProfile();
                    _userDetail.UserID =Guid.Parse(reader["ID"].ToString());
                    _userDetail.SponserID = Convert.ToInt32(reader["SponserID"].ToString());
                    _userDetail.ParentSponserID = Convert.ToInt32(reader["ParentSponserID"].ToString());
                    _userDetail.FirstName = reader["FirstName"].ToString();
                    _userDetail.LastName = reader["LastName"].ToString();
                    _userDetail.City = reader["City"].ToString();
                    _userDetail.MobileNumber = reader["ContactNumber"].ToString();
                    _userDetail.EmailID = reader["EmailID"].ToString();
                    _userDetail.Gender = reader["Gender"].ToString();
                }
                reader.Close();
                return _userDetail;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return _userDetail;
        }

        public User UpdateUserProfile(UserProfile userProfile)
        {
            var _data = _userRepository.Get(userProfile.UserID);
            if (_data != null)
            {
                _data.FirstName = userProfile.FirstName;
                _data.LastName = userProfile.LastName;
                _data.EmailID = userProfile.EmailID;
                _data.Gender = userProfile.Gender;
                _data.City = userProfile.City;
                _userRepository.Update(_data, userProfile.UserID);
                _unitOfWork.Commit();
            }
            return _data;
        }

        #endregion
    }
}
