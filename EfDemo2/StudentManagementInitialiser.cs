using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo2
{
    /// <summary>
    /// migrate existing data and have initial data. 
    /// code based or automated.
    /// 
    /// Has to inherit from chosen method in Context constructor
    /// </summary>
    public class StudentManagementInitialiser:DropCreateDatabaseAlways<StudentManagementContext>
    {
        protected override void Seed(StudentManagementContext context)
        {
            //to add data into the DB

            base.Seed(context);

            Student student1 = new Student() { Name = "Penny", Address = "Pearson Vue, 1" };
            School school1 = new School() { Name = "International School" };
            context.Students.Add(student1);
            context.Schools.Add(school1);

        }
    }
}
