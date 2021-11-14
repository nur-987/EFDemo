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
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }






        
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
