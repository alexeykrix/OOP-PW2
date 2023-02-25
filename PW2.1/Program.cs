using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LambdaExpressionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = ReadDataFromFile("students.txt");

            double minGrade = 60.0;
            double maxGrade = 100.0;

            List<Student> filteredStudents = students
                .Where(s => s.Grade >= minGrade && s.Grade <= maxGrade)
                .ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.Name} has a grade {student.Grade}");
            }

            Console.ReadKey();
        }

        static List<Student> ReadDataFromFile(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    double grade = double.Parse(parts[1]);

                    students.Add(new Student(name, grade));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data from file: {ex.Message}");
            }

            return students;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public double Grade { get; set; }

        public Student(string name, double grade)
        {
            Name = name;
            Grade = grade;
        }
    }
}
