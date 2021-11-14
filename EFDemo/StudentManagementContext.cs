using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFDemo
{
    //nuget package: EntityFramework
    public class StudentManagementContext:DbContext
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
        //Ensure the Connstring name matches the name given in base

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasOptional(s => s.School).WithRequired();

            #region
            /// <summary>
            /// specify mapping TPC
            /// classes should not have navigational properties.
            /// mapping of child type and if they are inherited
            /// 
            /// fluent API mapping
            /// </summary>

            //modelBuilder.Entity<AlumniStudents>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("AlumniStudent");
            //});
            //modelBuilder.Entity<CurentStudents>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("CurrentStudent");
            //});
            #endregion

            //modelBuilder.HasDefaultSchema("My");        //change default schema

            //relationship between classes
            //one to one: navigation from ori to navi and navi to ori with out list (in class)
            //in fluent api
            modelBuilder.Entity<Student>().HasOptional(s => s.School).WithRequired(t => t.Student);
            //Student => School optional        can change to required
            //School => Student Required


        }

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
