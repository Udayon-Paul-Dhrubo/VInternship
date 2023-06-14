using JWTToken.Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace AuthAPI.Services
{
    public class DbServices
    {
        private readonly string _connectionString = "Data Source=localhost:1521/orcl;User Id=system;Password=orcl1234;";

        //-------------------------------- insert -------------------------------- .//
        public AuthRsp Insert(string username, string hash)
        {
            AuthRsp response = new AuthRsp();      

            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create OracleCommand object
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        // Set the command type to stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Set the procedure name
                        command.CommandText = "users_auth_pkg.users_insert";

                        // Define input parameters
                        command.Parameters.Add("p_username", OracleDbType.NVarchar2).Value = username;
                        command.Parameters.Add("p_password", OracleDbType.NVarchar2).Value = hash;
                        ;

                        // Define output parameter for the cursor
                        command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        // Execute the command
                        command.ExecuteNonQuery();

                        // Retrieve the result from the output cursor
                        using (OracleDataReader reader = ((OracleRefCursor)command.Parameters["p_cursor"].Value).GetDataReader())
                        {
                            if (reader.Read())
                            {
                                int status = reader.GetInt32(0);
                                string message = reader.GetString(1);

                                response.Status = status.ToString();
                                response.Message = message;
                                // Process the status and message as needed
                            }
                        }

                    }
                    connection.Close();
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Status = "500";
                response.Message = ex.Message + " -- from Dbservice.Insert";

                Console.WriteLine(ex);

                return response;
            }            
        }


        //-------------------------------- login -------------------------------- .//
        public AuthRsp Login(string username, string hash)
        {
            AuthRsp response = new AuthRsp();

            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    connection.Open();

                    using (OracleCommand command = new OracleCommand("users_auth_pkg.users_login", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Create input parameters for userid and password
                        command.Parameters.Add("p_username", OracleDbType.NVarchar2).Value = username;
                        command.Parameters.Add("p_password", OracleDbType.NVarchar2).Value = hash;

                        // Define output parameter for the cursor
                        command.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        // Execute the stored procedure
                        command.ExecuteNonQuery();

         
                        // Retrieve the result from the output cursor
                        using (OracleDataReader reader = ((OracleRefCursor)command.Parameters["p_cursor"].Value).GetDataReader())
                        {
                            if (reader.Read())
                            {
                                int status = reader.GetInt32(0);
                                string message = reader.GetString(1);

                                response.Status = status.ToString();
                                response.Message = message;
                                // Process the status and message as needed
                            }
                        }
                        
                    }

                    connection.Close();
                }

                return response;

            }
            catch (Exception ex)
            {
                response.Status = "500";
                response.Message = ex.Message + " -- from Dbservice.Login";

                return response;
            }
        }
    }
}
