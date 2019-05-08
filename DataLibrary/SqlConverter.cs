using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class SqlConverter
    {
        private SqlConnection sqlConnection = null;

        public SqlConverter()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Stiff\Documents\demodb.mdf;Integrated Security=True;Connect Timeout=30";

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public SqlConverter(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void CreateNewDB()
        {
            string str = "CREATE DATABASE MyDatabase ON PRIMARY " +
                "(NAME = MyDatabase_Data, " +
                "FILENAME = 'D:\\MyDatabaseData.mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = MyDatabase_Log, " +
                "FILENAME = D:\\MyDatabaseLog.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, sqlConnection);

            try
            {
                sqlConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public void CreateTable()
        {
            string str = "CREATE TABLE TableName2 (" +
                "[TutorialID] INT NOT NULL," +
                "[TutorialName] NCHAR(10) NOT NULL," +
                "PRIMARY KEY CLUSTERED([TutorialID] ASC)" +
                ");";

            SqlCommand myCommand = new SqlCommand(str, sqlConnection);

            try
            {
                ////sqlConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public void SelectDataFromDB()
        {
            SqlCommand command;
            SqlDataReader reader;

            string sql;
            string output = string.Empty;

            sql = "Select TutorialID, TutorialName from TableName";

            command = new SqlCommand(sql, sqlConnection);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                output += reader.GetValue(0) + " - " + reader.GetValue(1);
            }

            reader.Close();
            command.Dispose();
            sqlConnection.Close();
        }

        public void InsertDataIntoDB()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql;
            string output = string.Empty;

            sql = "Insert into TableName (TutorialID, TutorialName) values (3, '" + "VB.Net" + "')";

            command = new SqlCommand(sql, sqlConnection);

            adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            sqlConnection.Close();
        }
    }
}
