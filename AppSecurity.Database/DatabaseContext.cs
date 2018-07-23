using AppSecurity.Models;
using System;
using System.Data.SqlClient;

namespace AppSecurity.Database
{
    public class DatabaseContext
    {
        private SqlConnection _connection;
        private const string VERIFY_SERIAL = "SELECT CanRun FROM AppSerial WHERE verificationCode = @verificationCode";
        private const string VERIFY_UPDATE = "UPDATE AppSerial SET LastCheck = @LastCheck WHERE verificationCode = @verificationCode";
        private const string ADD_SERIAL = "INSERT INTO AppSerial(VerificationCode, IdApp, CanRun, LastCheck, CreateTime) VALUES (@VerificationCode, @IdApp, @CanRun, @LastCheck, @CreateTime)";
        public DatabaseContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public bool VerifySerial(string serial)
        {
            bool verifed = false;
            using (_connection)
            {
                _connection.Open();
                using (var command = new SqlCommand(VERIFY_SERIAL, _connection))
                {
                    command.Parameters.AddWithValue("@verificationCode", serial);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            verifed = reader.GetBoolean(0);
                        }
                    }
                }
                using (var command = new SqlCommand(VERIFY_UPDATE, _connection))
                {
                    command.Parameters.AddWithValue("@LastCheck", DateTime.Now);
                    command.Parameters.AddWithValue("@verificationCode", serial);
                    command.ExecuteNonQuery();
                }
                _connection.Close();
            }
            return verifed;
        }

        public bool AddSerial(AppSerial appSerial)
        {
            bool added = false;
            using (_connection)
            {
                _connection.Open();
                using (var command = new SqlCommand(ADD_SERIAL, _connection))
                {
                    command.Parameters.AddWithValue("@CanRun", appSerial.CanRun);
                    command.Parameters.AddWithValue("@IdApp", appSerial.IdApp);
                    command.Parameters.AddWithValue("@LastCheck", appSerial.LastCheck);
                    command.Parameters.AddWithValue("@VerificationCode", appSerial.VerificationCode);
                    command.Parameters.AddWithValue("@CreateTime", appSerial.CreateTime);
                    added = command.ExecuteNonQuery() == 1;
                }
                _connection.Close();
            }
            return added;
        }
    }
}
