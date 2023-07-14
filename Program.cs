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
        /*
        void signifies that the return of this executable method will be void
        static implies that the scope of this method is at the class level, not the object level
        */
        static void Main(string[] args)
        {
            List<string> employees = new List<string>() { "adam", "amy" };
            employees.Add("barbara");
            employees.Add("billy");
            Console.WriteLine("Please enter a name: ");
            // Get a name from the console and assign it to a variable
            string input = Console.ReadLine() ?? "";
            employees.Add(input);
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }

    }
}
