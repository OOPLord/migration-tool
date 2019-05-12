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
            TableModel tm = new TableModel();

            tm.Name = "RuntimeTable";
            tm.ColumnCollection = new List<ColumnProperty>()
            {
                new ColumnProperty("PersonID", "int"),
                new ColumnProperty("FirstName", "varchar(255)"),
                new ColumnProperty("LastName", "varchar(255)"),
            };

            sqlConverter.CreateNewTable(tm);
        }

        [TestMethod]
        public void TestAlterTableAdd()
        {
            TableModel tm = new TableModel();

            tm.Name = "RuntimeTable";

            ColumnProperty newColumn = new ColumnProperty("Patronomic", "varchar(255)");

            sqlConverter.AlterTableAdd(tm, newColumn);
        }

        [TestMethod]
        public void TestAlterTableAlter()
        {
            TableModel tm = new TableModel();

            tm.Name = "RuntimeTable";

            ColumnProperty newColumn = new ColumnProperty("Patronomic", "int");

            sqlConverter.AlterTableAlter(tm, newColumn);
        }

        [TestMethod]
        public void TestAlterTableDrop()
        {
            TableModel tm = new TableModel();

            tm.Name = "RuntimeTable";

            ColumnProperty newColumn = new ColumnProperty("Patronomic", "int");

            sqlConverter.AlterTableDrop(tm, newColumn);
        }

        [TestMethod]
        public void TestInsert()
        {
            sqlConverter.InsertDataIntoDB();
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
            TableModel tm = new TableModel();

            tm.Name = "RuntimeTable";

            sqlConverter.DropTable(tm);
        }
    }
}
