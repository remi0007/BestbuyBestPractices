using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace BestbuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
             #region Configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            #endregion
            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Jello users, here are the current departments:");
            Console.WriteLine("Please press enter...");
            Console.ReadLine();

            var depos = repo.GetAllDepartments();
            Print(depos);

            

            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine();

                if (userResponse.ToLower() == "Yes")
            {
                Console.WriteLine($"What is the name of your new Department?");
                    userResponse = Console.ReadLine();

                repo.InsertDepartment(userResponse);
                repo.GetAllDepartments();
            }
            Console.WriteLine("Have a great day!!");
        }

        private static void Print(IEquatable<Department> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
            }
        }
    }
}
