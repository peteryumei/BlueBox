using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace BlueBox.Common
{
    public class DBX
    {
        private static string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static int CommandTimeout = 60;

        public static DataTable ExecQuery(string query)
        {
            return ExecQuery(query, ConnectionString);
        }

        public static DataTable ExecQuery(string query, BlueBox.Common.DBXParameters parameters, CommandType? commandType)
        {
            return ExecQuery(query, ConnectionString, parameters, commandType);
        }

        public static DataTable ExecQuery(string query, string connectionString)
        {
            return ExecQuery(query, connectionString, null, null);
        }

        public static DataTable ExecQuery(string query, string connectionString, DBXParameters parameters, CommandType? commandType)
        {
            DataTable functionReturnValue = null;

            DataTable objDataTable = new DataTable();
            System.Data.SqlClient.SqlConnection sqlConnection = null;
            System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
            sqlCommand.CommandTimeout = CommandTimeout;
            System.Data.SqlClient.SqlDataReader sqlDataReader = null;
       
            try
            {
                sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = query;
                if (parameters != null && parameters.Any())
                {
                    foreach (var param in parameters)
                    {
                        sqlCommand.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }
                if (commandType.HasValue) sqlCommand.CommandType = commandType.Value;
                sqlDataReader = sqlCommand.ExecuteReader();
                objDataTable.Load(sqlDataReader);

            }
            catch (Exception ex)
            {
                KillDBObjects(sqlConnection, sqlCommand, sqlDataReader);
                throw new Exception(query, ex);
            }
           

            KillDBObjects(sqlConnection, sqlCommand, sqlDataReader);

            functionReturnValue = objDataTable;

            objDataTable.Dispose();
            return functionReturnValue;
        }

        public static int ExecNonQuery(string query)
        {
            return ExecNonQuery(query, ConnectionString);
        }

        public static int ExecNonQuery(string query, DBXParameters parameters, CommandType? commandType)
        {
            return ExecNonQuery(query, ConnectionString, parameters, commandType);
        }

        public static int ExecNonQuery(string query, string connectionString)
        {
            return ExecNonQuery(query, connectionString, null, null);
        }

        public static int ExecNonQuery(string query, string connectionString, DBXParameters parameters, CommandType? commandType)
        {
            System.Data.SqlClient.SqlConnection sqlConnection = null;
            System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
            sqlCommand.CommandTimeout = CommandTimeout;
            int affectedRows = 0;

            try
                {
                    sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
                    sqlCommand.Connection = sqlConnection;

                    sqlConnection.Open();

                    sqlCommand.CommandText = query;
                    if (parameters != null && parameters.Any())
                    {
                        foreach (var param in parameters)
                        {
                            sqlCommand.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    if (commandType.HasValue) sqlCommand.CommandType = commandType.Value;
                    affectedRows = sqlCommand.ExecuteNonQuery();


                }
                catch (Exception ex)
                {

                    KillDBObjects(sqlConnection, sqlCommand, null);
                    throw new Exception(query, ex);
                    
                }
           

            KillDBObjects(sqlConnection, sqlCommand, null);

            return affectedRows;
        }

        public static object ExecScalarQuery(string query)
        {
            return ExecScalarQuery(query, ConnectionString, null, null);
        }

        public static object ExecScalarQuery(string query, DBXParameters parameters, CommandType? commandType)
        {
            return ExecScalarQuery(query, ConnectionString, parameters, commandType);
        }

        public static object ExecScalarQuery(string query, string connectionString, DBXParameters parameters, CommandType? commandType)
        {

            object objReturn = null;
            System.Data.SqlClient.SqlConnection sqlConnection = null;
            System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
            sqlCommand.CommandTimeout = CommandTimeout;
          
            try
            {
                sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
                sqlCommand.Connection = sqlConnection;

                sqlConnection.Open();

                sqlCommand.CommandText = query;
                if (parameters != null && parameters.Any())
                {
                    foreach (var param in parameters)
                    {
                        sqlCommand.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }
                if (commandType.HasValue) sqlCommand.CommandType = commandType.Value;

                objReturn = sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                KillDBObjects(sqlConnection, sqlCommand, null);
                throw new Exception(query, ex); 
            }
            
            KillDBObjects(sqlConnection, sqlCommand, null);

            return objReturn;

        }

        private static void KillDBObjects(System.Data.SqlClient.SqlConnection sqlConnection, System.Data.SqlClient.SqlCommand sqlCommand, System.Data.SqlClient.SqlDataReader sqlDataReader)
        {
            //close out the reader
            sqlDataReader?.Close();

            //dispose command
            sqlCommand?.Dispose();

            //dispose connection
            if (sqlConnection != null)
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Dispose();
            }
        }
    }
}
