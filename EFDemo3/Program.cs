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
        public List<School> SchoolList { get; set; }
    }

    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public Student StudentEnrolled { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
