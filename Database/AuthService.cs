using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Pubali_Bank_FundManagement.Models;
using System.Data;

namespace Pubali_Bank_FundManagement.Database
{
    public class AuthService
    {   
        private string _connectionString = "Data Source=localhost:1521/orcl;User Id=system;Password=orcl1234;";

        // ---------------------- User Login --------------------------------//
        public User VerifyUser(User user) 
        {   
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("pkg_user.UserLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create input parameters for userid and password
                    command.Parameters.Add("p_userid", OracleDbType.Varchar2).Value = user.Username;
                    command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = user.Password;

                    // Create output parameter for the cursor
                    OracleParameter cursorParam = new OracleParameter();
                    cursorParam.ParameterName = "p_cursor";
                    cursorParam.OracleDbType = OracleDbType.RefCursor;
                    cursorParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(cursorParam);

                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    // Retrieve the cursor result
                    OracleDataReader reader = ((OracleRefCursor)cursorParam.Value).GetDataReader();
                    while (reader.Read())
                    {
                        int status = reader.GetInt32(reader.GetOrdinal("status"));
                        string message = reader.GetString(reader.GetOrdinal("message"));

                        if ( status == 200 )
                        {
                            user.Password = message;
                        }
                        else
                        {
                            user.Password = "null";
                        }
                        
                    }
                    reader.Close();
                }

                connection.Close();
            }

            return user;
        }

        // ----------------------- User Registration ----------------------- //
        public Auth_Registration_Res InsertUser(User newUser)
        {
            Auth_Registration_Res res = new Auth_Registration_Res();

            res.status = StatusCodes.Status500InternalServerError.ToString();
            res.message = "Connection problem";

            // Create Oracle Connection object
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                //open connection
                connection.Open();

                // create command object
                using(OracleCommand command = connection.CreateCommand())
                {
                    // set command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // set procedure name
                    command.CommandText = "auth_pkg_user.user_insert";

                    // define input parameters
                    command.Parameters.Add("p_user_id", OracleDbType.Varchar2).Value = newUser.Username;
                    command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = newUser.Password;

                    // define output parameters
                    command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;   

                    // execute command
                    command.ExecuteNonQuery();

                    // retrieve result from the output cursor
                    using(OracleDataReader reader = 
                            ((Oracle.ManagedDataAccess.Types.OracleRefCursor)command.Parameters["p_cursor"].Value).GetDataReader())
                    {
                        while(reader.Read())
                        {
                            int status = reader.GetInt32(reader.GetOrdinal("status"));
                            string message = reader.GetString(reader.GetOrdinal("message"));

                            res.status = status.ToString();
                            res.message = message;
                        }
                    }

                    connection.Close();
                }

                return res;
                
            }
        }




        // ----------------------- User Login ----------------------- //
    }
}
