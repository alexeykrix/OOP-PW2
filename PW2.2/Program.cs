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
            List<Employee> employees = ReadDataFromFile("employees.txt");

            List<Employee> sortedBySalary = employees
                .OrderByDescending(e => e.Salary)
                .ToList();

            Console.WriteLine("Sorted by salary:");
            foreach (Employee employee in sortedBySalary)
            {
                Console.WriteLine($"{employee.Name} - {employee.Salary:C} | {employee.YearsOfExperience} years");
            }

            Console.WriteLine();

            List<Employee> sortedByExperience = employees
                .OrderByDescending(e => e.YearsOfExperience)
                .ToList();

            Console.WriteLine("Sorted by experience:");
            foreach (Employee employee in sortedByExperience)
            {
                Console.WriteLine($"{employee.Name} - {employee.YearsOfExperience} years of experience | {employee.Salary}$");
            }

            Console.ReadKey();
        }

        static List<Employee> ReadDataFromFile(string filePath)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    decimal salary = decimal.Parse(parts[1]);
                    int yearsOfExperience = int.Parse(parts[2]);

                    employees.Add(new Employee(name, salary, yearsOfExperience));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data from file: {ex.Message}");
            }

            return employees;
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfExperience { get; set; }

        public Employee(string name, decimal salary, int yearsOfExperience)
        {
            Name = name;
            Salary = salary;
            YearsOfExperience = yearsOfExperience;
        }
    }
}
