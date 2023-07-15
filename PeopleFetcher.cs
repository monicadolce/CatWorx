using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net.Http;


namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees()
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

        async public static Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();
            using (HttpClient client = new HttpClient())
            {
                // Download string from randomuser api
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                JObject json = JObject.Parse(response);
                // Loop through each token in api response results
                foreach (JToken token in json.SelectToken("results")!)
                {
                    // Parse JSON data
                    Employee emp = new Employee
                    (
                      token.SelectToken("name.first")!.ToString(),
                      token.SelectToken("name.last")!.ToString(),
                      Int32.Parse(token.SelectToken("id.value")!.ToString().Replace("-", "")),
                      token.SelectToken("picture.large")!.ToString()
                    );
                    employees.Add(emp);
                }

            }
            return employees;
        }
    }
}
