using DataLibrary;
using System.IO;
using System.Diagnostics;

namespace Migrations
{
	public class Test2
	{
		public void UP()
		{
			SqlConverter sqlConverter = new SqlConverter();

			sqlConverter.CreateNewDatabase("D:\\", "teststs");
		}
	}
}