using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;

namespace BestbuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        // Field or local variable for making queries to the Database
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()


        {
            var depos = _connection.Query<Department>("SELECT * FROM Departments;");
            return _connection.Query<Department>("SELECT * FROM Departments;");

        }

        public void InsertDepartment(string NewDepartmentName)
        {
         _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
        new { departmentName = NewDepartmentName });

        }

        public void InsertDepartment()
        {
            throw new NotImplementedException();
        }
    }
}
