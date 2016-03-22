using System;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace P2PAPI.Controllers
{
    public class UserController : ApiController
    {
        SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["P2PDBConnection"].ToString());

        // todo: the return types will be imporoved and changed to return JSON
        public int Add(string password, string firstName, string lastName, string middleName, string briefBio, string email, string userType, string staffId,
            string staffPosition, string studentId, string studentProgram, int studentYear, string studentLevel, int institutionId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Add_User", dbConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = firstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = lastName;
                    cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 50).Value = middleName;
                    cmd.Parameters.Add("@BriefBio", SqlDbType.NVarChar, 50).Value = briefBio;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
                    cmd.Parameters.Add("@UserType", SqlDbType.NVarChar, 50).Value = userType;
                    cmd.Parameters.Add("@StaffId", SqlDbType.NVarChar, 50).Value = staffId;
                    cmd.Parameters.Add("@StaffPosition", SqlDbType.NVarChar, 50).Value = staffPosition;
                    cmd.Parameters.Add("@StudentId", SqlDbType.NVarChar, 50).Value = studentId;
                    cmd.Parameters.Add("@StudentProgram", SqlDbType.NVarChar, 50).Value = studentProgram;
                    cmd.Parameters.Add("@StudentYear", SqlDbType.Int).Value = studentYear;
                    cmd.Parameters.Add("@StudentLevel", SqlDbType.NVarChar, 50).Value = studentLevel;
                    cmd.Parameters.Add("@InstitutionId", SqlDbType.Int).Value = institutionId;

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

        public int Delete(int userId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Delete_User", dbConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;

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

        public int Update(int userId, string password, string firstName, string lastName, string middleName, string briefBio, string email, string userType, string staffId,
            string staffPosition, string studentId, string studentProgram, int studentYear, string studentLevel, int institutionId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_Update_User", dbConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = firstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = lastName;
                    cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 50).Value = middleName;
                    cmd.Parameters.Add("@BriefBio", SqlDbType.NVarChar, 50).Value = briefBio;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
                    cmd.Parameters.Add("@UserType", SqlDbType.NVarChar, 50).Value = userType;
                    cmd.Parameters.Add("@StaffId", SqlDbType.NVarChar, 50).Value = staffId;
                    cmd.Parameters.Add("@StaffPosition", SqlDbType.NVarChar, 50).Value = staffPosition;
                    cmd.Parameters.Add("@StudentId", SqlDbType.NVarChar, 50).Value = studentId;
                    cmd.Parameters.Add("@StudentProgram", SqlDbType.NVarChar, 50).Value = studentProgram;
                    cmd.Parameters.Add("@StudentYear", SqlDbType.Int).Value = studentYear;
                    cmd.Parameters.Add("@StudentLevel", SqlDbType.NVarChar, 50).Value = studentLevel;
                    cmd.Parameters.Add("@InstitutionId", SqlDbType.Int).Value = institutionId;

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

        public DataTable GetOne(int userId)
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("sp_Select_One_User", dbConn))
                {
                    // Open the DB connection if it is not already open
                    if (dbConn.State != ConnectionState.Open)
                    {
                        dbConn.Open();
                    }

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
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

        public DataTable GetAll()
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("sp_Select_All_Users", dbConn))
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

        public int Login(string email, string password)
        {
            try
            {
                int successFlag = 0;
                DataTable data = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("sp_Login_User", dbConn))
                {
                    // Open the DB connection if it is not already open
                    if (dbConn.State != ConnectionState.Open)
                    {
                        dbConn.Open();
                    }

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
                    da.SelectCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password;
                    da.Fill(data);

                    if (data.Rows.Count > 0)
                    {
                        successFlag = 1;
                    }
                }

                // TODO: the return types will be changed to JSON

                return successFlag; // SUCCESS if 1, Failed if 0
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

        public int Logout(string email)
        {
            try
            {
                int successFlag = 0;
                DataTable data = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("sp_Logout_User", dbConn))
                {
                    // Open the DB connection if it is not already open
                    if (dbConn.State != ConnectionState.Open)
                    {
                        dbConn.Open();
                    }

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
                    da.Fill(data);

                    if (data.Rows.Count > 0)
                    {
                        successFlag = 1;
                    }
                }

                // TODO: the return types will be changed to JSON

                return successFlag; // SUCCESS if 1, Failed if 0
            }
            catch (Exception ex)
            {
                // TODO :: We will add a module to log errors, also all the return types will be in JSON
                //Log.Error(ex);
                //jsonNetResult.Data = new { success = false, message = "Failed." };

                return 0; // FAILED (maybe user not found)
            }
            finally
            {
                dbConn.Close();
            }
        }
    }
}