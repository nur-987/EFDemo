﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        //navigational property
        public School School { get; set; }


    }
    public class AlumniStudents : Student
    {
        public int GradYear { get; set; }
    }

    public class CurentStudents : Student
    {
        public int Grade { get; set; }
    }

    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }

        //Navigational property
        public List<Student> StudentList { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("runnnig EF demo");
            using (StudentManagementContext studentContext = new StudentManagementContext())
            {
                //id is auto generated

                Student student1 = new Student() { Name = "Charlie" };
                School school1 = new School() { SchoolName = "AAA" };
                student1.School = school1;
                AlumniStudents student2 = new AlumniStudents() { Name = "Ben" };
                student2.School = school1;
                CurentStudents student3 = new CurentStudents() { Name = "Genny" };
                student3.School = school1;

                studentContext.Schools.Add(school1);

                studentContext.Students.Add(student1);
                studentContext.Students.Add(student2);
                studentContext.Students.Add(student3);

                studentContext.SaveChanges();
            }
            Console.WriteLine("end of operation");
            Console.ReadLine();
        }
    }
}

//NOTES
//any property set as reference type automatically set as nullable
//any value type = deafault will not be nullable
//int and double will auto have 0 or 0.0 if you dnt give a value.
//the column sequence: PK, then based on properties listed in POCO class.

//Inheritance: 
//This page is following TPH(table for hierarchy)
//others: TPP, TPC