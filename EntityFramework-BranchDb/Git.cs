using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityFramework_BranchDb
{
    public class Git : Repo
    {

        public override string GetBranchName()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo info = new DirectoryInfo(directory);

            while (true)
            {
                if (Directory.Exists(info.FullName + @"\.git"))
                {
                    var branch =  File.ReadAllText(info.FullName + @"\.git\HEAD").Trim();
                    return branch.Split(':').Last().Split('/').Last();
                }
                info = info.Parent;
                if (info == null)
                    return null;
            }
        }


    }
}
