using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo2
{/// <summary>
/// in om console: 
/// enable-migration => 
/// add-migration  => code base migration
/// </summary>
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext() : base()
        { 
            Database.SetInitializer(new CreateDatabaseIfNotExists<StudentManagementContext>());
            //Database.SetInitializer(new(MigrateDatabaseToLatestVersion<StudentManagementContext>()));
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StudentManagementContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<StudentManagementContext>());
            
            //custom initialiser
            Database.SetInitializer(new StudentManagementInitialiser());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());

            //one to one relationship
            modelBuilder.Entity<Student>().HasRequired(s => s.SchoolStudied).WithRequiredPrincipal(t => t.StudentEnrolled);

            //one to one or zero
            modelBuilder.Entity<Student>().HasOptional(s => s.SchoolStudied).WithRequired(t => t.StudentEnrolled);

            //many to many      create List on both sides
            //creates 3 tables; school, student, joint info of student n school
            modelBuilder.Entity<Student>().HasMany(m => m.SchoolList).WithMany(s => s.StudentList).Map(ms =>
            {
                ms.MapLeftKey("StudentId");
                ms.MapRightKey("SchoolId");
                ms.ToTable("StudentSchool");

            });

            //stored procedures     already have existing stored procedure by sql
            //to map it specifically
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());         //ceates a SP for each entitiy



        }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }
    
    }
}

//what is a stored Procedure?
//to save or remeber certain functions.
//get calld when they are triggered
