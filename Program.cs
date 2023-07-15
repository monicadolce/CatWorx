/* 
with the using directive, we're importing a common namespace called System. Similar to require or import when using modules in Node.js, 
using directive lets us use the corresponding namespace (System) without needing to qualify its use when using one of its members.
The System namespace is part of the .NET framework and is a collection of commonly used methods, data types, and data structures.
*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


// namespace CatWorx.BadgeMaker
// {
//     /* 
//     Within the namespace, there's a class named Program and a static method name Main(); it is the entry point of the application 
//     and is invoked when the program runs, it's where the code is placed.
//     */

    
//     class Program
//     {
//         // Will return a list of Employee instances
        
        
// //  public static List<Employee> GetEmployees()
// //         {
            
    
// //             List<Employee> employees = new List<Employee>();
           
// //             while (true)
// //             {

// //                 Console.WriteLine("Enter first name: (leave empty to exit): ");

// //                 string firstName = Console.ReadLine() ?? "";

// //                 if (firstName == "")
// //                 {
// //                     break;
// //                 }
// //                 // Console.ReadLine() for each value
                
// //                 Console.Write("Enter last name: ");
// //                 string lastName = Console.ReadLine() ?? "";
// //                 Console.Write("Enter ID: ");
// //                 int id = Int32.Parse(Console.ReadLine() ?? "");
// //                 Console.Write("Enter Photo Url: ");
// //                 string photoUrl = Console.ReadLine() ?? "";
// //                 // Create a new Employee instance
// //                 Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
// //                 // Add currentEmployee
// //                 employees.Add(currentEmployee);
// //             }
// //             return employees;
// //         }
        
//         async static Task Main(string[] args)
//         {
//             // List<Employee> employees = GetEmployees();
//             employees = await PeopleFetcher.GetFromApi();
            
//             Util.PrintEmployees(employees);
//             Util.MakeCSV(employees);
//             await Util.MakeBadges(employees);
 
//         }
//     }
// }




namespace CatWorx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args)
        {
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

            Console.WriteLine("Would you like to fetch employee data from the API? (y/n): ");
            string response2 = Console.ReadLine() ?? "";
            if (response2 == "y" || response2 == "yes" || response2 == "Yes")
            {
                // employees = PeopleFetcher.GetFromAPI();
                employees = await PeopleFetcher.GetFromApi();
                Util.PrintEmployees(employees);
                Util.MakeCSV(employees);
                await Util.MakeBadges(employees);
            }
        }
    }
}