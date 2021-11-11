using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFDemo
{
    //nuget package: EntityFramework
    class StudentManagementContext:DbContext
    {
        public StudentManagementContext(): base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<StudentManagementContext>());
        }

        //to name your DB in your selected way(not auto generated)
        //public StudentManagementContext() : base("SchoolManagementSystem")
        //auto name = ProjectName.ContextName
        //public StudentManagementContext() : base("Name:ConectionStringName")
        //the Db name will be in the connection string => Initial Catalog.
        //Ensure the Connsring name matches the name given in base

        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}

// To specify connection sring
//App.config => After closing of <entityframework/>

    //< connectionStrings >
    //    < add name = "SchoolManagementSystemDbConnectionString" connectionString = "Data Source=(localdb)\****;
    //    Initial Catolg = StudentManagement123; Integrated Security: true"
    //    providerName = "System.Data.SqlClient" />
    //</ connectionStrings >
