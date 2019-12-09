using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class MigrationManager
    {
        private SqlConverter converter = null;

        public MigrationManager()
        {
            converter = new SqlConverter();
        }

        public MigrationManager(string connectionString)
        {
            converter = new SqlConverter(connectionString);
        }

        public void AddToDB(TableModel table, string fileName, string folderName)
        {
            try
            {
                MigrationDataManager manager = new MigrationDataManager();

                string code = manager.GenerateCreateTableScript(table, converter);

                FileManager.CreateFile(fileName, code, folderName);

                string result = FileManager.InvokeMethodSlow(fileName, table.Name, "Up", folderName);
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        public void MigrateDB(TableModel table, string fileName, string folderName)
        {
            try
            {
                FileManager.InvokeMethodSlow(fileName, table.Name, "Down", folderName);
            }
            catch
            {
                // ignored
            }
        }
    }
}
