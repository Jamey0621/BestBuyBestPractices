using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace BestBuyBestPractices
{
   public class DapperEmployeesRepository : IEmployessRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperEmployeesRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Employees> GetALLEmployees()
        {
            return _connection.Query<Employees>("SELECT * FROM Departments;").ToList();
        }
    }
}
