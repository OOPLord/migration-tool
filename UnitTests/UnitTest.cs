using System;
using DataLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCreateTable()
        {
            SqlConverter sqlConverter = new SqlConverter();

            sqlConverter.CreateTable();
        }

        [TestMethod]
        public void TestInsert()
        {
            SqlConverter sqlConverter = new SqlConverter();

            sqlConverter.InsertDataIntoDB();
        }

        [TestMethod]
        public void TestSelect()
        {
            SqlConverter sqlConverter = new SqlConverter();

            sqlConverter.SelectDataFromDB();
        }
    }
}
