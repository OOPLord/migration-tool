using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            string connectionString = @"Data Source=DESKTOP-NKCCE48;Initial Catalog=Demodb;User ID=sa;Password=demol23";

            sqlConnection = new SqlConnection(connectionString);
        }

        public SqlConverter(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void ReadDateToDB()
        {
            SqlCommand command;
            SqlDataReader reader;

            string sql;
            string output = string.Empty;

            sql = "Select TutorialID, TutorialName from demodb";

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

        public void WriteDateToDB()
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql;
            string output = string.Empty;

            sql = "Insert into demodb (TutorialID, TutorialName) values (3, '" + "VB.Net" + "')";

            command = new SqlCommand(sql, sqlConnection);

            adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            sqlConnection.Close();
        }
    }
}
