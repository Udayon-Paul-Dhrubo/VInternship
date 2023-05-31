namespace WebApplication2.Services
{
    using Oracle.ManagedDataAccess.Client;
    using Oracle.ManagedDataAccess.Types;
    using System.Data;


    public class DatabaseServices
    {

        public void getConnectionAndData(LoginDto loginDto)
        {
            //string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=your_service_name)));User Id=<your_username>;Password=<your_password>;";

            //   string connectionString = "Data Source=<your_data_source>;User Id=system;Password=system;";


            string connectionString = "Data Source=localhost:1521/orcl;User Id=system;Password=orcl1234;";

            //   string connectionString = "Data Source=<your_data_source>;User Id=<your_username>;Password=<your_password>;";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("InsertDummyData", connection))
                {

                    //ParameterArray parameters = new ParameterArray();

                    command.CommandType = CommandType.StoredProcedure;

                    // Create output parameter for the cursor
                    OracleParameter cursorParam = new OracleParameter();
                    cursorParam.ParameterName = "p_cursor";
                    cursorParam.OracleDbType = OracleDbType.RefCursor;
                    cursorParam.Direction = ParameterDirection.Output;

                   // parameters.Add(cursorParam);

                   // command.Parameters.AddRange(parameters.GetParameters());
                   

                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    // Retrieve the cursor result
                    OracleDataReader reader = ((OracleRefCursor)cursorParam.Value).GetDataReader();
                    while (reader.Read())
                    {
                        string status = reader.GetString(0);
                        int successCount = reader.GetInt32(1);
                        Console.WriteLine("Status: " + status);
                        Console.WriteLine("Success Count: " + successCount);
                    }
                    reader.Close();
                }

                connection.Close();
            }



        }

        public RegistrationResponseDto InsertUser(RegisterDto reqdata)
        {
            RegistrationResponseDto logres = new RegistrationResponseDto();
            string connectionString = "Data Source=localhost:1521/orcl;User Id=system;Password=orcl1234;";
            // Create OracleConnection object
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create OracleCommand object
                using (OracleCommand command = connection.CreateCommand())
                {
                    // Set the command type to stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Set the procedure name
                    command.CommandText = "pkg_user.user_insert";

                    // Define input parameters
                    command.Parameters.Add("p_username", OracleDbType.Varchar2).Value = reqdata.Username;
                    command.Parameters.Add("p_user_password", OracleDbType.Varchar2).Value = reqdata.Password;
                    command.Parameters.Add("p_first_name", OracleDbType.Varchar2).Value = reqdata.FirstName;
                    command.Parameters.Add("p_last_name", OracleDbType.Varchar2).Value = reqdata.LastName;
                    command.Parameters.Add("p_email", OracleDbType.Varchar2).Value = reqdata.Email;

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
                            logres.status = status.ToString();
                            logres.message = message;
                            // Process the status and message as needed
                        }
                    }
                   
                }
                connection.Close();
            }

            return logres;
        }

            public LoginResponseDto verifyAndLogin(LoginDto loginDto)
        {
            LoginResponseDto logres = new LoginResponseDto();
            logres.status = "600";
            logres.message = "Error login";
            string connectionString = "Data Source=localhost:1521/orcl;User Id=system;Password=orcl1234;";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                using (OracleCommand command = new OracleCommand("pkg_user.UserLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Create input parameters for userid and password
                    command.Parameters.Add("p_userid", OracleDbType.Varchar2).Value = loginDto.username;
                    command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = loginDto.Password;

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
                        int status = reader.GetInt32(0);
                        string message = reader.GetString(1);
                        // Console.WriteLine("Status: " + status);
                        // Console.WriteLine("Message: " + message);
                 
                         logres.status = status.ToString();
                        logres.message = message;
                    }
                    reader.Close();
                }

                connection.Close();
            }

            return logres;

        }
    }
}
