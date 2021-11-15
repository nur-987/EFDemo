using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo2
{
    //[Table("MyTable")]
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StudentRollNumber { get; set; }
        public string StudentRemarks { get; set; }

        [ForeignKey("SchoolStudied")]
        public int SchoolId { get; set; }
        public School SchoolStudied { get; set; }
        public List<School> SchoolList { get; set; }
    }

    public class School
    {
        public string Name { get; set; }

        [ForeignKey("StudentEnrolled")]
        public int SchoolID { get; set; }
        public Student StudentEnrolled { get; set; }

        public List<Student> StudentList { get; set; }
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
                Student student1 = new Student() { Name = "Penny", Address = "Pearson Vue, 1" };
                School school1 = new School() { Name = "International School" };
                
                //for one to one
                student1.SchoolStudied = school1;
                school1.StudentEnrolled = student1;

                //for many to many
                List<School> schList = new List<School>();
                schList.Add(school1);
                List<Student> stdList = new List<Student>();
                stdList.Add(student1);
                student1.SchoolList = schList;
                school1.StudentList = stdList;
                

                stuContext.Schools.Add(school1);
                stuContext.Students.Add(student1);
                stuContext.SaveChanges();

                //in custom initialiser => Seed
                //seeded data added into DB first
                //then these data here will be added.

            }
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
