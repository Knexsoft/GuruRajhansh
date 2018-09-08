using MLM.Business.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MLM.Business.Utilities
{
    public class LeveIIncomeUtilities
    {
        private static SqlDataReader rdr = null;
        private static SqlCommand cmd = null;
        private static SqlConnection con = null;
        private static string _connection = "Data Source=Kanha;Initial Catalog=MLM;Integrated Security=True";

        public List<LevelIncomeView> GetLevelIncomeByUserID(Guid userID)
        {
            try
            {
                var _lIncomeList = new List<LevelIncomeView>();
                try
                {
                    // Open connection to the database
                    con = new SqlConnection(_connection);
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetLevelIncomeByUserID";
                    cmd.Parameters.Add("@userId", SqlDbType.UniqueIdentifier).Value = userID;
                    cmd.Connection = con;
                    // Execute the query
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        LevelIncomeView _lIncome = new LevelIncomeView();
                        _lIncome.LevelNumber = Convert.ToInt32(rdr["LevelNo"].ToString());
                        _lIncome.Amount = Convert.ToDecimal(rdr["Income"].ToString());
                        _lIncome.CreditOn = Convert.ToDateTime(rdr["CreditOn"].ToString());
                        _lIncomeList.Add(_lIncome);
                    }
                    return _lIncomeList;
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
                return _lIncomeList;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new List<LevelIncomeView>();
            }
        }
    }
}
