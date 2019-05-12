using DataLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        public void TestCreateTableGeneric()
        {
            string errorMessage = string.Empty;

            TableModel tm = new TableModel();
            tm.Name = "RuntimeTable";
            tm.ColumnCollection = new List<ColumnProperty>()
            {
                new ColumnProperty("PersonID", "int"),
                new ColumnProperty("FirstName", "varchar(255)"),
                new ColumnProperty("LastName", "varchar(255)"),
            };

            errorMessage = sqlConverter.CreateNewTable(tm);

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
        public void TestInsert()
        {
            ////sqlConverter.InsertDataIntoDB();
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
