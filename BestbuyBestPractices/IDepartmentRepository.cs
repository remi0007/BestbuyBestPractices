using System;
using System.Collections.Generic;
using System.Text;

namespace BestbuyBestPractices
{
    public interface IDepartmentRepository
    {
        // we are here saying that we need a method called GetAllDepartments that returns a collection
        // that conforms to IEnumerable<T>
        IEnumerable<Department> GetAllDepartments();

        void InsertDepartment(string NewDepartmentName);
    }
}
