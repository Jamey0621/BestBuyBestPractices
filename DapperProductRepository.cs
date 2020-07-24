using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BestBuyBestPractices
{
 public   class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreatProduct(string newName, int newPrice, int newCategoryID)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) VALUES (@name, @price, @catergoryID);",
            new { Name = newName, Price = newPrice, CatergoryID = newCategoryID });
        }

        public void DeleteProduct(string name, int price, int category)
        {
            _connection.Execute("");
        }
        public IEnumerable<ProductRepository> GetAllProducts()
        {
            return _connection.Query<ProductRepository>("SELECT * FROM Departments;").ToList();
        }
    }
}
