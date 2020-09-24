using System;
using System.IO;
using System.Reflection;
using CompanyProject.Repository.InitialDataBase;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("Resources", StringComparison.Ordinal)));
            
        }
    }
}
