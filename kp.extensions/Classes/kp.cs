using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;

namespace kp.extensions
{
    public static class kp
    {
        public static bool isAdminPrivilege()
        {
            bool isElevated = false;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            return isElevated;
        }
        public static bool isFile(string Path)
        {
            FileAttributes attr = File.GetAttributes(Path);
            if (attr.HasFlag(FileAttributes.Directory))
                return false;
            else
                return true;
        }
        public static bool isDirectory(string Path)
        {
            FileAttributes attr = File.GetAttributes(Path);
            if (attr.HasFlag(FileAttributes.Directory))
                return true;
            else
                return false;
        }
    }
}
