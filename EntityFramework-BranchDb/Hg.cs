using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_BranchDb
{
    public class Hg : Repo
    {
        public override string GetBranchName()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo info = new DirectoryInfo(directory);

            while (true)
            {
                if (Directory.Exists(info.FullName + @"\.hg"))
                {
                    return File.ReadAllText(info.FullName + @"\.hg\branch").Trim();
                }
                info = info.Parent;
                if (info == null)
                    return null;
            }

        }


    }
}
