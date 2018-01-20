using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.IO;
namespace kp.extensions
{
    public static class FileExt
    {
        public static void ReplaceinDir(string sourcedir, string oldchar, string newchar)
        {
            string rootfolder = sourcedir;
            string[] files = System.IO.Directory.GetFiles(rootfolder, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                try
                {
                    string contents = System.IO.File.ReadAllText(file);
                    contents = contents.Replace(oldchar, newchar);
                    System.IO.File.SetAttributes(file, FileAttributes.Normal);

                    System.IO.File.WriteAllText(file, contents);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static class Copy
        {
            public static void WithSameName(string sourcefile,string desdir,bool overwrite)
            {
                if (File.Exists(sourcefile))
                {
                    String nameoffile = sourcefile.Substring(sourcefile.LastIndexOf("\\") + 1);
                    if (overwrite == true)
                    {
                        File.Copy(sourcefile, desdir + @"\" + nameoffile, true);
                    }
                    else File.Copy(sourcefile, desdir + @"\" + nameoffile, false);

                } 

            }
            public static void OnlyifExist(string sourcefile, string desfile)
            {
                String nameoffile = sourcefile.Substring(sourcefile.LastIndexOf("\\") + 1);
                if (File.Exists(desfile))
                {
                    File.Copy(sourcefile, desfile, true);
                }
            }
            public static void OnlyifNotExist(string sourcefile, string desfile)
            {
                String nameoffile = sourcefile.Substring(sourcefile.LastIndexOf("\\") + 1);
                if (!File.Exists(desfile))
                {
                    File.Copy(sourcefile, desfile, true);
                }
            }
        }
       
    }
}
