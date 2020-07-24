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

            Console.WriteLine("Do you want to see the depatments");
            var ans = Console.ReadLine();
            var answer = ans.ToLower();

            var departments = repo.GetALLDepartments();

           
            if (answer == "yes")
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


        }
    }
}
