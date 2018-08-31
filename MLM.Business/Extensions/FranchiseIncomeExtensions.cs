﻿using System;
using System.Collections.Generic;
using MLM.Business.Models.ReqModels;
using System.Text;
using MLM.DataLayer.Abstracts;
using System.Data.SqlClient;
using System.Data;
using MLM.DataLayer.EntityModel;

namespace MLM.Business.Extensions
{
    public static class FranchiseIncomeExtensions
    {
        private static SqlDataReader rdr = null;
        private static SqlCommand cmd = null;
        private static SqlConnection con = null;

        public static List<KeyValuePair<string, string>> GetAllFranchiseIncomeType()
        {
            var _franchiseIncomeTypeList = new List<KeyValuePair<string, string>>();
            //_franchiseIncomeTypeList.Add(new KeyValuePair<string, string>("-- Select --", "0"));
            //List<FranchiseIncomeReq> _franchiseIncomeTypeList = new List<FranchiseIncomeReq>();
            try
            {
                // Open connection to the database
                string ConnectionString = "Data Source=kanha;Initial Catalog=MLM;Integrated Security=True";
                con = new SqlConnection(ConnectionString);
                con.Open();
                string CommandText = "SELECT * FROM FranchiseIncomeTypes";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                // Execute the query
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    _franchiseIncomeTypeList.Add(new KeyValuePair<string, string>(rdr["Pins"].ToString(), rdr["Pins"].ToString()));
                }
                return _franchiseIncomeTypeList;
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
            return _franchiseIncomeTypeList;
        }

        public static FranchiseIncomeReq FindFranchiseIncomeTypeByPin(int oPin)
        {
            try
            {
                FranchiseIncomeReq _frq = null;
                // Open connection to the database
                string ConnectionString = "Data Source=kanha;Initial Catalog=MLM;Integrated Security=True";
                con = new SqlConnection(ConnectionString);
                con.Open();
                string CommandText = "SELECT * FROM FranchiseIncomeTypes where Pins = '" + oPin + "'";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                // Execute the query
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    _frq = new FranchiseIncomeReq();
                    _frq.FrenchiseIncomeTypeID = Convert.ToInt32(rdr["FranchiseIncomeTypeID"].ToString());
                    _frq.Pins = Convert.ToInt32(rdr["Pins"].ToString());
                    _frq.FreePins = Convert.ToInt32(rdr["FreePins"].ToString());
                    _frq.Amount = Convert.ToDecimal(rdr["Amount"].ToString());
                }
                return _frq;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return new FranchiseIncomeReq();
            }
            finally
            {
                // Close data reader object and database connection
                if (rdr != null)
                    rdr.Close();

                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public static FranchiseIncomeReq AddNewFranchise(FranchiseIncomeReq req)
        {
            try
            {
                var Id = Guid.NewGuid();
                FranchiseIncomeReq _frq = null;
                // Open connection to the database
                string ConnectionString = "Data Source=kanha;Initial Catalog=MLM;Integrated Security=True";
                con = new SqlConnection(ConnectionString);
                con.Open();
                string CommandText = "INSERT INTO dbo.FranchiseIncomes (ID,UserID,FranchiseIncomeID,TotalAmount,Income,CreatedOn)" +
                   "VALUES ('"+Id+"','"+req.Pins +"','"+req.FrenchiseIncomeTypeID+"','"+req.Amount+"','"+req.Amount+"','"+ DateTime.Now+"') ";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                return _frq;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return new FranchiseIncomeReq();
            }
            finally
            {
                // Close data reader object and database connection
                if (rdr != null)
                    rdr.Close();

                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public static List<FranchiseIncomeType> AllFranchiseIncomeType()
        {
            var _franchiseIncomeTypeList = new List<FranchiseIncomeType>();
            try
            {
                // Open connection to the database
                string ConnectionString = "Data Source=kanha;Initial Catalog=MLM;Integrated Security=True";
                con = new SqlConnection(ConnectionString);
                con.Open();
                string CommandText = "SELECT * FROM FranchiseIncomeTypes";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                // Execute the query
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    FranchiseIncomeType frq = new FranchiseIncomeType();
                    frq.Pins =Convert.ToInt32(rdr["Pins"].ToString());
                    frq.FreePins = Convert.ToInt32(rdr["FreePins"].ToString());
                    frq.Amount = Convert.ToDecimal(rdr["Amount"].ToString());
                    _franchiseIncomeTypeList.Add(frq);
                }
                return _franchiseIncomeTypeList;
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
            return _franchiseIncomeTypeList;
        }
    }
}
