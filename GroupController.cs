using System;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace P2PAPI.Controllers
{
    public class GroupController : ApiController
    {
        SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["P2PDBConnection"].ToString());

        // todo: the return types will be imporoved and changed to return JSON
        public int Add(int groupOwnerUserId, string name, string description)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Add_Group", dbConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GroupOwnerUserId", SqlDbType.Int).Value = groupOwnerUserId;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = description;

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

        public int Delete(int groupId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_Group", dbConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = groupId;

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

        public int Update(int groupId, int groupOwnerUserId, string name, string description)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_Group", dbConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GroupId", SqlDbType.Int).Value = groupId;
                    cmd.Parameters.Add("@GroupOwnerUserId", SqlDbType.Int).Value = groupOwnerUserId;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = description;

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

        public DataTable GetOne(int groupId)
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("sp_Select_One_Group", dbConn))
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