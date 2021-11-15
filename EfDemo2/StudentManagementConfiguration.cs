using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo2
{
    /// <summary>
    /// whenever the DBContext on model create gets to huge
    /// can move it out to a config.
    /// separate based on the class
    /// </summary>
    class StudentManagementConfiguration:EntityTypeConfiguration<Student>
    {

        public StudentManagementConfiguration()
        {
            this.ToTable("MyTable", "MyTableSchema");
        }
        

    }
}
