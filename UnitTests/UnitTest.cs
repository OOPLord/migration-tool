using System;
using System.Collections.Generic;
using DataLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void TestDropTableGeneric()
        {
            TableModel tm = new TableModel();

            tm.Name = "RuntimeTable";
            
            sqlConverter.DropTable(tm);
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
    }
}
