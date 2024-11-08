using Npgsql;
using System.Data;
using AWS;
using System.Drawing;

namespace PostGreSQL
{
    public static class Database
    {
        private const string DoubleQuote = "\"";
        private const string _HostName = "127.0.0.1";
        private const string PortNumber = "5439";

        //        private const string DatabaseName = "DentitekOnlineProd";
        //        private const string Username = "postgres";
        //        private const string Password = "w6K1FTfnXGYBsVzKB5YE";
        private static string? _ConnectionString = null;
        private static DatabasePostGreSqlCredential? _Credential = null;

        static Database()
        {
            _Credential = GetCredential();

            if (_Credential != null)
            {
                SetConnectionString(_Credential);
            }
        }

        //static Database(DatabasePostGreSqlCredential? DbCredential)
        //{
        //    _Credential = DbCredential;

        //    if (_Credential != null)
        //    {
        //        SetConnectionString(_Credential);
        //    }
        //}

        public static void SetCredential (DatabasePostGreSqlCredential? DbCredential = null)
        {
            if (DbCredential == null)
            {
                DbCredential = GetCredential();
            }


            if (_Credential != null)
            {
                _Credential = DbCredential;
                SetConnectionString(_Credential);
            }
        }

        private static DatabasePostGreSqlCredential GetCredential()
        {
            return AWS.S3.GetDentitekOnlineProdCredential();
        }

        private static void SetConnectionString(DatabasePostGreSqlCredential Credential)
        {
            if (Credential != null)
            {
                _ConnectionString = $"Host={_HostName};Port={PortNumber};Database={Credential.DbName};User Id={Credential.UserName};Password={Credential.Password};Timeout=15";
            }
        }

        // retrieve

        public static DataTable? GetData(string Sql, out string ErrorMessage)
        {
            ErrorMessage = "";
            DataTable dt = new DataTable();

            if (!TestDatabaseConnection(out ErrorMessage))
            {
                return null;
            }

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Sql, _ConnectionString);

            try
            {
                da.Fill(dt);
                
            }
            catch (Exception ex)
            {
                ErrorMessage = "Erreur: " + ex.Message;
            }

            return dt;
        }

        /// <summary>
        /// Exceute a SQL Non-Query (Insert, Update, Delete)
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public static int ExecuteUpdate (string Sql, out string ErrorMessage)
        {
            int RowChangedCount = -1;

            ErrorMessage = string.Empty;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_ConnectionString))
                {
                    NpgsqlCommand command = new NpgsqlCommand(Sql, connection);
                    command.Connection.Open();
                    RowChangedCount = command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Erreur de Maj: {ex.Message}";
            }

            return RowChangedCount;
        }

        public static bool TestDatabaseConnection(out string ErrorMessage)
        {
            bool ConnectionSuccessfull = false;

            ErrorMessage = "";

            if (string.IsNullOrEmpty(_ConnectionString))
            {
                _Credential = GetCredential();

                if (_Credential != null)
                {
                    SetConnectionString(_Credential);
                }
            }

            if (string.IsNullOrEmpty(_ConnectionString))
            {
                ErrorMessage = "La Connection string est vide, impossible de se brancher a la BD, problème de branchement a AWS pour obtenir les paramètres de BD";
            }

            NpgsqlConnection Connection = new NpgsqlConnection(_ConnectionString);

            try
            {
                Connection.Open();
                var ConnState = Connection.State;
                ConnectionSuccessfull = (ConnState != ConnectionState.Closed);
                Connection.Close();
            }
            catch (Exception ex)
            {
                ErrorMessage = "Erreur branchement BD (probablement le Bation qui a expiré ou n'a pas été démarré)" + ex.Message;
            }

            return ConnectionSuccessfull;
        }

    }
}
