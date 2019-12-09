using DataLibrary;

namespace Migrations
{
	public class OldClass
	{
		private SqlConverter sqlConverter = new SqlConverter(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=D:\Workspace\Diploma Tool\DB\db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		public void Up()
		{

			string sqlScript = "CREATE TABLE OldClass(oldField int,);";

			sqlConverter.ExetuteScript(sqlScript);
		}
		public void Down()
		{

			string sqlScript = "DROP TABLE OldClass;";

			sqlConverter.ExetuteScript(sqlScript);
		}
	}
}