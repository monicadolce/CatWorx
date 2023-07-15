using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using SkiaSharp;
using System.Threading.Tasks;

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

            /*
            async—The MakeBadges() method will be asynchronous and use an async/await syntax that is similar to JavaScript. 
            This is necessary because the method we use from the HttpClient object is asynchronous.
            Task—This is the required return type for an asynchronous method that returns no value.
            public—Must be accessible by the Main() method.
            void—The purpose of these methods is to create a file or print information, so there is no need for a return.
            static—Scoped to class, so can be invoked directly without instantiating an object.
            List<Employee>—Employees parameters, the data source of employee info.
            */
            async public static Task MakeBadges(List<Employee> employees)
            {
                // Layout variables
                int BADGE_WIDTH = 669;
                int BADGE_HEIGHT= 1044;

                int PHOTO_LEFT_X = 184;
                int PHOTO_TOP_Y = 215;
                int PHOTO_RIGHT_X = 486;
                int PHOTO_BOTTOM_Y = 517;

                int COMPANY_NAME_Y = 150;

                int EMPLOYEE_NAME_Y = 600; 

                int EMPLOYEE_ID_Y = 730;

                // instance of HttpClient is disposed after code in block has run
                using(HttpClient client = new HttpClient())
                {
                    for (int i = 0; i < employees.Count; i++)
                    {
                        SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
                        SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));
                        
                        // SKData data = background.Encode();
                        // data.SaveTo(File.OpenWrite("data/employeeBadge.png"));

                        SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
                        SKCanvas canvas = new SKCanvas(badge);

                        canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
                        canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));
                        

                        SKPaint paint = new SKPaint();
                        paint.TextSize = 42.0f;
                        paint.IsAntialias = true;
                        paint.Color = SKColors.White;
                        paint.IsStroke = false;
                        paint.TextAlign = SKTextAlign.Center;
                        paint.Typeface = SKTypeface.FromFamilyName("Arial");
                        // Company name
                        canvas.DrawText(employees[i].GetCompanyName(), BADGE_WIDTH / 2f, COMPANY_NAME_Y, paint);

                        paint.Color = SKColors.Black;
                        // Employee Name
                        canvas.DrawText(employees[i].GetFullName(), BADGE_WIDTH / 2f, EMPLOYEE_NAME_Y, paint);

                        paint.Typeface = SKTypeface.FromFamilyName("Courier New");
                        // Employee ID
                        canvas.DrawText(employees[i].GetId().ToString(), BADGE_WIDTH / 2f, EMPLOYEE_ID_Y, paint);

                        
                        
                        SKImage finalImage = SKImage.FromBitmap(badge);
                        SKData data = finalImage.Encode();
                        string template = "data/{0}_badge.png";
                        data.SaveTo(File.OpenWrite(string.Format(template, employees[i].GetId())));
                        // data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
                       
                    }
                }
            }
            // {
            //     // Create image
            //     SKImage newImage = SKImage.FromEncodedData(File.OpenRead("badge.png"));

            //     SKData data = newImage.Encode();
            //     data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
            // }
        
    }
}