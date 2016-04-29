using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using G = System.Configuration;

namespace AirlineReservationSystem.DAL
{
    public abstract class DAL
    {
        protected SqlConnection connection = null;

        public void OpenConnection(string connectionString)
        {
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection();
                    connection.ConnectionString = connectionString;
                    connection.Open();
                }
                else if (connection != null && connection.State == ConnectionState.Closed)
                {
                    using (connection = new SqlConnection())
                    {
                        connection.ConnectionString = connectionString;
                        connection.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot open connection: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public string GetConnectionStringFromExeConfig(string connectionStringNameInConfig)
        {
            G.ConnectionStringSettings connectionStringSettings =
                G.ConfigurationManager.ConnectionStrings[connectionStringNameInConfig];

            if (connectionStringSettings == null)
            {
                throw new ApplicationException(String.Format
                    ("Error. Connection string not found for name '{0}'.",
                    connectionStringNameInConfig));
            }
            return connectionStringSettings.ConnectionString;
        }
    }
}
