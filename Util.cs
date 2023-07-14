using System;
using System.IO;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Util
    {
        /*
        Method is static, it belongs to the class itself instead of individual instances or objects; 
        we can access this method from the class name.
        */

        // PrintEmployees() method accepts List<Employee> as a parameter
        public static void PrintEmployees(List<Employee> employees)
        {
            // Iterating over Employee instances to get an employee's full name from GetFullName() 
            for (int i = 0; i < employees.Count; i++)
            {
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
                    Console.WriteLine(employees[i]);
                }
            }

        }

        public static void MakeCSV(List<Employee> employees)
        {
            // Check to see if folder exists
            if (!Directory.Exists("data"))
            {
                // If not, create it
                Directory.CreateDirectory("data");
            }

            // using temporarily a resource
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                file.WriteLine("ID, Name, PhotoUrl");

                // Loop over employees
                for (int i = 0; i < employees.Count; i++)
                {
                    {
                        string template = "{0,-10}\t{1,-20}\t{2}";
                        file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));

                    }
                }
            }
        }
    }
}