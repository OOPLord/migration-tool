using DataLibrary;

namespace Migrations
{
	public class Test3
	{
		private SqlConverter sqlConverter = new SqlConverter(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=teststs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		public void Up()
		{

			string sqlScript = "CREATE TABLE Test3(PersonID int,FirstName varchar(255),LastName varchar(255),);";

			sqlConverter.ExetuteScript(sqlScript);
		}
		public void Down()
		{

			string sqlScript = "DROP TABLE Test3;";

			sqlConverter.ExetuteScript(sqlScript);
		}
	}
}