using System;
using System.IO;

namespace SqlBuilder
{
    class Program
    {
        static void Main(string[] args)
        {

            string sourcepath = "..\\..\\..\\SQL\\Source";
            string targetpath = "..\\..\\..\\SQL\\Target";

            foreach (string path in Directory.GetFiles(sourcepath, "*.sql"))
            {
                Console.WriteLine($"Source = {path}");
                string content=   Transform.BuilderFile(path);
                string newPath = Path.Combine(targetpath, Path.GetFileName(path));
                Console.WriteLine($"    Target = {newPath}");
                File.WriteAllText(newPath, content);
            }
        }
    }
}
