using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.FileProviders;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileProvider fff=new PhysicalFileProvider(Directory.GetCurrentDirectory());
            string p = fff.GetFileInfo("/Resources/DbDataSeed/InitialDBContentNew.json").PhysicalPath;
            Console.WriteLine(p);
            
        }
    }
}
