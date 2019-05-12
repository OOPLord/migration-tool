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

        public string CreateNewTable(TableModel model)
        {
            // CREATE TABLE table_name(
            // column1 datatype,
            // column2 datatype,
            // column3 datatype,
            // ....
            // );

            // CREATE TABLE TableName2 (
            // [TutorialID] INT NOT NULL,
            // [TutorialName] NCHAR(10) NOT NULL,
            // PRIMARY KEY CLUSTERED([TutorialID] ASC)
            // );

            StringBuilder sb = new StringBuilder();

            sb.Append("CREATE TABLE " + model.Name + "");

            // ToDo: check if collection is not empty
            sb.Append("(\n");

            foreach (var column in model.ColumnCollection)
            {
                sb.Append(column.Name + " " + column.Type + ",\n");
            }

            sb.Append(");");

            SqlCommand command = new SqlCommand(sb.ToString(), sqlConnection);

            return this.ExetuteScript(command);
        }

        public string DropTable(TableModel model)
        {
            // DROP TABLE table_name;

            StringBuilder sb = new StringBuilder();

            sb.Append("DROP TABLE " + model.Name + ";");

            SqlCommand command = new SqlCommand(sb.ToString(), sqlConnection);

            return this.ExetuteScript(command);
        }

        public string AlterTableAdd(TableModel model, ColumnProperty newColumn)
        {
            // ALTER TABLE table_name
            // ADD column_name datatype;

            // string execSQL = "DECLARE @sup nvarchar(15); " + 
            // "SET @sup = QUOTENAME('" + suppliernotxt + "'); " +
            // "EXEC ('ALTER TABLE ProductNormalDB  ADD ' + @sup + ' nvarchar(20) NULL')"

            StringBuilder sb = new StringBuilder();

            sb.Append("ALTER TABLE " + model.Name +
                "\nADD "+ newColumn.Name + " " + newColumn.Type + ";");

            SqlCommand command = new SqlCommand(sb.ToString(), sqlConnection);

            return this.ExetuteScript(command);
        }

        public string AlterTableDrop(TableModel model, ColumnProperty dropColumn)
        {
            // ALTER TABLE table_name
            // DROP COLUMN column_name;

            StringBuilder sb = new StringBuilder();

            sb.Append("ALTER TABLE " + model.Name +
                "\nDROP COLUMN " + dropColumn.Name + ";");

            SqlCommand command = new SqlCommand(sb.ToString(), sqlConnection);

            return this.ExetuteScript(command);
        }

        public string AlterTableAlter(TableModel model, ColumnProperty alterColumn)
        {
            // ALTER TABLE table_name
            // ALTER COLUMN column_name datatype;

            StringBuilder sb = new StringBuilder();

            sb.Append("ALTER TABLE " + model.Name +
                "\nALTER COLUMN " + alterColumn.Name + " " + alterColumn.Type + ";");

            SqlCommand command = new SqlCommand(sb.ToString(), sqlConnection);

            return this.ExetuteScript(command);
        }

        public void SelectDataFromDB(TableModel model)
        {
            SqlCommand command;
            SqlDataReader reader;

            string output = string.Empty;

            StringBuilder sb = new StringBuilder();

            sb.Append("Select ");

            // ToDo: check if collection is not empty
            
            foreach (var column in model.ColumnCollection)
            {
                sb.Append(column.Name + " " + column.Type + ",");
            }

            sb.Append("from " + model.Name + ";");

            try
            {
                command = new SqlCommand(sb.ToString(), sqlConnection);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    output += reader.GetValue(0) + " - " + reader.GetValue(1);
                }

                reader.Close();
                command.Dispose();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
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

        private string ExetuteScript(SqlCommand command)
        {
            string errorMessage = string.Empty;

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                //sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message);

                return ex.Message;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return string.Empty;
        }
    }
}
