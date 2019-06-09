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

        public void AddToDB(TableModel table)
        {
            try
            {
                MigrationDataManager manager = new MigrationDataManager();

                string code = manager.GenerateCreateTableScript(table, converter);

                FileManager.CreateFile(table.Name, code);

                FileManager.InvokeMethodSlow(table.Name, "Up");
            }
            catch
            {
                // ignored
            }
        }

        public void MigrateDB(TableModel table)
        {
            try
            {
                FileManager.InvokeMethodSlow(table.Name, "Down");
            }
            catch
            {
                // ignored
            }
        }
    }
}
