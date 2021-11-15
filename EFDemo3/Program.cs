using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo3
{
    /// <summary>
    /// Migration Example
    /// </summary>
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StudentRollNumber { get; set; }
        public string StudentRemarks { get; set; }
        public School SchoolEnrolled { get; set; }
    }

    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public List<Student> StudentEnrolled { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hi Welcome to first EF demo");
            using (SchoolMan2DbContext context = new SchoolMan2DbContext())
            {
                School school1 = new School() { Name = "International School" };
                Student student1 = new Student() { Name = "Penny", Address = "Pearson Vue, 1" , SchoolEnrolled=school1};
                Student student2 = new Student() { Name = "Henry", Address = "Madiston Road, 32", SchoolEnrolled = school1 };

                context.Schools.Add(school1);
                context.Students.Add(student1);
                context.Students.Add(student2);

                context.SaveChanges();

            }
            Console.WriteLine("end of operation");
            Console.ReadLine();
        }
    }
}
