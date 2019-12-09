using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Deployment
    {
        public static string DeterminePaths()
        {
            string folderPathToExecutedAssembly;
            string exeAssemblyName;

            Assembly assembly = Assembly.GetAssembly(typeof(Deployment));

            folderPathToExecutedAssembly = Path.GetDirectoryName(assembly.Location);
            exeAssemblyName = assembly.GetName().Name;

            string subpathMustBe = "migration-tool";
            string[] splitPath = folderPathToExecutedAssembly.Split(
                new[] { subpathMustBe }, StringSplitOptions.None);

            string pathToRootFolder = string.Empty;

            ////for (int i = 0; i < splitPath.Length - 1; i++)
            ////{
            ////    pathToRootFolder += splitPath[i] + subpathMustBe;
            ////}

            pathToRootFolder += splitPath[0] + subpathMustBe;

            return pathToRootFolder;
        }
    }
}