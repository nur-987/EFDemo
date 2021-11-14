using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo2
{
    //[Table("MyTable")]
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int StudentRollNumber { get; set; }
        public string StudentRemarks { get; set; }
        public int StudentID { get; set; }
        public List<School> SchoolStudied { get; set; }
    }

    public class School
    {
        public string Name { get; set; }
        public int SchoolID { get; set; }
        public List<Student> StudentEnrolled { get; set; }
    }

    public class StudentDetails
    {
        public int StudentDetailsId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public Student Student { get; set; }
    }

    public class EmergerncyNumber
    {
        public int HpNumber { get; set; }
        public string Relationship { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi Welcome to first EF demo");
            using (StudentManagementContext stuContext = new StudentManagementContext())
            {
                Student student1 = new Student() { Name = "Han", Address = "Pearson Vue, 1" };
                School school1 = new School() { Name = "Han" };
                stuContext.Schools.Add(school1);
                stuContext.Students.Add(student1);
                stuContext.SaveChanges();
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
