using MLM.Business.Abstracts;
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
        //private readonly IBaseRepository<User> _userRepository;
        //private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        //public UserUtilities(IBaseRepository<User> userRepository, IUnitOfWork unitOfWork)
        //{
        //    _userRepository = userRepository;
        //    _unitOfWork = unitOfWork;
        //}
        #endregion

        #region Public Method

        public List<UserView> GetAllUsersBySponserId(int sponserID)
        {
            String strConnString = "Data Source=kanha;Initial Catalog=MLM;Integrated Security=True";
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
                DataTable schemaTable = reader.GetSchemaTable();
                if (reader.HasRows)
                {
                    _userList = new List<UserView>();
                    while (reader.Read())
                    {
                        UserView _userDetail = new UserView();
                        _userDetail.SponserID = Convert.ToInt32(reader["SponserID"].ToString());
                        _userDetail.ParentSponserID = Convert.ToInt32(reader["ParentSponserID"].ToString());
                        _userDetail.FullName = string.Format("{0} {1}", reader["FirstName"].ToString(), reader["LastName"].ToString());
                        _userDetail.City = reader["City"].ToString();
                        _userDetail.MobileNumber = reader["ContactNumber"].ToString();
                        _userDetail.EmailID = reader["EmailID"].ToString();
                        _userDetail.Gender = reader["Gender"].ToString();
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

        #endregion
    }
}
