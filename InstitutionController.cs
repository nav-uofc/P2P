using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace P2PAPI.Controllers
{
    public class InstitutionController : ApiController
    {
        SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["P2PDBConnection"].ToString());

        // todo: the return types will be imporoved and changed to return JSON
        public int Add(string name, string domain, string country, string province, string city, string postalCode, string streetAddress)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Add_Institution", dbConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;
                    cmd.Parameters.Add("@Domain", SqlDbType.NVarChar, 50).Value = domain;
                    cmd.Parameters.Add("@Country", SqlDbType.NVarChar, 50).Value = country;
                    cmd.Parameters.Add("@Province", SqlDbType.NVarChar, 50).Value = province;
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = postalCode;
                    cmd.Parameters.Add("@StreetAddress", SqlDbType.NVarChar, 50).Value = streetAddress;

                    // Open the DB connection if it is not already open
                    if (dbConn.State != ConnectionState.Open)
                    {
                        dbConn.Open();
                    }
                    cmd.ExecuteNonQuery();
                }

                //jsonNetResult.Data = new { success = true, message = "Success." }; // TODO: the return types will be changed to JSON

                return 1; // SUCCESS
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
                //return new string[] { "value1", "value2" };
                //jsonNetResult.Data = new { success = false, message = "Failed to add Certification." };

                return 0; // FAILED
            }
            finally
            {
                dbConn.Close();
            }
        }

        public int Delete(int institutionId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_Institution", dbConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.Int).Value = institutionId;

                    // Open the DB connection if it is not already open
                    if (dbConn.State != ConnectionState.Open)
                    {
                        dbConn.Open();
                    }
                    cmd.ExecuteNonQuery();
                }
                
                //jsonNetResult.Data = new { success = true, message = "Success." }; // TODO: the return types will be changed to JSON


                return 1; // SUCCESS
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
                //jsonNetResult.Data = new { success = false, message = "Failed." };

                return 0; // FAILED
            }
            finally
            {
                dbConn.Close();
            }
        }
    }
}
