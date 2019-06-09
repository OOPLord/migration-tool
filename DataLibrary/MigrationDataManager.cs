using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class MigrationDataManager
    {
        const string migrationTemplate = "using DataLibrary;" +
                            ////"\nusing System.Diagnostics;" +

                            "\n\nnamespace Migrations" +
                            "\n{" +
                                "\n\tpublic class Test2" +
                                "\n\t{" +

                                    "\n\t\tprivate SqlConverter sqlConverter = new SqlConverter();" +

                                    "\n\t\tpublic void UP()" +
                                    "\n\t\t{" +

                                        "\n\n\t\t\t{upScript}" +

                                    "\n\t\t}" +

                                    "\n\t\tpublic void Down()" +
                                    "\n\t\t{" +

                                        "\n\n\t\t\t{dowmScript}" +

                                    "\n\t\t}" +
                                "\n\t}" +
                            "\n}";


        const string beforeName = "using DataLibrary;" +
                            ////"\nusing System.Diagnostics;" +

                            "\n\nnamespace Migrations" +
                            "\n{" +
                                "\n\tpublic class ";

        const string afterName = "\n\t{" +

                                    "\n\t\tprivate SqlConverter sqlConverter = new SqlConverter(@\"";

        const string afterConnection = "\");" +

                                    "\n\t\tpublic void Up()" +
                                    "\n\t\t{";

        const string middlePart = "\n\n\t\t\tsqlConverter.ExetuteScript(sqlScript);" +
                                    "\n\t\t}" +

                                    "\n\t\tpublic void Down()" +
                                    "\n\t\t{";

        const string downPart = "\n\n\t\t\tsqlConverter.ExetuteScript(sqlScript);" +
                                "\n\t\t}" +
                                "\n\t}" +
                            "\n}";

        public string GenerateCreateTableScript(TableModel tm, SqlConverter converter)
        {
            string upScript = string.Empty;
            string dowmScript = string.Empty;

            string sqlScript = converter.CreateNewTable(tm);

            upScript = $"string sqlScript = \"{sqlScript}\";";

            sqlScript = converter.DropTable(tm);

            dowmScript = $"string sqlScript = \"{sqlScript}\";";

            string migrationString = beforeName + tm.Name + afterName + converter.ConnectionString + afterConnection + $"\n\n\t\t\t{upScript}" + middlePart + $"\n\n\t\t\t{dowmScript}" + downPart;

            return migrationString;
        }

    }
}
