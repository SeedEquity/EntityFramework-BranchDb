using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_BranchDb
{
    public abstract class Repo
    {
        public const string SqlServerConnectionString = "Server=.;Database={0}-{1};Integrated Security=True;";
        public string GetBranchDb(string db, string connectionString)
        {
            var branch = GetBranchName();
            return string.Format(connectionString, db, branch);
        }

        public abstract string GetBranchName();

        public string GetConnectionString(string db, string connectionString)
        {
            return GetBranchDb(db, connectionString);
        }

        public string GetConnectionString(string db)
        {
            return GetConnectionString(db, SqlServerConnectionString);
        }

        public static readonly Git Git = new Git();
        public static readonly Hg Hg  = new Hg();
    }
}
