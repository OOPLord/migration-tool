using DataLibrary;

namespace Migrations
{
	public class Class
	{
		private SqlConverter sqlConverter = new SqlConverter(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=demodb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		public void Up()
		{

			string sqlScript = "CREATE TABLE Class();";

			sqlConverter.ExetuteScript(sqlScript);
		}
		public void Down()
		{

			string sqlScript = "DROP TABLE Class;";

			sqlConverter.ExetuteScript(sqlScript);
		}
	}
}