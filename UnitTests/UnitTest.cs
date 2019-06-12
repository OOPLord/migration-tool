using DataLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        private SqlConverter sqlConverter;

        [TestInitialize]
        public void TestInitialize()
        {
            sqlConverter = new SqlConverter();
        }

        [TestMethod]
        public void TestDeployment()
        {
            string errorMessage = string.Empty;

            Deployment.DeterminePaths();

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }

        [TestMethod]
        public void TestCreateFile()
        {
            string errorMessage = string.Empty;

            const string code = "using DataLibrary;" +
                            "\nusing System.IO;" +
                            "\nusing System.Diagnostics;" +

                            "\n\nnamespace Migrations" +
                            "\n{" +
                                "\n\tpublic class Test2" +
                                "\n\t{" +
                                    "\n\t\tpublic void UP()" +
                                    "\n\t\t{" +
                                        "\n\t\t\tSqlConverter sqlConverter = new SqlConverter();" +

                                        "\n\n\t\t\tsqlConverter.CreateNewDatabase(\"D:\\\\\", \"teststs\");" +

                                    "\n\t\t}" +
                                "\n\t}" +
                            "\n}";

            FileManager.CreateFile(@"D:\Workspace\Diploma\migration-tool\Migrations\Test2.cs", code, string.Empty);

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }

        [TestMethod]
        public void TestLoadFile()
        {
            string errorMessage = string.Empty;

            FileManager.InvokeMethodSlow("Test2", "Test2", "UP", string.Empty);

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }

        [TestMethod]
        public void TestCreateDataBase()
        {
            string errorMessage = string.Empty;

            errorMessage = sqlConverter.CreateNewDatabase("D:\\", "test");

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }

        [TestMethod]
        public void TestDropDataBase()
        {
            string errorMessage = string.Empty;

            errorMessage = sqlConverter.DropDatabase("test");

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }

        [TestMethod]
        public void TestCreateTableGeneric()
        {
            string errorMessage = string.Empty;

            TableModel tm = new TableModel();
            tm.Name = "NewTable";
            tm.ColumnCollection = new List<ColumnProperty>()
            {
                new ColumnProperty("PersonID", "int"),
                new ColumnProperty("FirstName", "varchar(255)"),
                new ColumnProperty("LastName", "varchar(255)"),
            };

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;"
                                    + "Initial Catalog={0};"
                                    + "Integrated Security=True;"
                                    + "Connect Timeout=30;"
                                    + "Encrypt=False;"
                                    + "TrustServerCertificate=False;"
                                    + "ApplicationIntent=ReadWrite;"
                                    + "MultiSubnetFailover=False";

            string connection = string.Format(connectionString, @"D:\test.mdf");

            SqlConnection sql = new SqlConnection(connection);

            string sqlScript = sqlConverter.CreateNewTable(tm);
            errorMessage = sqlConverter.ExetuteScript(sqlScript);

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }

        [TestMethod]
        public void TestAlterTableAdd()
        {
            string errorMessage = string.Empty;

            TableModel tm = new TableModel();
            tm.Name = "RuntimeTable";

            ColumnProperty newColumn = new ColumnProperty("Patronomic", "varchar(255)");

            errorMessage = sqlConverter.AlterTableAdd(tm, newColumn);

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }

        [TestMethod]
        public void TestAlterTableAlter()
        {
            string errorMessage = string.Empty;

            TableModel tm = new TableModel();
            tm.Name = "RuntimeTable";

            ColumnProperty newColumn = new ColumnProperty("Patronomic", "int");

            errorMessage = sqlConverter.AlterTableAlter(tm, newColumn);

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }

        [TestMethod]
        public void TestAlterTableDrop()
        {
            string errorMessage = string.Empty;

            TableModel tm = new TableModel();
            tm.Name = "RuntimeTable";

            ColumnProperty newColumn = new ColumnProperty("Patronomic", "int");

            errorMessage = sqlConverter.AlterTableDrop(tm, newColumn);

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }

        [TestMethod]
        public void TestSelect()
        {
            TableModel tm = new TableModel();

            tm.Name = "RuntimeTable";
            tm.ColumnCollection = new List<ColumnProperty>()
            {
                new ColumnProperty("PersonID", "int"),
                new ColumnProperty("FirstName", "varchar(255)"),
                new ColumnProperty("LastName", "varchar(255)"),
            };

            sqlConverter.SelectDataFromDB(tm);
        }

        [TestMethod]
        public void TestDropTableGeneric()
        {
            string errorMessage = string.Empty;

            TableModel tm = new TableModel();
            tm.Name = "RuntimeTable";

            errorMessage = sqlConverter.DropTable(tm);

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }
    }
}
