/* 
with the using directive, we're importing a common namespace called System. Similar to require or import when using modules in Node.js, 
using directive lets us use the corresponding namespace (System) without needing to qualify its use when using one of its members.
The System namespace is part of the .NET framework and is a collection of commonly used methods, data types, and data structures.
*/

using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    /* 
    Within the namespace, there's a class named Program and a static method name Main(); it is the entry point of the application 
    and is invoked when the program runs, it's where the code is placed.
    */
    class Program
    {
        // Will return a list of Employee instances
        static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            while (true)
            {

                Console.WriteLine("Enter first name: (leave empty to exit): ");

                string firstName = Console.ReadLine() ?? "";

                if (firstName == "")
                {
                    break;
                }
                // Console.ReadLine() for each value
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine() ?? "";
                Console.Write("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine() ?? "");
                Console.Write("Enter Photo Url: ");
                string photoUrl = Console.ReadLine() ?? "";
                // Create a new Employee instance
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                // Add currentEmployee
                employees.Add(currentEmployee);
            }
            return employees;
        }

        // PrintEmployees() method accepts List<Employee> as a parameter
        static void PrintEmployees(List<Employee> employees)
        {
            // Iterating over Employee instances to get an employee's full name from GetFullName() 
            for (int i = 0; i < employees.Count; i++)
           
            {
                // Each item in employees is now an Employee instance

                /*
                We want the first argument (argument {0}), the id, to be left-aligned and padded to at least 10 characters, so we enter {0,-10}. Then we want to print a tab character (\t). 
                We want the next argument ({1}), the name, to be left-aligned and padded to 20 characters—hence {1,-20}.
                Next, we want to print another tab character (\t). And finally, we want to print the last argument ({2}), the photo URL, with no formatting: {2}.
                Put that all together, and it makes {0,-10}\t{1,-20}\t{2}, which is the formatting formula for the output.
                */
                string template = "{0,-10}\t{1,-20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
            }
        }

        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            PrintEmployees(employees);
        }
    }
}
