/* 
with the using directive, we're importing a common namespace called System. Similar to require or import when using modules in Node.js, 
using directive lets us use the corresponding namespace (System) without needing to qualify its use when using one of its members.
The System namespace is part of the .NET framework and is a collection of commonly used methods, data types, and data structures.
*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        // Task is an asynchronous method
        async static Task Main(string[] args)
        {
            // Ask user if they want to enter employee data, if yes GetEmployees() will run
            List<Employee> employees;
            Console.WriteLine("Would you like to enter employee information? (y/n): ");
            string response1 = Console.ReadLine() ?? "";
            if (response1 == "y" || response1 == "yes" || response1 == "Yes")
            {
                employees = PeopleFetcher.GetEmployees();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                await Util.MakeBadges(employees);
            }

            // Ask user if they want to fetch employee data from, if yes GetFromApi() will run
            Console.WriteLine("Would you like to fetch employee data from the API? (y/n): ");
            string response2 = Console.ReadLine() ?? "";
            if (response2 == "y" || response2 == "yes" || response2 == "Yes")
            {
                employees = await PeopleFetcher.GetFromApi();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                await Util.MakeBadges(employees);
            }
        }
    }
}