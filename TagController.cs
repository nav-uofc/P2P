using System;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace P2PAPI.Controllers
{
    public class TagController : ApiController
    {
        SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["P2PDBConnection"].ToString());

        // todo: the return types will be imporoved and changed to return JSON
        public int Add(string value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Add_Tag", dbConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Value", SqlDbType.NVarChar, 50).Value = value;

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
                // TODO :: We will add a module to log errors, also all the return types will be in JSON
                //Log.Error(ex);
                //jsonNetResult.Data = new { success = false, message = "Failed." };

                return 0; // FAILED
            }
            finally
            {
                dbConn.Close();
            }
        }

        public int Delete(int tagId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_Tag", dbConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TagId", SqlDbType.Int).Value = tagId;

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
                // TODO :: We will add a module to log errors, also all the return types will be in JSON
                //Log.Error(ex);
                //jsonNetResult.Data = new { success = false, message = "Failed." };

                return 0; // FAILED
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataTable GetAll()
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("sp_Select_All_Tags", dbConn))
                {
                    // Open the DB connection if it is not already open
                    if (dbConn.State != ConnectionState.Open)
                    {
                        dbConn.Open();
                    }

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(data);
                }

                // TODO: the return types will be changed to JSON
                 
                return data; // SUCCESS
            }
            catch (Exception ex)
            {
                // TODO :: We will add a module to log errors, also all the return types will be in JSON
                //Log.Error(ex);
                //jsonNetResult.Data = new { success = false, message = "Failed." };

                return null; // FAILED
            }
            finally
            {
                dbConn.Close();
            }
        }

        public DataTable GetGroupTags(int groupId)
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("sp_Select_Tags_For_Group", dbConn))
                {
                    // Open the DB connection if it is not already open
                    if (dbConn.State != ConnectionState.Open)
                    {
                        dbConn.Open();
                    }

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@GroupId", SqlDbType.Int).Value = groupId;
                    da.Fill(data);
                }

                // TODO: the return types will be changed to JSON

                return data; // SUCCESS
            }
            catch (Exception ex)
            {
                // TODO :: We will add a module to log errors, also all the return types will be in JSON
                //Log.Error(ex);
                //jsonNetResult.Data = new { success = false, message = "Failed." };

                return null; // FAILED
            }
            finally
            {
                dbConn.Close();
            }
        }
    }
}