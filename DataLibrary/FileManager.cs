﻿using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public static class FileManager
    {

        public static void CreateFile(string fileName, string code, string folderName)
        {
            string rootFolder = Deployment.DeterminePaths();

            string migrationsDirectory = rootFolder + Path.DirectorySeparatorChar + "Migrations";

            if (!Directory.Exists(migrationsDirectory))
            {
                Directory.CreateDirectory(migrationsDirectory);
            }

            if (!string.IsNullOrWhiteSpace(folderName))
            {
                migrationsDirectory = Path.Combine(migrationsDirectory, folderName);
            }

            if (!Directory.Exists(migrationsDirectory))
            {
                Directory.CreateDirectory(migrationsDirectory);
            }

            string migrationFile = Path.Combine(migrationsDirectory, fileName + ".cs");

            FileInfo file = new FileInfo(migrationFile);

            if (file.Exists)
            {
                Trace.WriteLine("File already exists.");
            }
            else
            {
                file.Create().Dispose();
            }

            using (var fw = file.CreateText())
            {
                fw.Write(code);
            }

            ////var p = new Evaluation.Project(@"C:\projects\MyProject.csproj");
            ////p.AddItem("Compile", @"C:\folder\file.cs");
            ////p.Save();
        }

        public static string InvokeMethodSlow(
            string fileName,
            string ClassName,
            string MethodName,
            string folderName)
        {
            string rootFolder = Deployment.DeterminePaths();

            string dataLibDll = string.Empty;
            string migrDll = string.Empty;
            string migrationFile = string.Empty;

            if (string.IsNullOrWhiteSpace(folderName))
            {
                dataLibDll = Path.Combine(rootFolder, @"DataLibrary\bin\Debug\DataLibrary.dll");
                migrDll = Path.Combine(rootFolder, @"Migrations\Migration.dll");
                migrationFile = Path.Combine(rootFolder, "Migrations", fileName + ".cs");
            }
            else
            {
                dataLibDll = Path.Combine(rootFolder, @"DataLibrary\bin\Debug\DataLibrary.dll");
                migrDll = Path.Combine(rootFolder, @"Migrations\Migration.dll");
                migrationFile = Path.Combine(rootFolder, "Migrations", folderName, fileName + ".cs");
            }

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();

            CompilerParameters parameters = new CompilerParameters(
                new string[] { dataLibDll });

            parameters.ReferencedAssemblies.Add("System.IO.dll");

            parameters.GenerateExecutable = false;
            parameters.OutputAssembly = migrDll;

            CompilerResults results = icc.CompileAssemblyFromFile(parameters, migrationFile);

            if (results.Errors.Count > 0)
            {
                return results.Errors[0].ErrorText;
            }

            Object[] args = null;
            // load the assemly
            Assembly assembly = Assembly.LoadFrom(migrDll);

            // Walk through each type in the assembly looking for our class
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass == true)
                {
                    if (type.FullName.EndsWith("." + ClassName))
                    {
                        // create an instance of the object
                        object ClassObj = Activator.CreateInstance(type);

                        // Dynamically Invoke the method
                        object Result = type.InvokeMember(MethodName,
                          BindingFlags.Default | BindingFlags.InvokeMethod,
                               null,
                               ClassObj,
                               args);

                        ////return (Result);
                        return string.Empty;
                    }
                }
            }

            throw (new System.Exception("could not invoke method"));
        }
    }
}
