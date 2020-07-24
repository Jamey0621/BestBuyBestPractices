using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);
            bool todo = true;
            do
            {
                Console.WriteLine("What would you like to edit?");
                Console.WriteLine("Choose the corsponding number,");
                Console.WriteLine("1: Departmennts | 2: Employess | 3: Products | 4: Reviews");
                var ans = Convert.ToInt32(Console.ReadLine());



                if (ans == 1)
                {
                    Console.WriteLine("You have chosen to enter the deparments!, ");
                    Console.WriteLine("What would you like to do?");

                    Console.WriteLine("1: Add a department | 2: Delete a department | 3: List The Departments | 4: Return to start ");
                    int depAns = Convert.ToInt32(Console.ReadLine());

                    if (depAns == 1)
                    {
                        Console.Write("Type a new Department name:");
                        var newDepartmentName = Console.ReadLine();

                        repo.InsertDepartment(newDepartmentName);

                        var departments = repo.GetALLDepartments();

                        foreach (var dept in departments)
                        {
                            Console.WriteLine($"{dept.DepartmentID} || {dept.Name}");
                            Console.WriteLine("--------------");
                        }
                    }


                    else if (depAns == 2)
                    {
                        var departments = repo.GetALLDepartments();

                        foreach (var dept in departments)
                        {
                            Console.WriteLine($"{dept.DepartmentID} || {dept.Name}");
                            Console.WriteLine("--------------");
                        }
                        Console.WriteLine("Write the Department Id for the department you want to delete.");
                        var depID = Convert.ToInt32(Console.ReadLine());

                        repo.DeleteDepartment(depID);

                        Console.WriteLine("Completed!");


                    }
                    else if (depAns == 3)
                    {
                        var departments = repo.GetALLDepartments();

                        foreach (var dept in departments)
                        {
                            Console.WriteLine($"{dept.DepartmentID} || {dept.Name}");
                            Console.WriteLine("--------------");
                        }
                    }
                    else if (depAns == '4')
                    {

                        todo = false;
                    }
                    
                    
                    
                    
                    Console.WriteLine("Do you want to continue? Y/N");
                    var cont = Console.ReadLine();
                    if (cont == "y")
                    {
                        todo = false;
                    }
                    else { todo = true; }




                }
            } while (todo == false);
            

           
          /*  if (answer == "yes")
            {
                foreach (var dept in departments )
                {
                    Console.WriteLine(dept.Name);
                    Console.WriteLine("----------------------");
                }
            }
            else
            {
                Console.WriteLine("Thankyou!");
                System.Environment.Exit(1);
            }

            Console.WriteLine("DO you want to create a deparment?");
            ans = Console.ReadLine();
            answer = ans.ToLower();

            if (answer == "yes")
            {


                Console.Write("Type a new Department name:");
                var newDepartmentName = Console.ReadLine();

                repo.InsertDepartment(newDepartmentName);



                foreach (var dept in departments)
                {
                    Console.WriteLine(dept.Name);
                }
            }
            else
            {
                Console.WriteLine("NO Problem, Have a great day!");
                System.Environment.Exit(1);
            }

            var prorepo = new DapperProductRepository(conn);
            Console.Write("Product Name: ");
            var newName = Console.ReadLine();
            Console.Write("Price of Product: ");
            var newPrice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Product CategoryID: ");
            var newCategoryID = Convert.ToInt32(Console.ReadLine());

            prorepo.CreatProduct(newName, newPrice, newCategoryID);

            var products = prorepo.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine(prod.name, prod.price, prod.categoryId);
            }

            */
        }
    }
}
