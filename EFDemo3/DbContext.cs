using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo3
{
    class SchoolMan2DbContext:DbContext
    {
        public SchoolMan2DbContext() : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SchoolMan2DbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
