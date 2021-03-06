using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SystemIOPackage
{
    public class PathExamples
    {
        public static void Example()
        {
            string folder = @"C:\temp";
            string fileName = "test.dat";
            string fullPath = Path.Combine(folder, fileName); // Results in C:\\temp\\test.dat
        }

        public static void ExamplePathMethods()
        {
            string path =@"C:\temp\subdir\file.txt";

            Console.WriteLine(Path.GetDirectoryName(path)); // Displays C:\temp\subdir 
            Console.WriteLine(Path.GetExtension(path)); // Displays .txt 
            Console.WriteLine(Path.GetFileName(path)); // Displays file.txt 
            Console.WriteLine(Path.GetPathRoot(path)); // Displays C:\


        }


    }
}
