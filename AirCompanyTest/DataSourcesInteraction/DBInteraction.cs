using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace AirCompanyTest
{
    class DBInteraction
    {
    public SqlConnection Connect()
        {
            string connectionStringNort = ConfigurationManager.AppSettings["cnStr"];
            var conn = new SqlConnection();
            Console.WriteLine("Connection object --> " + conn.GetType().Name);
            conn.ConnectionString = connectionStringNort;
            conn.Open();
            return conn;
        }
    public void SelectTopProducts(SqlConnection conn)
        {
            DbCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select top 3 * From Products where UnitPrice > 20 ORDER By UnitsInStock DESC";
            // Read line by line using ExecuteReader::Read
            using (var dr = cmd.ExecuteReader())
            {
                Console.WriteLine("Read data object --> " + dr.GetType().Name);
                Console.WriteLine("\n*** Current content of Products***\n");
                while (dr.Read())
                {
                    Console.WriteLine(
                        "-> Product ID: {0}, Product Name: {1}, Quantity Per Unit: {2}, Unit Price: {3}, Units In Stock: {4}\n",
                        dr["ProductID"],
                        dr["ProductName"],
                        dr["QuantityPerUnit"],
                        dr["UnitPrice"],
                        dr["UnitsInStock"]);
                }
            }
        }
    public int InsertIntoRegions(SqlConnection conn,int id)
        {
            string commandText = string.Format("INSERT INTO Region VALUES (@id,'EMEA')", id);
            int numberOfAffectedRows = 0;
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    numberOfAffectedRows = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    var error = new Exception("Couldn't insert into Regions", ex);
                    throw error;
                }
                catch (SystemException ex)
                {
                    var error = new Exception("Couldn't insert into Regions", ex);
                    throw error;
                }
            }

            return numberOfAffectedRows;
        }
    public void SelectRegions(SqlConnection conn)
        {
            DbCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * From Region ORDER By RegionID DESC";
            using (var dr = cmd.ExecuteReader())
            {
                Console.WriteLine("Read data object --> " + dr.GetType().Name);
                Console.WriteLine("\n*** Current content of Region***\n");
                while (dr.Read())
                {
                    Console.WriteLine(
                        "-> Region ID: {0}, Region Description: {1}\n",
                        dr["RegionID"],
                        dr["RegionDescription"]
                        );
                }
            }
        }
    public int UpdateRegionByID(SqlConnection conn,int id)
        {
            string commandText = string.Format("UPDATE Region SET RegionDescription = 'Belarus' WHERE RegionID = @id", id);
            int numberOfAffectedRows = 0;
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    numberOfAffectedRows = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    var error = new Exception("Couldn't update Regions", ex);
                    throw error;
                }
            }
            return numberOfAffectedRows;
        }
        public int DeleteRegionByID(SqlConnection conn,int id)
        {
            string commandText = string.Format("DELETE FROM Region WHERE RegionID = @id", id);
            int numberOfAffectedRows = 0;
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    numberOfAffectedRows = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    var error = new Exception("Couldn't delete Region", ex);
                    throw error;
                }
                ;
            }
            return numberOfAffectedRows;
        }
        public void SelectCustomerOrdersUsingStoredProcedure(SqlConnection conn, string custID)
        {
            SqlDataReader rdr = null;
            Console.WriteLine("\nCustomer Orders:\n");
            try
            {
                SqlCommand cmd = new SqlCommand("CustOrdersOrders", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@CustomerID", custID));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(
                        "Order: {0,-35} Total: {1,2}",
                        rdr["OrderID"],
                        rdr["OrderDate"]);
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
        }
    }



 }


