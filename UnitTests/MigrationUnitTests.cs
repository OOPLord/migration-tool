using DataLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class MigrationUnitTests
    {
        [TestMethod]
        public void Test_MigrateFromManager_Up()
        {
            string errorMessage = string.Empty;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=teststs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConverter sqlConverter = new SqlConverter(connectionString);

            MigrationDataManager manager = new MigrationDataManager();

            TableModel tm = new TableModel();
            tm.Name = "Test3";
            tm.ColumnCollection = new List<ColumnProperty>()
            {
                new ColumnProperty("PersonID", "int"),
                new ColumnProperty("FirstName", "varchar(255)"),
                new ColumnProperty("LastName", "varchar(255)"),
            };

            string code = manager.GenerateCreateTableScript(tm, sqlConverter);

            FileManager.CreateFile(tm.Name, code, string.Empty);

            FileManager.InvokeMethodSlow(tm.Name, tm.Name, "Up", string.Empty);

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }

        [TestMethod]
        public void Test_MigrateFromManager_Down()
        {
            string errorMessage = string.Empty;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=teststs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConverter sqlConverter = new SqlConverter(connectionString);

            FileManager.InvokeMethodSlow("Test3", "Test3", "Down", string.Empty);

            Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage), errorMessage);
        }
    }
}
