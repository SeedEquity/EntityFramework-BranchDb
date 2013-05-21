EntityFramework-BranchDb
========================

Easily create new EF databases per branch from Mercurial or Git

## Problem

You use Entity Framework and would like to use Git / Mercurial Branching.   But, when you do, your Entity Framework Database gets out of sync, because you may have changed a model in your branch.  So, you can't switch easily between branches.

## Solution

Automatically create a database for each branch you are in.  This database will stay in sync with whatever branch you are in, and will allow you to easily switch without having to muck around with either EF or SQL.


## How to Use

### Step 1 : Install the Nuget Package
` Install-Package EntityFramework-BranchDb`

### Step 2 : Modify your DbContext for your dev environment

NOTE: This code snippet only works if you are using Debug builds.  You'll have to modify it as appropriate if this is not how you develop code.

    #if DEBUG
            var dbName = "MyDb";
            
            // branch switcher for dev environments
            publicMyDbContext() :
                base(Repo.Git.GetConnectionString(DbName))
            {
    
            }
    #endif

### Step 3: Test it out

Run your project.  If you are in branch "master" and your database is called "myDb", then you will be using a db called "myDb-master"

Now, when you create databases in your dev environemnt, they will be called by dbname-branchname.  You can verify that by looking at your database list in Sql Server Enterprise Manager.

Then, switch branches:

    git checkout -b MyBranch
    

Then, compile and run your app again

You should see a database called `myDb-MyBranch`.




